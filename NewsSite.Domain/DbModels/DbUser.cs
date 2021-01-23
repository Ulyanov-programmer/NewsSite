using NewsSite.BL.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsSite.BL.DbModels
{
    public class DbUser : IUser, IDbObject
    {
        [Key]
        public int Id { get; private set; }

        public string Name { get; private set; }

        public ICollection<DbNews> DbNews { get; private set; }

        //public Role RoleId { get; set; }

        //public string NameOfRole
        //{
        //    get => RoleId.Name;
        //}

        public string Email { get; private set; }

        public DbUser(string nameOfUser, string emailOfUser)
        {
            Name = nameOfUser;
            //RoleId = roleOfUser;
            Email = emailOfUser;
        }

        public DbUser() { }
    }
}
