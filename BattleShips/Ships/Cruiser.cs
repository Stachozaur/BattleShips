using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Ships
{
    public class Cruiser : Ship
    {
        public override int HealthPoints => 3;
        public override int Size => 3;
        public override string Symbol => "C";
    }
}
