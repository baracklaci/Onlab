using Dnd.Dal.Dto;
using Dnd.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dnd.Dal.Services
{
    public class UserService
    {
        private DndContext db;
        public UserService(DndContext dbContext)
        {
            this.db = dbContext;
        }

        public Entities.ApplicationUser GetEntityUser(string username)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username);
        }

        public ApplicationUserHeader FindUserByName(string username)
        {
            return db.Users.Select(u => new ApplicationUserHeader()
            {
                UserName = u.UserName,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                FriendRequest = u.FriendRequest,
                Friends = u.Friends.Select(f => f.Friend2.UserName).ToList()
            }).Where(u => u.UserName == username).FirstOrDefault();
        }

        public ApplicationUserHeader UpdateUser(string username, ApplicationUserHeader usernew)
        {
            var user = db.Users.Include(u => u.Friends).ThenInclude(u => u.Friend2).FirstOrDefault(u => u.UserName == username);
            if (user == null)
                return null;
            user.Email = usernew.Email;
            user.FirstName = usernew.FirstName;
            user.LastName = usernew.LastName;
            user.FriendRequest = usernew.FriendRequest;
            var newfriends = usernew.Friends.Except(user.Friends.Select(u => u.Friend2.UserName));
            foreach (var f in newfriends)
            {
                var friend = db.Users.FirstOrDefault(u => u.UserName == f);
                if (friend != null)
                {
                    user.Friends.Add(new UserFriend { Friend2 = friend });
                }
            }
            db.SaveChanges();
            return FindUserByName(username);
        }
    }
}
