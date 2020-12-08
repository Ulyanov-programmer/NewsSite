using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Models
{
    public class DTOUser : IDTOModel
    {
        readonly DbUser DbObject;

        IDbObject IDTOModel.DbObjectOfDTOModel => DbObject;


        internal DTOUser(DbUser dbUser)
        {
            DbObject = dbUser;
        }

        public string GetInfo()
        {
            return $"Пользователь {DbObject.Name}, {DbObject.Email}";
        }
    }
}
