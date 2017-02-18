var rounds = (function () {
    return {
        debugEnabled: true,
        players: [],

        initializePlay: initializePlay,
        removePlayer: removePlayer
    };

    function initializePlay() {
        /* Add new player */
        $('#player-select').on('change', addNewPlayer);
    }

    function addNewPlayer(e) {
        $("option:selected", this).attr('disabled', 'disabled')
        var name = $("option:selected", this).text();
        var id = this.value;

        rounds.players.push({ "id": id, "name": name });
        $("#player-select").val("0");
        refreshCurrentPlayers();
    }

    function removePlayer(id) {
        for (var i = 0; i < rounds.players.length; i++) {
            var player = rounds.players[i];
            if (player.id == id) {
                rounds.players.splice(i, 1);
                $('.player-option[value="' + id + '"]').attr('disabled', null);
            }
        }
        refreshCurrentPlayers();
    }

    function refreshCurrentPlayers() {
        for (var i = 0; i < rounds.players.length; i++) {
            var player = rounds.players[i];
            if ($('#' + player.id + '.player').length == 0) {
                $('#player-list').append(getPlayerLi(player));
            }
        }

        $('.player').each(function () {
            var id = $(this).attr('id');
            var found = false;
            for (var i = 0; i < rounds.players.length; i++) {
                var player = rounds.players[i];
                if (player.id == id) { found = true; }
            }
            if (!found) this.remove();
        });

        writeDebug(JSON.stringify(rounds.players));
    }

    function getPlayerLi(player) {
        return '<tr id="' + player.id + '" class="player">'
        + '<td class="player-name">' + player.name + '</td>'
        + '<td class="player-remove"><span class="delete-player glyphicon glyphicon-trash" onclick="rounds.removePlayer(' + player.id + ')"></span></td>'
        + '</tr>';
    }

    function writeDebug(message) {
        if (rounds.debugEnabled) {
            console.log("Rounds | " + message);
        }
    } 
})();

$(document).ready(function () {
    rounds.initializePlay();
});