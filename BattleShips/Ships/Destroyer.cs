using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Ships
{
    public class Destroyer : Ship
    {
        public override int HealthPoints => 2;
        public override int Size => 2;
        public override string Symbol => "D";
    }

}
