﻿using NewsSite.BL.Abstractions;
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

        public List<string> GetInfo()
        {
            var info = new List<string>
            {
                DbObject.Name,
                DbObject.Email
            };

            return info;
        }
    }
}
