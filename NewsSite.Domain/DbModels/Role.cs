using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsSite.BL
{
    /// <summary>
    /// Этот класс содержит функционал, который будет реализован в будущем. 
    /// На данный момент он бесполезен.
    /// </summary>
    internal class Role : IDbObject
    {
        public Role() { }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<DbUser> DbUsers { get; set; }
    }
}
