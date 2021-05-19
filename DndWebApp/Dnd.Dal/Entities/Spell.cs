using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dnd.Dal.Entities
{
    public class Spell
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int? Level { get; set; }
        [StringLength(50)]
        public string School { get; set; }
        [StringLength(50)]
        public string CastingTime { get; set; }
        [StringLength(50)]
        public string Range { get; set; }
        [StringLength(50)]
        public string Components { get; set; }
        [StringLength(50)]
        public string Duration { get; set; }
        [StringLength(5000)]
        public string Description { get; set; }
        [StringLength(5000)]
        public string HigherLevels { get; set; }
    }
}
