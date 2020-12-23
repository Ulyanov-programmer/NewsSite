using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsSite.BL
{
    internal class Role : IDbObject
    {
        public Role() { }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<DbUser> DbUsers { get; set; }
    }
}
