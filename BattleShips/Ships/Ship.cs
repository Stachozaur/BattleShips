using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Ships
{
    public abstract class Ship
    {
        public abstract int HealthPoints { get; }
        public abstract int Size { get; }
        public abstract string Symbol { get; }
        public List<Cell> ShipParts { get; set; }
        private bool _isShipInBoard { get; set; }
        private bool _isSunk;

        public Ship()
        {
            ShipParts = new List<Cell>();
        }
        public bool IsHit(Coordinates coordinates)
        {
            foreach (var cell in ShipParts)
            {
                if (cell.IsHit(coordinates))
                {
                    return true;

                }
            }
            return false;
        }

        public bool IsSunk()
        {
            foreach (var cell in ShipParts)
            {
                if (cell.GetHitStatus())
                {
                    _isSunk = true;
                    return _isSunk;
                }
            }
            return _isSunk;
        }

        public bool IsCollision(Ship newShip)
        {
            foreach (var newShipCell in newShip.ShipParts)
            {
                foreach (var cell in ShipParts)
                {
                    if (!cell.IsNotOverlapping(newShipCell))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsShipInBoard(Ship newShip)
        {
            foreach (var newShipCell in newShip.ShipParts)
            {
                if (newShipCell.CellInBoard(newShipCell))
                {
                    _isShipInBoard = true;  
                }
                _isShipInBoard = false;
            }
            return _isShipInBoard;
        }
    }
}
