using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class Player
    {
        private Board _board;
        public string Name { get; set; }
        private List<ShipTypes> _shipTypesList = new List<ShipTypes>() { ShipTypes.Submarine, ShipTypes.Cruiser };

        public Player()
        {
            _board = new Board();
        }

        public bool ReceiveShot(Coordinates coordinates)
        {
            return _board.ReceiveShot(coordinates);
        }

        public Coordinates GetCoordinate()
        {
            var coordinate = UI.GetShipCoordinate(Name);
            return coordinate;
        }

        public Orientation GetOrientation()
        {
            var orientation = UI.GetShipOrientation();
            return orientation;
        }

        public void PlaceAllShips()
        {
            Name = UI.GetPlayerName();

            foreach (var ship in _shipTypesList)
            {
                ShipPlacementStatus shipPlacementStatus = ShipPlacementStatus.NotPlaced;
                do
                {
                    var shipCoordinates = GetCoordinate();
                    var shipOrientation = GetOrientation();
                    var newShip = _board.CreateShip(ship, shipCoordinates, shipOrientation);
                    if (_board.PlaceShip(newShip) == ShipPlacementStatus.OK)
                    {
                        DisplayFullBoard();
                        break;
                    }
                    UI.PrintMessage($"{Name}! Come on! I need correct coordinates :)");
                }
                while (shipPlacementStatus != ShipPlacementStatus.OK);
            }
        }
        public void DisplayFullBoard()
        {
            var fullBoard = _board.CreateFullBoard();
            UI.PrintBoard(fullBoard);
        }

        public void DisplayShadowBoard()
        {
            var shadowBoard = _board.CreateShadowBoard();
            UI.PrintBoard(shadowBoard);
        }

        public Coordinates Shoot()
        {
            return _board.Shoot();
        }

        public bool HasLost()
        {
            return _board.HasLost();
        }
    }
}
