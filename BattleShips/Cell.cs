using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class Cell
    {
        private Coordinates _coordinates;

        public int X => _coordinates.X;
        public int Y => _coordinates.Y;
        private bool _isHit;
        public Cell(Coordinates coordinates)
        {
            _coordinates = coordinates;
        }
        public bool IsHit(Coordinates coordinates)
        {
            if (_coordinates.X == coordinates.X && _coordinates.Y == coordinates.Y)
            {
                _isHit = true;
                return true;
            }
            return false;
        }

        /// this method check if cell is  available in range :
        /// (-1,-1) (-1,0), (-1,1),
        /// (0,-1) (0,0) (0,+1),
        /// (+1,-1) (+1,0) (+1, +1)

        public bool IsNotOverlapping(Cell cell)
        {

            var resultX = Math.Abs(this.GetX() - cell.GetX());
            var resultY = Math.Abs(this.GetY() - cell.GetY());

            //if (resultX > 1 && resultY > 1 || resultX > 1 && resultY <= 1 || resultX <= 1 && resultY > 1)
            if (resultX > 1 || resultY > 1)
            {
                return true;
            }

            return false;
        }

        public bool CellInBoard(Cell cell)
        {
            if (cell._coordinates.X >= 0 && cell._coordinates.Y >= 0 && cell._coordinates.X < 10 && cell._coordinates.Y < 10)
            {
                return true;
            }
            return false;
        }
        public bool GetHitStatus()
        {
            return _isHit;
        }
        public int GetX()
        {
            return _coordinates.X;
        }
        public int GetY()
        {
            return _coordinates.Y;
        }


    }
}
