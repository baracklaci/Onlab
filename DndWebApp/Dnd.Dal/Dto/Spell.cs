using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnd.Dal.Dto
{
    public class Spell
    {
        public string Name { get; set; }
        public int? Level { get; set; }
        public string School { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string HigherLevels { get; set; }
    }
}
