using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Ships
{
    public class Battleship : Ship
    {
        public override int HealthPoints => 4;
        public override int Size => 4;
        public override string Symbol => "B";
    }

}
