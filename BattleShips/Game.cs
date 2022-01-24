using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class Game
    {
        private bool IsOver;
        public Game()
        {
            var playersTurn = InitializeGame.InitializePlayers();

            while (!IsOver)
            {
                while (playersTurn.Count > 0)
                {
                    var currentPlayer = playersTurn.Dequeue();
                    var nextPlayer = playersTurn.Peek();
                    playersTurn.Enqueue(currentPlayer);

                    Console.WriteLine($"{currentPlayer.Name} turn");

                    nextPlayer.DisplayShadowBoard();
                    Console.WriteLine();
                    currentPlayer.DisplayFullBoard();

                    //Ask player for the input and other player receives shot
                    var target = currentPlayer.Shoot();
                    nextPlayer.ReceiveShot(target);
                    Console.Clear();

                    //ask board of attacked player for the list of ships, if that list is empty the player hast lost and print Name of current Player
                    if (nextPlayer.HasLost())
                    {
                        UI.PrintMessage("You won");
                        playersTurn.Clear();
                        IsOver = true;
                    }
                }
            }

        }
    }
}
