using NewsSite.BL.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsSite.BL.DbModels
{
    public class DbUser : IUser, IDbObject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<DbNews> DbNews { get; set; }

        //public Role RoleId { get; set; }

        //public string NameOfRole
        //{
        //    get => RoleId.Name;
        //}

        public string Email { get; set; }

        public DbUser(string nameOfUser, string emailOfUser)
        {
            Name = nameOfUser;
            //RoleId = roleOfUser;
            Email = emailOfUser;
        }

        public DbUser() { }
    }
}
