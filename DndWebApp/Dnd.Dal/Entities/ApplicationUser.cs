using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dnd.Dal.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<CharacterSheet> CharacterSheets { get; set; } = new List<CharacterSheet>();

        public List<UserFriend> Friends { get; set; } = new List<UserFriend>();
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public bool FriendRequest { get; set; } = true;
    }
}
