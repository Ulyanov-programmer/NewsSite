using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsSite.BL
{
    internal class Role : IDbObject
    {
        public Role() { }

        [Key]
        public int Id { get; private set; }

        public string Name { get; private set; }

        public ICollection<DbUser> DbUsers { get; set; }
    }
}
