using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dnd.Dal.Entities
{
  public class FeatureSkill
  {
    [Key]
    public int ID { get; set; }
    [StringLength(50)]
    public string Name { get; set; }
    [StringLength(5000)]
    public string Description { get; set; }
    public int? Level { get; set; }
  }
}
