using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class UI
    {
        //console writeline, inputs methods
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void PrintBoard(string[,] board)
        {

            Console.WriteLine("   1   2   3   4   5   6   7   8   9   10");
            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.Write(NumberToTextASCII(row) + "| ");
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
        public static char NumberToTextASCII(int number)
        {
            char text = Convert.ToChar(number + 65);
            return text;
        }

        public static int TextToNumberASCII(char text)
        {
            int number = Convert.ToInt32(text) - 65;
            return number;
        }

        public static Coordinates GetShipCoordinate(string playerName)
        {
            //get coordinates
            //cell for each coordinate

            PrintMessage($"{playerName}, Please enter starting coordinates of your ship (example: 'A3'): ");

            string input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                bool isLetter = char.IsLetter(input[0]);

                char inputRow = char.ToUpper(input[0]);
                int row = TextToNumberASCII(inputRow);
                bool isNumber = int.TryParse(input.Substring(1, input.Length - 1), out int col);

                if (isLetter && isNumber)
                {
                    var shootCoordinates = new Coordinates(row, col - 1);
                    return shootCoordinates;
                }
            }
            return GetShipCoordinate(playerName);

        }

        public static Orientation GetShipOrientation()
        {
            PrintMessage("Please enter ship orientation ('V' for vertical, 'H' for horizontal): ");
            char input = Convert.ToChar(Console.ReadLine().ToUpper());

            if (input == 'V' ^ input == 'H')
            {
                if (input == 'V')
                {
                    return Orientation.Vertical;
                }
                else if (input == 'H')
                {
                    return Orientation.Horizontal;
                }
            }
            else
            {
                PrintMessage("Please, give the correct direction");
                return GetShipOrientation();
            }
            PrintMessage("Please Enter 'H' or 'V'");
            return GetShipOrientation();
        }
        public static string GetPlayerName()
        {
            PrintMessage("Please type your name");
            string input = Console.ReadLine();
            return input;
        }

        public static Coordinates GetShootCoordinate()
        {
            PrintMessage($"Please enter your shoot coordinates (example: 'A3'): ");

            string input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                bool isLetter = char.IsLetter(input[0]);

                char inputRow = char.ToUpper(input[0]);
                int row = TextToNumberASCII(inputRow);
                bool isNumber = int.TryParse(input.Substring(1, input.Length - 1), out int col);

                if (isLetter && isNumber)
                {
                    var shootCoordinates = new Coordinates(row, col - 1);
                    return shootCoordinates;
                }
            }
            return GetShootCoordinate();
        }

        public static void WelcomeMessage()
        {
            PrintMessage("Welcome to battleships game. Put your ships on the map, and destroy your enemy fleet.");
            PrintMessage("You got 2 submarines, 2 destroyers, one cruiser and one battleship. Good luck!");
            Console.WriteLine();
        }
    }
}
