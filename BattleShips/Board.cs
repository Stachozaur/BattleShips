using BattleShips.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class Board
    {
        private List<Ship> _shipsList;
        private List<Cell> _missedCellsList;
        private int _width = 10;
        private int _height = 10;

        public Board()
        {
            _missedCellsList = new List<Cell>();
            _shipsList = new List<Ship>();
            CreateFullBoard();
        }

        public string[,] CreateFullBoard()
        {
            string[,] fullBoard = new string[_width, _height];

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    fullBoard[i, j] = " ";
                }
            }
            foreach (var cell in _missedCellsList)
            {
                if (cell.GetHitStatus())
                {
                    fullBoard[cell.GetX(), cell.GetY()] = "X";
                }
                fullBoard[cell.GetX(), cell.GetY()] = ".";
            }

            foreach (var ship in _shipsList)
            {
                foreach (var shipCell in ship.ShipParts)
                {
                    if (shipCell.GetHitStatus())
                    {
                        fullBoard[shipCell.GetX(), shipCell.GetY()] = "*";
                    }
                    else
                    {
                        fullBoard[shipCell.GetX(), shipCell.GetY()] = ship.Symbol;
                    }

                }
            }

            return fullBoard;
        }

        public string[,] CreateShadowBoard()
        {
            string[,] shadowBoard = new string[_width, _height];

            //shadowBoard = missedList.Select(x => [x.GetX(),x.GetY()] = ".");░

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    shadowBoard[i, j] = "░";
                }
            }

            foreach (var miss in _missedCellsList)
            {
                shadowBoard[miss.GetX(), miss.GetY()] = ".";

            }
            foreach (var ship in _shipsList)
            {
                foreach (var cell in ship.ShipParts)
                {
                    if (cell.GetHitStatus())
                    {
                        shadowBoard[cell.GetX(), cell.GetY()] = ship.Symbol;
                    }
                }
            }

            return shadowBoard;
        }
        private ShipPlacementStatus ShipCoordinatesOk(Ship newShip)
        {
            if (_shipsList.Count == 0)
            {
                return ShipPlacementStatus.OK;
            }
            foreach (var ship in _shipsList)
            {
                if (ship.IsCollision(newShip))
                {
                    return ShipPlacementStatus.ShipCollision;
                }
            }
            return ShipPlacementStatus.OK;
        }
        public ShipPlacementStatus PlaceShip(Ship ship)
        {
            var shipPlacementResult = ShipCoordinatesOk(ship);

            if (shipPlacementResult == ShipPlacementStatus.OK)
            {
                _shipsList.Add(ship);
            }
            return shipPlacementResult;
        }

        public bool ReceiveShot(Coordinates coordinates)
        {
            foreach (var ship in _shipsList)
            {
                if (ship.IsHit(coordinates))
                {

                    return true;
                }
            }
            _missedCellsList.Add(CreateMissCell(coordinates));
            return false;
        }
        private Cell CreateMissCell(Coordinates coordinates)
        {
            var newMissedCell = new Cell(coordinates);

            return newMissedCell;
        }

        public Ship CreateShipObject(ShipTypes type) => type switch
        {
            ShipTypes.Battleship => new Battleship(),
            ShipTypes.Submarine => new Submarine(),
            ShipTypes.Cruiser => new Cruiser(),
            ShipTypes.Destroyer => new Destroyer(),
            _ => throw new ArgumentOutOfRangeException()
        };

        public Ship CreateShip(ShipTypes type, Coordinates coordinates, Orientation orientation)
        {
            var ship = CreateShipObject(type);
            if (orientation == Orientation.Horizontal)
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    var newCoordinates = new Coordinates(coordinates.X, coordinates.Y + i);
                    var newShipCell = new Cell(newCoordinates);
                    ship.ShipParts.Add(newShipCell);
                }
            }
            else if (orientation == Orientation.Vertical)
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    var newCoordinates = new Coordinates(coordinates.X + i, coordinates.Y);
                    var newShipCell = new Cell(newCoordinates);
                    ship.ShipParts.Add(newShipCell);
                }
            }
            return ship;
        }

        public Coordinates Shoot()
        {
            var target = UI.GetShootCoordinate();
            bool inRange = CoordinatesInRange(target);

            while (!inRange)
            {
                UI.PrintMessage("Type correct coords!");
                target = UI.GetShootCoordinate();
                inRange = CoordinatesInRange(target);
            }
            return target;
        }

        public bool HasLost()
        {
            foreach (var ship in _shipsList)
            {
                foreach (var cell in ship.ShipParts)
                {
                    if (cell.GetHitStatus() == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static bool CoordinatesInRange(Coordinates coordinates)
        {
            if (coordinates.X >= 0 & coordinates.X < 10 & coordinates.Y >=0 & coordinates.Y < 10)
            {
                return true;
            }
            return false;
        }

    }
}
