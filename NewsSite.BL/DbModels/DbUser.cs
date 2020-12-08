using NewsSite.BL.Abstractions;
using System;
using System.Collections.Generic;

namespace NewsSite.BL.DbModels
{
    internal class DbUser : IUser, IDbObject
    {
        readonly int Id;
        public int Identity
        {
            get => Id;
        }

        readonly string NameOfUser;
        public string Name 
        {
            get => NameOfUser;
            set => throw new NotImplementedException();
        }

        internal DbNews News { get; set; }

        readonly Role RoleOfUser;
        public Role Role
        {
            get => RoleOfUser;
        }

        readonly string EmailOfUser;

        public DbUser(string nameOfUser, Role roleOfUser, string emailOfUser)
        {
            NameOfUser = nameOfUser;
            RoleOfUser = roleOfUser;
            EmailOfUser = emailOfUser;
        }

        public string Email
        {
            get => EmailOfUser;
            set => throw new NotImplementedException();
        }
    }
}
