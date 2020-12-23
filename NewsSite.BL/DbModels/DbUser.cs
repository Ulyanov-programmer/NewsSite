using NewsSite.BL.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsSite.BL.DbModels
{
    internal class DbUser : IUser, IDbObject
    {
        [Key]
        public int UserId { get; set; }

        public int Identity
        {
            get => UserId;
        }

        private string NameOfUser { get; set; }
        public string Name 
        {
            get => NameOfUser;
        }

        internal List<DbNews> DbNews { get; set; }

        //public Role RoleId { get; set; }

        //public string NameOfRole
        //{
        //    get => RoleId.Name;
        //}

        private string EmailOfUser { get; set; }

        public DbUser(string nameOfUser, string emailOfUser)
        {
            NameOfUser = nameOfUser;
            //RoleId = roleOfUser;
            EmailOfUser = emailOfUser;
        }

        public DbUser() { }

        public string Email
        {
            get => EmailOfUser;
        }
    }
}
