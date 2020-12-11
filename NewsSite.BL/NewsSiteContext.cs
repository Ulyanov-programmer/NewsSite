using Microsoft.EntityFrameworkCore;
using NewsSite.BL.DbModels;
using System;

namespace NewsSite.BL
{
    public class NewsSiteContext : DbContext
    {
        public NewsSiteContext(DbContextOptions<NewsSiteContext> options) : base(options)
        {

        }

        internal DbSet<DbUser> Users { get; set; }
        internal DbSet<DbNews> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbNews>()
                .HasOne(p => p.DbUserId)
                .WithMany(b => b.DbNews)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<DbUser>()
               .HasMany(p => p.DbNews)
               .WithOne(p => p.DbUserId);
        }
    }
}
