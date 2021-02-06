using Microsoft.EntityFrameworkCore;
using NewsSite.Entities.DbModels;

namespace NewsSite.BL
{
    public class NewsSiteContext : DbContext
    {
        public NewsSiteContext(DbContextOptions<NewsSiteContext> options) : base(options)
        {
            //TODO: Уделять экземпляр контекста после операций.
        }

        internal DbSet<DbUser> Users { get; set; }
        internal DbSet<DbNews> News { get; set; }
    }
}
