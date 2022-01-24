using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public static class InitializeGame
    {
        public static Queue<Player> InitializePlayers()
        {
            Queue<Player> playersTurn = new Queue<Player>();
            var players = 2;
            for (int i = 0; i < players; i++)
            {
                var player = new Player();
                player.PlaceAllShips();
                playersTurn.Enqueue(player);
            }

            return playersTurn;
        }

    }
}
