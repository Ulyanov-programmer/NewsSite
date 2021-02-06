using NewsSite.Entities.DBAbstractions;
using NewsSite.Entities.DbModels;
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
        public int Id { get; private set; }

        public string Name { get; private set; }

        public ICollection<DbUser> DbUsers { get; private set; }
    }
}
