using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dnd.Dal.Entities
{
    public class Weapon
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int? AtkBonus { get; set; }
        public int? Dmg { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
    }
}
