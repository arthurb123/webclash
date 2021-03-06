//Main channel handler

exports.handleChannel = function(channel)
{
    //Create custom check functions

    const isInGame = function(checkAlive) {
        let inGame = (channel.playing != undefined &&
                      channel.playing &&
                      game.players[channel.name] != undefined);

        if (inGame && checkAlive)
            inGame = !game.players[channel.name].killed;

        return inGame;
    };

    //Disconnect and logout event listener

    const logOut = function() {
        if (channel.playing) {
            //Shorten name

            let id = channel.name;

            //Check if player is in-combat, 
            //if so do not logout

            if (combat.active.in(id))
                return;

            //Remove player

            game.removePlayer(channel);

            //Output

            output.give('User \'' + id + '\' has logged out.');
        }
    }

    channel.onDisconnect(logOut);
    channel.on('CLIENT_LOGOUT', logOut);

    //If the connected channel is not playing,
    //send to the landing page (login)

    if (channel.playing == undefined || !channel.playing)
        channel.emit('REQUEST_LANDING');

    //Send client and server name

    channel.emit('UPDATE_CLIENT_NAME', properties.clientName);
    channel.emit('UPDATE_SERVER_NAME', properties.serverName);

    //channel event listeners

    //Authentication events

    channel.on('CLIENT_LOGIN', function(data) {
        //Check if valid package

        if (data === undefined || 
            data.name === undefined ||
            data.pass === undefined)
            return;

        //Login account
        
        accounts.login(
            channel, 
            data.name.toString(), 
            data.pass.toString()
        );
    });

    channel.on('CLIENT_REGISTER', function(data) {
        //Check if valid package

        if (data === undefined || 
            data.name === undefined)
            return;

        //Register account

        accounts.register(
            channel, 
            data.name.toString(), 
            data.pass.toString()
        );
    });

    channel.on('CLIENT_CREATE_CHARACTER', function(data) {
        try {
            //Check if client is already in-game

            if (isInGame())
                return;

            //Check if player is allowed to
            //create a character

            storage.load('accounts', channel.name, function(account) {
                if (account.created)
                    return;

                //Check if character exists and
                //is an allowed option

                if (properties.playerCharacters[data] == undefined)
                    return;

                //Load stats

                storage.load('stats', channel.name, function(player) {
                    //Change character name

                    player.char_name = properties.playerCharacters[data];

                    //Calculate starting position based
                    //on the chosen character

                    let char = game.characters[player.char_name];

                    let spos = game.tileToActualPosition(
                        tiled.getMapIndex(properties.startingMap),
                        properties.startingTile.x,
                        properties.startingTile.y,
                        char.width,
                        char.height
                    );

                    //Set player starting position

                    player.pos = {
                        X: spos.x,
                        Y: spos.y
                    };

                    //Save account

                    account.created = true;
                    storage.save('accounts', channel.name, account);

                    //Save player

                    game.savePlayer(channel.name, player, function() {
                        //Request game

                        channel.emit('REQUEST_GAME');
                    });
                });
            });
        }
        catch (err) {
            output.giveError('Could not handle character creation: ', err);
        }
    });

    channel.on('CLIENT_JOIN_GAME', function() {
        try {
            //Check if client is already in-game

            if (isInGame())
                return;

            //Add client as player if the player
            //does not exist yet, otherwise
            //refresh player

            if (game.players[channel.name] == undefined)
                game.addPlayer(channel);
            else
                game.refreshPlayer(channel, channel.name);

            //Send MOTD message

            server.syncChatMessage(properties.welcomeMessage, channel);

            //Send game time

            server.syncGameTime(channel);

            //Set playing

            channel.playing = true;
        }
        catch (err) {
            output.giveError('Could not handle game join: ', err);
        }
    });

    //Player interaction events

    channel.on('CLIENT_PLAYER_UPDATE', function(data) {
        try {
            //Check if in-game

            if (!isInGame(true))
                return;

            //Shorten channel name

            let id = channel.name;

            //Cancel player casting

           combat.cancelPlayerCasting(id);

            //Check data

            let type = '';

            if (data.moving !== undefined) {
                game.players[id].moving = data.moving;
                type = 'moving';
            }
            if (data.direction !== undefined) {
                game.players[id].direction = data.direction;
                type = 'direction';
            }
            if (data.pos !== undefined) {
                //Check if valid movement

                let valid = true;

                //Check if position delta is within limit

                let dX = Math.abs(game.players[id].pos.X-data.pos.X);
                let dY = Math.abs(game.players[id].pos.Y-data.pos.Y);

                //Higher banding factor allows for more inconsistencies
                //in movement, this is useful for people with slower
                //connections or when the server is congested to prevent
                //rubber banding. However this also raises the risk of 
                //exploitation. Adjust carefully!

                let bandingFactor = 2;
                
                let dMax = game.players[id].character.movement.max*bandingFactor;
                dMax *= game.players[id].statusEffectsMatrix['movementSpeedFactor'];

                if (dX > dMax ||
                    dY > dMax)
                    valid = false;

                //Check for collider violation if enabled

                if (properties.serverCheckColliders) {
                    //Specify a factor for the violation margin,
                    //keeping this under 1 makes sure to provide
                    //a smoother experience for players; especially
                    //with a slower internet connection

                    let factor = .75;

                    //Check player collider against all colliders on map

                    let collider = game.players[id].character.collider;

                    //Create collider rectangle

                    let rect = {
                        x: data.pos.X + collider.x + (1-factor) * collider.width,
                        y: data.pos.Y + collider.y + (1-factor) * collider.height,
                        w: collider.width  * factor,
                        h: collider.height * factor
                    };

                    //Check for collider violation or outside of the map

                    let map = game.players[id].map_id;

                    //TODO: For the checking if the player is inside the
                    //      map, the collider rect should not be used.
                    //      Instead the normal bounding box of the character could
                    //      be used? It might just not be necessary but it
                    //      requires some further looking into!

                    if (!tiled.checkRectangleInMap(map, rect) ||
                        tiled.checkCollisionWithRectangle(map, rect, id))
                        valid = false;
                }

                //Handle accordingly
                    
                if (valid) {
                    game.players[id].pos.X = Math.round(data.pos.X);
                    game.players[id].pos.Y = Math.round(data.pos.Y);

                    type = 'position';
                } else
                    server.syncPlayerPartially(id, 'position', channel, false);
            }

            //Sync across all

            if (type.length > 0)
                server.syncPlayerPartially(id, type, channel, true);
        }
        catch (err)
        {
            output.giveError('Could not handle player data: ', err);
        }
    });

    channel.on('CLIENT_PLAYER_ACTION', function(data) {
        try
        {
            //Check if in-game

            if (!isInGame(true))
                return;

            //Shorten channel name

            let id = channel.name;

            //Try to create an action based
            //on the map conditions (if PvP map)

            let result = combat.performPlayerAction(
                data.slot, 
                id, 
                data.target, 
                data.angle,
                tiled.maps[game.players[id].map_id].pvp
            );

            //Emit casting action packages to self and others

            if (result) {
                server.syncPlayerActionCast(data.slot, id, channel);
                server.syncPlayerActionCast(data.slot, id, channel, true);
            }
        }
        catch (err)
        {
            output.giveError('Could not add player action: ', err);
        }
    });

    channel.on('CLIENT_RESPAWN_PLAYER', function() {
        try
         {
            //Check if in-game

            if (!isInGame())
                return;

            //Shorten channel name

            let id = channel.name;

            //Try to respawn player

            game.respawnPlayer(id);
         }
         catch (err)
         {
            output.giveError('Could not respawn player: ', err);
         }
    });

    channel.on('CLIENT_REQUEST_MAP', function(data) {
        try {
            //Check if in-game and if data is valid

            if (!isInGame(true) || data == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Shorten current map

            let map = game.players[id].map_id;

            //Get next map

            let next_map = tiled.getMapIndex(data);

            //Check if valid player and if
            //the player is on a different map

            if (id == -1 || next_map == -1 || game.players[id].map === data)
                return;

            //Check if player is near to a loadMap property

            let result = tiled.checkPropertyWithRectangle(
                map, 
                'loadMap', 
                data,
                {
                    x: game.players[id].pos.X,
                    y: game.players[id].pos.Y,
                    w: game.players[id].character.width,
                    h: game.players[id].character.height
                }
            );

            if (!result.near)
                return;

            //Check if positioning properties exist,
            //if they do reposition the player

            let properties = [];

            if (result.tile != undefined && result.object != undefined)
                properties = tiled.getPropertiesFromTileObject(map, result.tile, result.object);
            else if (result.tile != undefined)
                properties = tiled.getPropertiesFromTile(map, result.tile);
            else if (result.object != undefined)
                properties = tiled.getPropertiesFromObject(map, result.object);

            if (properties != undefined)
                for (let p = 0; p < properties.length; p++)
                {
                    //Set position value if property exists

                    if (properties[p].name === 'positionX')
                        game.players[id].pos.X = (properties[p].value-tiled.maps[next_map].width/2+.5)*tiled.maps[next_map].tilewidth-game.players[id].character.width/2;
                    if (properties[p].name === 'positionY') 
                        game.players[id].pos.Y = (properties[p].value-tiled.maps[next_map].height/2+1)*tiled.maps[next_map].tileheight-game.players[id].character.height;
                }
            
            //Send map to player

            game.loadMap(channel, data);
        } catch (err) {
            output.giveError('Could not handle map request: ', err);
        }
    });

    channel.on('CLIENT_REQUEST_MAP_CONTENT', function() {
        try {
            //Check if in-game

            if (!isInGame(true))
                return;

            //Shorten channel name

            let id = channel.name;

            //Check if player requires setup

            //TODO: Move this to a more suitable
            //      method for increased cohesion

            if (!game.players[id].setup) {
                game.setupPlayer(channel);

                game.players[id].setup = true;
            }

            //Send player position to itself

            server.syncPlayerPartially(id, 'position', channel, false);

            //Send player to all players in the same map

            server.syncPlayer(id, channel, true);

            //Send all players in the same map

            game.sendPlayers(channel);

            //Send all NPCs in the same map

            npcs.sendMap(id);

            //Send all items in the same map

            items.sendMap(id);

            //Send map finished package

            //TODO: Seperate this from the map content,
            //      make it a seperate request in the
            //      client-server communication pipeline

            channel.emit('GAME_MAP_FINISHED');
        }
        catch (err) {
            output.giveError('Could not handle map content request: ', err);
        }
    });

    channel.on('CLIENT_NEW_CHAT', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame() || data == undefined)
                return;

            //Handle client input text

            let msg = '';

            //TODO: Check correct length
            //TODO: Check if spamming

            //Check if command

            if (data[0] === '/')
            {
                //Check command and handle output

                let output = input.handleCommand(data, channel);

                if (output == 'invalid')
                    msg = 'Invalid command.';
                else if (output == 'wrong')
                    msg = 'Incorrect command syntax.';
                else
                    return;

                server.syncChatMessage(msg, channel);

                return;
            }
            else
                msg = '<b>' + channel.name + '</b>: ' + input.filterText(data);

            //Send chat message to player and all others

            server.syncChatMessage(msg, channel, true);
            server.syncChatMessage(msg, channel);
        }
        catch (err) {
            output.giveError('Could not handle chat message: ', err);
        }
    });

    channel.on('CLIENT_USE_ITEM', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) || data == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Check if player has item

            if (!items.hasPlayerItem(id, data))
                return;

            //Use item

            let result = items.usePlayerItem(id, data);

            //Respond with result

            channel.emit('CLIENT_USE_ITEM_RESPONSE', {
                valid: result,
                sounds: items.getItem(data).sounds
            });
        }
        catch (err) {
            output.giveError('Could not use item: ', err);
        }
    });

    channel.on('CLIENT_DROP_ITEM', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) || data == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Attempt to drop item

            items.dropPlayerItem(id, data);
        }
        catch (err) {
            output.giveError('Could not drop item: ', err);
        }
    });

    channel.on('CLIENT_UNEQUIP_ITEM', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) || data == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Get sounds

            let sounds = items.unequipPlayerEquipment(id, data);

            //Respond

            channel.emit('CLIENT_UNEQUIP_ITEM_RESPONSE', sounds);
        }
        catch (err) {
            output.giveError('Could not unequip item: ', err);
        }
    });

    channel.on('CLIENT_PICKUP_ITEM', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) || data == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Pick up world item

            if (!items.pickupItem(game.players[id].map_id, id, data))
            {
                //Failure, notify user

                server.syncChatMessage('You do not have enough inventory space.', channel);
            }
        }
        catch (err) {
            output.giveError('Could not pickup item: ', err);
        }
    });

    channel.on('CLIENT_SELL_ITEM', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) || data == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Try to sell item

            let sold = shop.sellItem(id, data.item, data.npc);

            //Respond with result

            channel.emit('CLIENT_SELL_ITEM_RESPONSE', sold);
        }
        catch (err) {
            output.giveError('Could not sell item: ', err);
        }
    });

    channel.on('CLIENT_INTERACT_PROPERTIES', function() {
        try {
            //Check if in-game

            if (!isInGame(true))
                return;

            //Shorten channel name

            let id = channel.name;

            //Get all properties that the player collided with

            let properties = tiled.getPropertiesWithRectangle(game.players[id].map_id, {
                x: game.players[id].pos.X,
                y: game.players[id].pos.Y,
                w: game.players[id].character.width,
                h: game.players[id].character.height
            });

            //Handle unique properties

            if (properties != undefined) {
                for (let p = 0; p < properties.length; p++)
                {
                    switch (properties[p].name) {
                    //Position X property

                    case 'positionX':
                        game.setPlayerTilePosition(
                            id,
                            game.players[id].map_id,
                            properties[p].value,
                            undefined
                        );
                        break;

                    //Position Y property

                    case 'positionY':
                        game.setPlayerTilePosition(
                            id,
                            game.players[id].map_id,
                            undefined,
                            properties[p].value
                        );
                        break;
                    }
                }
            }
        }
        catch (err) {
            output.giveError('Could not interact with properties: ', err);
        }
    });

    channel.on('CLIENT_DIALOG_EVENT', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) 
                || data == undefined
                || data.owner == undefined
                || data.type == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Get map index

            let map = game.players[id].map_id;

            //Setup variables

            let dialogEvent;

            //Check if NPC or item dialog

            switch (data.type)
            {
                case 'item':
                    //Item

                    dialogEvent = items.getItem(data.owner).dialog[data.id];

                    eventName =
                        data.owner.replace(' ', '') +       //Item name to make sure the event can occur
                                                            //with other items (it is called 'npc' but it is the item name)
                        dialogEvent.eventType +             //Event type for uniqueness
                        data.id;                            //Dialog ID for uniqueness
                    break;
                case 'npc':
                    //NPC

                    dialogEvent = npcs.onMap[map][data.owner].data.dialog[data.id];

                    eventName =
                        map.toString() +                    //Map to make sure the event can occur on other maps
                        npcs.onMap[map][data.owner].name +  //NPC name for uniqueness
                        dialogEvent.eventType +             //Event type for uniqueness
                        data.id;                            //Dialog ID for uniqueness
                    break;
                case 'map':
                    //Map

                    dialogEvent = tiled.maps_dialogs[map][data.owner].dialog[data.id];

                    eventName =
                        map.toString() +                    //Map to make sure the event can occur on other maps
                        data.owner +                        //Dialog name for uniqueness
                        dialogEvent.eventType +             //Event type for uniqueness
                        data.id;                            //Dialog ID for uniqueness
                    break;
                case 'quest':
                    //Quest

                    let questObjective = quests.getPlayerQuestObjective(id, data.quest);
                    if (questObjective.talkObjective == undefined)
                        return;
                    
                    dialogEvent = questObjective.talkObjective.dialog[data.id];

                    eventName = 
                        data.quest +                        //Quest name to make sure the event can occur with other quests
                        data.owner +                        //The current objective for uniqueness
                        dialogEvent.eventType +             //Event type for uniqueness
                        data.id;                            //Dialog ID for uniqueness
                    break;
            }

            //Check if valid

            if (dialogEvent == undefined ||
                !dialogEvent.isEvent)
                return;

            //Check if the event has already occured

            if (game.getPlayerGlobalVariable(id, eventName) &&
                !dialogEvent.repeatable) {
                //Respond with false (occurred)

                channel.emit('CLIENT_DIALOG_EVENT_RESPONSE', { result: false, id: data.id });

                return;
            }

            //Handle events

            dialog.handleEvents(id, channel, dialogEvent, data);
        }
        catch (err) {
            output.giveError('Could not handle dialog event: ', err);
        }
    });

    channel.on('CLIENT_ACCEPT_QUEST', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) 
                || data == undefined 
                || data.owner == undefined
                || data.type == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Check if NPC or item dialog

            let dialogEvent;

            switch (data.type)
            {
                case 'item':
                    dialogEvent = items.getItem(data.owner).dialog[data.id];
                    break;
                case 'npc':
                    dialogEvent = npcs.onMap[game.players[id].map_id][data.owner].data.dialog[data.id];
                    break;
                case 'map':
                    dialogEvent = tiled.maps_dialogs[map][data.owner].dialog[data.id];
                    break;
            }

            //Check if valid

            if (dialogEvent == undefined)
                return;

            //Check if dialog is a quest event

            if (dialogEvent.isEvent && dialogEvent.eventType === 'ShowQuest') {
                //Accept quest with name

                if (!quests.acceptQuest(id, dialogEvent.showQuestEvent.name))
                    return;

                //Respond

                channel.emit('CLIENT_ACCEPT_QUEST_RESPONSE', dialogEvent.showQuestEvent.name)
            }
        }
        catch (err) {
            output.giveError('Could not accept quest: ', err);
        }
    });

    channel.on('CLIENT_ABANDON_QUEST', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) || 
                data == undefined || 
                !isNaN(data))
                return;

            //Shorten channel name

            let id = channel.name;

            //Remove quest from player quests

            delete game.players[id].quests[data];

            //Respond

            channel.emit('CLIENT_ABANDON_QUEST_RESPONSE', data);
        }
        catch (err) {
            output.giveError('Could not abandon quest: ', err);
        }
    });

    channel.on('CLIENT_FINISH_QUEST', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) || data == undefined || !isNaN(data))
                return;

            //Try to finish quest

            quests.finishQuest(channel.name, data);
        }
        catch (err) {
            output.giveError('Could not finish quest: ', err);
        }
    });

    channel.on('CLIENT_BUY_ITEM', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) || data == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Get map index

            let map = game.players[id].map_id;

            //Check if player is on the same
            //map as the NPC, way too simple for now

            if (npcs.onMap[map][data.npc] == undefined)
                return;

            //Try to buy item

            let bought = shop.buyItem(
                id,
                data.item,
                data.npc, 
                data.id
            );

            //Respond if bought

            channel.emit('CLIENT_BUY_ITEM_RESPONSE', bought);
        }
        catch (err) {
            output.giveError('Could not buy shop item: ', err);
        }
    });

    channel.on('CLIENT_NPC_INTERACTION', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) || data == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Get map index

            let map = game.players[id].map_id;

            //If in "dialog" range, handle any
            //necessary interactions

            if (npcs.inDialogRange(map, data, game.players[id].pos.X, game.players[id].pos.Y)) {
                //Check for quest gather objective turn-in

                quests.evaluateQuestObjective(id, 'gather', npcs.onMap[map][data].name);
            }
        }
        catch (err) {
            output.giveError('Could not handle NPC interaction: ', err);
        }
    });

    channel.on('CLIENT_REQUEST_DIALOG', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) || data == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Get map index

            let map = game.players[id].map_id;

            //If in dialog range respond with the dialog

            if (npcs.inDialogRange(map, data, game.players[id].pos.X, game.players[id].pos.Y)) {
                //Check for quest gather objective turn-in

                quests.evaluateQuestObjective(id, 'gather', npcs.onMap[map][data].name);

                //Check if NPC should provide quest dialog, this method
                //otherwise returns the default dialog by the NPC

                let { npcDialog, questName } = quests.providesQuestDialog(id, map, data);

                //Send dialog response (with uniquely created dialog)

                channel.emit('CLIENT_REQUEST_DIALOG_RESPONSE', {
                    npc: data,
                    quest: questName,
                    dialog: dialog.createUnique(id, npcDialog)
                });
            }
        }
        catch (err) {
            output.giveError('Could not handle dialog request: ', err);
        }
    });

    channel.on('CLIENT_REQUEST_MAP_DIALOG', function(data) {
        try {
            //Check if in-game and data is valid

            if (!isInGame(true) || data == undefined)
                return;

            //Shorten channel name

            let id = channel.name;

            //Get map index

            let map = game.players[id].map_id;

            //Check if map has the corresponding dialog

            if (tiled.maps_dialogs[map][data] == undefined)
                return;

            //If in dialog range respond with the dialog

            if (tiled.inDialogRange(id, map, data))
                channel.emit('CLIENT_REQUEST_MAP_DIALOG_RESPONSE', {
                    name: data,
                    title: tiled.maps_dialogs[map][data].title,
                    dialog: dialog.createUnique(
                        id, 
                        tiled.maps_dialogs[map][data].dialog
                    )
                });  
        }
        catch (err) {
            output.giveError('Could not handle map dialog request: ', err);
        }
    });

    channel.on('CLIENT_REQUEST_EXP', function() {
        //Check if in-game

        if (!isInGame())
            return;

        //Shorten channel name

        let id = channel.name;

        //Respond with current target xp

        channel.emit('CLIENT_REQUEST_EXP_RESPONSE', exptable[game.players[id].level-1]);
    });

    channel.on('CLIENT_INCREMENT_ATTRIBUTE', function(data) {
        //Check if in-game and data is valid

        if (!isInGame(true) || data == undefined)
            return;

        //Shorten channel name

        let id = channel.name;

        //Increment attribute

        game.incrementPlayerAttribute(id, data);
    });

    channel.on('CLIENT_USER_SETTINGS', function(settings) {
        //Check if in-game and data is valid

        if (!isInGame() || 
            settings == undefined || 
            settings.audio == undefined)
            return;

        //Check and/or format data to make sure
        //players can't save invalid data

        if (settings.audio.main == undefined || isNaN(settings.audio.main) || settings.audio.main < 0 || settings.audio.main > 100)
            settings.audio.main = 100;
        if (settings.audio.music == undefined || isNaN(settings.audio.music) || settings.audio.music < 0 || settings.audio.music > 100)
            settings.music = 100;
        if (settings.audio.sound == undefined || isNaN(settings.audio.sound) || settings.audio.sound < 0 || settings.audio.sound > 100)
            settings.audio.sound = 100;

        //Save user settings

        game.saveUserSettings(channel.name, {
            audio: {
                main: settings.audio.main,
                sound: settings.audio.sound,
                music: settings.audio.music
            }
        });
    });

    channel.on('CLIENT_INVITE_TO_PARTY', function(participant_name) {
        //Check if in-game and data is valid

        if (!isInGame() || participant_name == undefined)
            return;

        //Invite player to party

        parties.invitePlayer(channel.name, participant_name);
    });

    channel.on('CLIENT_JOIN_PARTY', function() {
        //Check if in-game

        if (!isInGame())
            return;

        //Join party

        parties.joinParty(channel.name);
    });

    channel.on('CLIENT_LEAVE_PARTY', function(reason) {
        //Check if in-game and data is valid

        if (!isInGame() || reason == undefined)
            return;

        //Leave party

        parties.leaveParty(channel.name, reason);
    });

    channel.on('CLIENT_BANK_REMOVE_ITEM', function(item) {
        //Check if in-game

        if (!isInGame(true))
            return;

        //Shorten channel name

        let id = channel.name;

        //Check if player has inventory space available

        let slot = items.getPlayerFreeSlot(id);

        //Check if slot is valid

        if (slot === -1)
            return;

        //Remove item from player bank

        banks.removeItem(id, item, function(success, bank) {
            if (!success)
                return;

            //Give item to player

            items.addPlayerItem(id, item);

            //Send new bank

            channel.emit('GAME_BANK_UPDATE', bank);
        });
    });

    channel.on('CLIENT_BANK_ADD_ITEM', function(item) {
        //Check if in-game

        if (!isInGame(true))
            return;

        //Shorten channel name

        let id = channel.name;

        //Check if player has the item

        if (!items.hasPlayerItem(id, item))
            return;

        //Add item to bank

        banks.addItem(id, item, function(success, bank) {
            if (!success)
                return;

            //Remove item from inventory

            items.removePlayerItem(id, item);

            //Send new bank

            channel.emit('GAME_BANK_UPDATE', bank);
        });
    });

    channel.on('CLIENT_REQUEST_ALIASES', function() {
        //Respond with current target xp

        channel.emit('CLIENT_REQUEST_ALIASES_RESPONSE', gameplay.aliases);
    });
};

//Sync/send chat message function, if channel is undefined it will be globally emitted

exports.syncChatMessage = function(message, channel, broadcast)
{
    if (channel === undefined)
        io.emit('GAME_CHAT_UPDATE', message);
    else {
        if (broadcast === undefined || !broadcast) 
            channel.emit('GAME_CHAT_UPDATE', message);
        else
            channel.broadcast.emit('GAME_CHAT_UPDATE', message);
    }
};

//Sync player partially function, if channel is undefined it will be globally emitted

exports.syncPlayerPartially = function(id, type, channel, broadcast)
{
    let data = {
        name: id
    };

    switch (type)
    {
        case 'position':
            data.pos = game.players[id].pos;
            break;
        case 'moving':
            data.moving = game.players[id].moving;
            break;
        case 'direction':
            data.direction = game.players[id].direction;
            break;
        case 'character':
            data.character = game.players[id].character;
            break;
        case 'level':
            data.level = game.players[id].level;
            break;
        case 'exp':
            data.exp = game.players[id].stats.exp;
            break;
        case 'points':
            data.points = game.players[id].stats.points;
            break;
        case 'attributes':
            data.attributes = game.players[id].attributes;
            break;
        case 'currency':
            data.currency = game.players[id].currency;
            break;
        case 'health':
            data.health = game.players[id].health;
            break;
        case 'mana':
            data.mana = game.players[id].mana;
            break;
        case 'quests':
            data.quests = game.players[id].quests;
            break;
        case 'actions':
            data.actions = [];

            for (let a = 0; a < game.players[id].actions.length; a++) {
                if (game.players[id].actions[a] == undefined)
                    continue;

                if (combat.getAction(game.players[id].actions[a].name) != undefined)
                    data.actions[a] = combat.createPlayerSlotAction(game.players[id].actions[a]);
            }
            break;
        case 'statusEffects':
            data.statusEffects = game.players[id].statusEffects;
            break;
        case 'equipment':
            data.equipment = {};

            for (let equipment in game.players[id].equipment) {
                let item = items.getItem(game.players[id].equipment[equipment]);

                if (item == undefined || item.equippableSource.length === 0)
                    continue;

                data.equipment[equipment] = item.equippableSource;
            }

            break;
    }

    if (channel === undefined)
        io.room(game.players[id].map_id).emit('GAME_PLAYER_UPDATE', data);
    else {
        if (broadcast === undefined || !broadcast) {
            if (channel.name === data.name)
                data.isPlayer = true;

            channel.emit('GAME_PLAYER_UPDATE', data);
        }
        else
            channel.broadcast.emit('GAME_PLAYER_UPDATE', data);
    }
};

//Sync whole player function, if channel is undefined it will be globally emitted

exports.syncPlayer = function(id, channel, broadcast)
{
    this.syncPlayerPartially(id, 'moving', channel, broadcast);
    this.syncPlayerPartially(id, 'position', channel, broadcast);
    this.syncPlayerPartially(id, 'direction', channel, broadcast);
    this.syncPlayerPartially(id, 'character', channel, broadcast);
    this.syncPlayerPartially(id, 'equipment', channel, broadcast);
    this.syncPlayerPartially(id, 'statusEffects', channel, broadcast);
    this.syncPlayerPartially(id, 'level', channel, broadcast);
    this.syncPlayerPartially(id, 'health', channel, broadcast);
    this.syncPlayerPartially(id, 'mana', channel, broadcast);
};

//Sync player remove function, will be broadcast by default

exports.removePlayer = function(channel, leaveRoom)
{
    //Check if valid

    if (channel === undefined || 
        channel.name === undefined ||
        !channel.playing)
        return;

    //Broadcast player removal

    channel.broadcast.emit('GAME_PLAYER_UPDATE', { name: channel.name, remove: true });

    //Leave room and decrement map popularity
    //if necessary

    if (leaveRoom) {
        npcs.mapPopulation[channel._roomId]--;

        rooms.leave(channel);
    }
}

//Sync NPC partially function, if channel is undefined it will be globally emitted

exports.syncNPCPartially = function(map, id, type, channel)
{
    //Check if NPC is valid

    if (npcs.onMap[map] === undefined || npcs.onMap[map][id] === undefined)
        return;

    //If channel is specified, check if the 
    //NPC is invisible for this player

    if (channel != undefined && npcs.isInvisible(channel.name, id))
        return;

    //Setup data

    let data = {
        id: id,
        name: npcs.onMap[map][id].data.name
    };

    //Get specific data type

    switch (type)
    {
        case 'position':
            data.pos = {
                X: Math.round(npcs.onMap[map][id].pos.X),
                Y: Math.round(npcs.onMap[map][id].pos.Y)
            };
            break;
        case 'moving':
            data.moving = npcs.onMap[map][id].moving;
            break;
        case 'direction':
            data.direction = npcs.onMap[map][id].direction;
            break;
        case 'character':
            data.character = npcs.onMap[map][id].data.character;
            break;
        case 'type':
            data.type = npcs.onMap[map][id].data.type;
            data.hasDialog = !(npcs.onMap[map][id].data.dialog != undefined && npcs.onMap[map][id].data.dialog.length == 0);
            break;
        case 'stats':
            data.stats = npcs.onMap[map][id].data.stats;
            break;
        case 'statusEffects':
            data.statusEffects = npcs.onMap[map][id].statusEffects;
            break;
        case 'health':
            data.health = npcs.onMap[map][id].data.health;
            break;
        case 'equipment':
            data.equipment = npcs.onMap[map][id].data.equipment;
            break;
        case 'aggressive':
            data.aggressive = npcs.onMap[map][id].data.aggressive;
            break;
        case 'inCombat':
            data.inCombat = (npcs.onMap[map][id].target !== -1);
            break;
        case 'showNameplate':
            data.showNameplate = npcs.onMap[map][id].data.showNameplate;
            break;
    }

    //Emit

    if (channel === undefined) {
        //Custom room emission method,
        //make sure players that have the
        //NPC set to invisible - don't
        //recieve any packages

        const room = rooms.get(map);

        for (let player in room) {
            if (!npcs.isInvisible(player, id))
                room[player].emit('GAME_NPC_UPDATE', data);
        }
    }
    else 
        channel.emit('GAME_NPC_UPDATE', data);
}

//Sync whole NPC function, if channel is undefined it will be globally emitted

exports.syncNPC = function(map, id, channel)
{
    this.syncNPCPartially(map, id, 'moving', channel);
    this.syncNPCPartially(map, id, 'position', channel);
    this.syncNPCPartially(map, id, 'direction', channel);
    this.syncNPCPartially(map, id, 'character', channel);
    this.syncNPCPartially(map, id, 'equipment', channel);
    this.syncNPCPartially(map, id, 'type', channel);
    this.syncNPCPartially(map, id, 'aggressive', channel);
    this.syncNPCPartially(map, id, 'inCombat', channel);
    this.syncNPCPartially(map, id, 'showNameplate', channel);

    //Some NPCs don't have stats, so we dont send it if
    //it is empty. Otherwise send stats and other combat
    //related data.

    if (npcs.onMap[map][id].data.stats !== undefined &&
        npcs.onMap[map][id].data.stats !== null) {
        this.syncNPCPartially(map, id, 'stats', channel);
        this.syncNPCPartially(map, id, 'statusEffects', channel);
        this.syncNPCPartially(map, id, 'health', channel);
    }
};

//Remove NPC function, if channel is undefined it will be globally emitted

exports.removeNPC = function(map, id, channel)
{
    let data = {
        id: id,
        remove: true
    };

    if (channel === undefined)
        io.room(map).emit('GAME_NPC_UPDATE', data);
    else 
        channel.emit('GAME_NPC_UPDATE', data);
};

//Sync player action casting function, if channel is undefined it will be globally emitted

exports.syncPlayerActionCast = function(slot, id, channel, broadcast)
{
    //Get the action

    let action =combat.getAction(game.players[id].actions[slot].name);

    //Get casting time and adjust based on
    //status effects matrix

    let castingTime = action.castingTime;
    castingTime *= game.players[id].statusEffectsMatrix['castingTimeFactor'];

    //Check if casting time is immediate

    if (castingTime === 0)
        return;

    //Setup base data

    let data = {
        player: id,
        beginTime: Date.now()
    };

    //Set data based on syncing type

    if (channel === undefined || broadcast) {
        data.targetTime = castingTime;
        data.icon       = action.src;
    }
    else
        data.slot = slot;

    //Sync

    if (channel === undefined)
        io.room(game.players[id].map_id).emit('GAME_OTHER_PLAYER_CAST_ACTION', data);
    else {
        if (broadcast === undefined || !broadcast)
            channel.emit('GAME_PLAYER_CAST_ACTION', data);
        else
            channel.broadcast.emit('GAME_OTHER_PLAYER_CAST_ACTION', data);
    }
};

//Sync player cancel casting function, if channel is undefined it will be globally emitted

exports.syncPlayerCancelCast = function(id, channel, broadcast) 
{
    if (channel === undefined)
        io.room(game.players[id].map_id).emit('GAME_OTHER_PLAYER_CANCELLED_CAST', id);
    else {
        if (broadcast === undefined || !broadcast)
            channel.emit('GAME_OTHER_PLAYER_CANCELLED_CAST', id);
        else
            channel.broadcast.emit('GAME_OTHER_PLAYER_CANCELLED_CAST', id);
    }
};

//Sync single action slot (for specific player) function

exports.syncPlayerActionSlot = function(slot, id, channel)
{
    let data = {
        slot: slot
    };

    if (game.players[id].actions[slot] != undefined)
    {
        data.action = combat.createPlayerSlotAction(game.players[id].actions[slot]);

        if (data.action === undefined) {
            data.remove = true;
            delete data.slot;
        }
    }
    else
        data.remove = true;

    channel.emit('GAME_ACTION_SLOT_UPDATE', data);
};

//Sync whole inventory item (for specific player) function

exports.syncPlayerInventory = function(id, channel)
{
    for (let i = 0; i < game.players[id].inventory.length; i++)
        if (game.players[id].inventory[i] != undefined)
            server.syncPlayerInventoryItem(i, id, channel, false);
};

//Sync single inventory item (for specific player) function

exports.syncPlayerInventoryItem = function(slot, id, channel)
{
    let data = {
        slot: slot
    };

    if (game.players[id].inventory[slot] !== undefined)
    {
        data.item = items.getConvertedItem(game.players[id].inventory[slot]);

        if (data.item === undefined) {
            data.remove = true;
            delete data.item;
        }
    }
    else
        data.remove = true;

    channel.emit('GAME_INVENTORY_SLOT_UPDATE', data);
};

exports.syncPlayerEquipment = function(id, channel)
{
    for (let equipment in game.players[id].equipment)
        if (equipment != undefined)
            server.syncPlayerEquipmentItem(equipment, id, channel);
};

//Sync single equipment item function, if channel is undefined it will be globally emitted

exports.syncPlayerEquipmentItem = function(equippable, id, channel)
{
    let data;

    if (game.players[id].equipment[equippable] !== undefined) {
        data = items.getConvertedItem(game.players[id].equipment[equippable]);

        if (data === undefined)
            data = {
                equippable: equippable,
                remove: true
            };
    } else
        data = {
            equippable: equippable,
            remove: true
        };

    channel.emit('GAME_EQUIPMENT_SLOT_UPDATE', data);
};

//Sync NPC action casting function, if channel is undefined it will be globally emitted

exports.syncNPCActionCast = function(map, id, icon, targetTime, channel, broadcast)
{
    //Check if casting time is immediate

    if (targetTime === 0)
        return;

    //Setup data

    const data = {
        npc: id,
        targetTime: targetTime,
        icon: icon,
        beginTime: Date.now()
    };
    
    //Sync

    if (channel === undefined)
        io.room(map).emit('GAME_NPC_CAST_ACTION', data);
    else {
        if (broadcast === undefined || !broadcast)
            channel.emit('GAME_NPC_CAST_ACTION', data);
        else
            channel.broadcast.emit('GAME_NPC_CAST_ACTION', data);
    }
};

//Sync whole action function, if channel is undefined it will be globally emitted

exports.syncActionElement = function(actionData, actionElement, channel, broadcast)
{
    //Trim data by creating custom data structure

    const data = {
        pos: actionData.pos,
        map: actionData.map,
        element: actionElement,
        ownerType: actionData.ownerType,
        owner: actionData.owner,
        sounds: actionData.sounds,
        centerPosition: actionData.centerPosition
    };

    if (channel === undefined)
        io.room(data.map).emit('GAME_ACTION_UPDATE', data);
    else {
        if (broadcast === undefined || !broadcast)
            channel.emit('GAME_ACTION_UPDATE', data);
        else
            channel.broadcast.emit('GAME_ACTION_UPDATE', data);
    }
};

//Remove Action function, if channel is undefined it will be globally emitted

exports.removeActionElement = function(id, map, channel, broadcast)
{
    let data = {
        remove: true,
        id: id
    };

    if (channel === undefined)
        io.room(map).emit('GAME_ACTION_UPDATE', data);
    else {
        if (broadcast === undefined || !broadcast)
            channel.emit('GAME_ACTION_UPDATE', data);
        else
            channel.broadcast.emit('GAME_ACTION_UPDATE', data);
    }
};

//Sync single item function, if channel is undefined it will be globally emitted

exports.syncItem = function(map, data, channel, broadcast)
{
    if (channel === undefined)
        io.room(map).emit('GAME_WORLD_ITEM_UPDATE', data);
    else {
        if (broadcast === undefined || !broadcast)
            channel.emit('GAME_WORLD_ITEM_UPDATE', data);
        else
            channel.broadcast.emit('GAME_WORLD_ITEM_UPDATE', data);
    }
};

//Sync item dialog to client, which immediately opens up the dialog on the clientside

exports.syncItemDialog = function(id, itemName, dialogData)
{
    let data = {
        dialog: dialog.createUnique(id, dialogData),
        name: itemName
    };

    game.players[id].channel.emit('GAME_START_ITEM_DIALOG', data);
};

//Sync game time function, if channel is undefined it will be globally emitted

exports.syncGameTime = function(channel)
{
    let time = {
        dayLength: gameplay.dayLength,
        nightLength: gameplay.nightLength,
        current: game.time.current
    };
    
    if (channel === undefined)
        io.emit('GAME_SERVER_TIME', time);
    else
        channel.emit('GAME_SERVER_TIME', time);
};
