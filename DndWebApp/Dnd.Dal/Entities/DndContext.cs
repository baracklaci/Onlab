using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnd.Dal.Entities
{
    public class DndContext : IdentityDbContext<ApplicationUser>
    {
        public DndContext(DbContextOptions<DndContext> options) : base(options)
        {

        }

        public override DbSet<ApplicationUser> Users { get; set; }
        public DbSet<UserFriend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserFriend>()
                .HasOne(uf => uf.Friend1)
                .WithMany(u => u.Friends)
                .HasForeignKey(uf => uf.UserID1);

            modelBuilder.Entity<UserFriend>()
                .HasOne(uf => uf.Friend2)
                .WithMany()
                .HasForeignKey(uf => uf.UserID2);

        }
    }
}
