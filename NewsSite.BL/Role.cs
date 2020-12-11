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
        public int RoleId { get; set; }
        public int Identity
        {
            get => RoleId;
        }

        private string NameOfRole { get; set; }
        public string Name
        {
            get => NameOfRole;
            set => throw new NotImplementedException();
        }

        public List<DbUser> DbUsers { get; set; }
    }
}
