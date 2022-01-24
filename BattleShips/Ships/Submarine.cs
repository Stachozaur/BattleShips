using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Ships
{
    public class Submarine : Ship
    {
        public override int HealthPoints => 1;
        public override int Size => 1;
        public override string Symbol => "S";
    }
}

