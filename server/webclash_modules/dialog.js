exports.createUnique = function(id, dialogData) {
    try {
        let start = -1;

        for (let i = 0; i < dialogData.length; i++)
            if (dialogData[i].entry) {
                start = i;

                break;
            }

        if (start === -1) {
            output.give("Could not create unique dialog, dialog has no entry.");

            return [];
        }

        let result = JSON.parse(JSON.stringify(dialogData));

        this.inspectItem(id, start, result);

        return result;
    }
    catch (err) {
        output.giveError("Could not create unique dialog: ", err);

        return [];
    }
};

exports.inspectItem = function(id, itemId, dialogData) {
    let current = dialogData[itemId];

    if (current == undefined)
        return;

    if (current.getVariableEvent != undefined) {
        dialogData[itemId] = undefined;

        let next = -1;

        if (game.getPlayerGlobalVariable(id, current.getVariableEvent.name))
            next = current.options[0].next;
        else
            next = current.options[1].next;

        if (next !== -1) {
            dialogData[next].entry = current.entry;

            dialog.inspectItem(id, next, dialogData);
        }

        return;
    }

    current.options.forEach(function(option) {
        if (option.next === -1)
            return;

        let next = dialogData[option.next];

        if (next.getVariableEvent != undefined) {
            dialogData[option.next] = undefined;

            if (game.getPlayerGlobalVariable(id, next.getVariableEvent.name))
                option.next = next.options[0].next;
            else
                option.next = next.options[1].next;
            
            dialogData[option.next].entry = next.entry;
        }

        dialog.inspectItem(id, option.next, dialogData);
    });
};

exports.handleEvents = function(id, channel, dialogEvent, clientData) {
    let quest;

    //Handle events

    //Load map event

    if (dialogEvent.eventType === 'LoadMap') {
        //Get map index

        let new_map = tiled.getMapIndex(dialogEvent.loadMapEvent.map);

        //Check if map is valid

        if (new_map === -1)
            return;

        //Load map

        game.loadMap(channel, dialogEvent.loadMapEvent.map);

        //Set position

        game.setPlayerTilePosition(
            id,
            new_map,
            dialogEvent.loadMapEvent.positionX,
            dialogEvent.loadMapEvent.positionY
        );
    }

    //Give item event

    else if (dialogEvent.eventType === 'GiveItem') {
        //Add item(s)

        let done = false;

        for (let a = 0; a < dialogEvent.giveItemEvent.amount; a++) {
            if (items.addPlayerItem(channel, id, dialogEvent.giveItemEvent.item))
                done = true;
        }

        if (!done)
            return;
    }

    //Affect player event

    else if (dialogEvent.eventType === 'AffectPlayer') {
        //Add differences

        //Health

        if (dialogEvent.affectPlayerEvent.healthDifference > 0)
            game.healPlayer(id, dialogEvent.affectPlayerEvent.healthDifference);
        else if (dialogEvent.affectPlayerEvent.healthDifference < 0)
            game.damagePlayer(id, dialogEvent.affectPlayerEvent.healthDifference);

        //Mana

        game.deltaManaPlayer(id, dialogEvent.affectPlayerEvent.manaDifference);

        //Gold

        if (!game.deltaGoldPlayer(id, dialogEvent.affectPlayerEvent.goldDifference)) {
            channel.emit('CLIENT_DIALOG_EVENT_RESPONSE', { result: false, id: clientData.id });
            return;
        }
    }

    //Spawn NPC event

    else if (dialogEvent.eventType === 'SpawnNPC') {
        //Spawn event NPCs for the specified amount

        let pos = {
            x: game.players[id].pos.X+game.players[id].character.width/2,
            y: game.players[id].pos.Y+game.players[id].character.height,
        };

        for (let i = 0; i < dialogEvent.spawnNPCEvent.amount; i++)
            npcs.createEventNPC(
                map,
                dialogEvent.spawnNPCEvent.name,
                pos.x,
                pos.y,
                id,
                dialogEvent.spawnNPCEvent.hostile
            );
    }

    //Turn hostile event

    else if (dialogEvent.eventType === 'TurnHostile') {
        //Grab target NPC

        let npc = npcs.onMap[map][clientData.npc];

        //Kill original NPC

        npcs.killNPC(map, clientData.npc);

        //Create event NPC

        npcs.createEventNPC(
            map,
            npc.name,
            npc.pos.X+npc.clientData.character.width/2,
            npc.pos.Y+npc.clientData.character.height,
            id,
            true,
            function() {
                //On reset, respawn original npc

                npcs.respawnNPC(map, clientData.npc);
            }
        );

        //Respond and return

        channel.emit('CLIENT_DIALOG_EVENT_RESPONSE', { result: true, id: clientData.id });
        return;
    }

    //Show quest event

    else if (dialogEvent.eventType === 'ShowQuest') {
        //Send quest information to player,
        //if the quest has not been completed yet
        //or the quest can be repeated

        if (!quests.hasCompleted(id, dialogEvent.showQuestEvent.name) || dialogEvent.repeatable)
            quest = quests.getQuestDialog(dialogEvent.showQuestEvent.name);
        else {
            channel.emit('CLIENT_DIALOG_EVENT_RESPONSE', { result: false, id: clientData.id });

            return;
        }
    }

    //Show shop event

    else if (dialogEvent.eventType === 'ShowShop') {
        //Respond to make sure the dialog closes

        channel.emit('CLIENT_DIALOG_EVENT_RESPONSE', { result: true, id: clientData.id });

        //Open shop for the player

        shop.openShop(id, clientData.npc, clientData.id, dialogEvent.showShopEvent);
    }

    //Set player variable event

    else if (dialogEvent.eventType === 'SetVariable') {
        //Set player variable

        game.setPlayerGlobalVariable(
            id,
            dialogEvent.setVariableEvent.name,
            dialogEvent.setVariableEvent.value
        );
    }

    //Check if event is repeatable,
    //if not set a player global variable

    if (!dialogEvent.repeatable && dialogEvent.eventType !== 'ShowQuest') {
        game.setPlayerGlobalVariable(
            id,
            eventName,
            true
        );
    }

    //Respond true (success)

    channel.emit('CLIENT_DIALOG_EVENT_RESPONSE', { result: true, quest: quest, id: clientData.id });
};