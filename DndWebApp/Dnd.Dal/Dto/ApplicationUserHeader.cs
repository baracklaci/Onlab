using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnd.Dal.Dto
{
    public class ApplicationUserHeader
    {
        //public List<CharacterSheet> CharacterSheets { get; set; } = new List<CharacterSheet>();
        //public List<User> Friends { get; set; } = new List<User>();
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool FriendRequest { get; set; }
        public List<string> Friends { get; set; } = new List<string>();
    }
}
