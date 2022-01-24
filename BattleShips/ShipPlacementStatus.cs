using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public enum ShipPlacementStatus
    {
        OK,
        ShipOutOfBoard,
        ShipCollision,
        NotPlaced,
        ShipsPlaced
    }
}
