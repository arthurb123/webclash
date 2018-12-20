const client = {
    ingame: false,
    connect: function(cb) {
        //Try to make a connection
        
        window['socket'] = io.connect(properties.address + ":" + properties.port);
        
        //Setup possible server requests
        
        this.setup();
        
        //Callback
        
        cb();
    },
    joinGame: function() {
        if (this.ingame)
            return;
        
        socket.emit('CLIENT_JOIN_GAME');
        
        this.ingame = true;
    },
    setup: function() {
        socket.on('UPDATE_CLIENT_NAME', function(t) { document.title = t; });
        
        socket.on('REQUEST_LANDING', view.loadLanding);
        socket.on('REQUEST_GAME', view.loadGame);
        
        socket.on('GAME_PLAYER_UPDATE', function (data) {
             //Check if the recieved data is valid
            
             if (data === undefined || data.name === undefined)
                 return;
            
             //Get the id of the player's data
            
             let id = game.getPlayerIndex(data.name);
            
             //If the player does not yet exist, create it
            
             if (id == -1 && data.isPlayer) {
                 game.instantiatePlayer();
                 
                 id = game.player;
             }
             else if (id == -1) {
                 game.instantiateOther();
                 
                 id = game.players.length-1;
             }
            
             //Check what data is present
            
             if (data.pos !== undefined) 
                 game.players[id].POS = data.pos;
             if (data.movement !== undefined) 
                 game.players[id].Movement(data.movement.VX, data.movement.VY);
             if (data.direction !== undefined) 
                 game.players[id]._direction = data.direction;
             if (data.src !== undefined) 
                 game.players[id].SPRITE = new lx.Sprite(data.src);
        });
    }
}