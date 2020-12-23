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
    }
}
