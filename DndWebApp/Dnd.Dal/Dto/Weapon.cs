using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnd.Dal.Dto
{
    public class Weapon
    {
        public string Name { get; set; }
        public int? AtkBonus { get; set; }
        public int? Dmg { get; set; }
        public string Type { get; set; }
    }
}
