using Microsoft.EntityFrameworkCore;
using NewsSite.BL.DbModels;
using System;

namespace NewsSite.BL
{
    public class NewsSiteContext : DbContext
    {
        internal NewsSiteContext(DbContextOptions<NewsSiteContext> options) : base(options)
        {
        }

        internal DbSet<DbUser> Users { get; set; }
        internal DbSet<DbNews> Videos { get; set; }
    }
}
