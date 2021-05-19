using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dnd.Dal.Entities
{
    public class UserFriend
    {
        [Key]
        public int ID { get; set; }
        public string UserID1 { get; set; }
        public string UserID2 { get; set; }
        public ApplicationUser Friend1 { get; set; }
        public ApplicationUser Friend2 { get; set; }
    }
}
