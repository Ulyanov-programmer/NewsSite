using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using NewsSite.Entities.DBAbstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.DTOModels.NullClasses
{
    class NullDTO : IDTOModel
    {
        private readonly IDbObject _dbObject;

        public NullDTO(Type typeofDbObject) 
        {
            if (typeofDbObject == typeof(DTONews))
            {
                _dbObject = new DbNews(-1, "DefaultName", "DefaultPath");
            }
            else if (typeofDbObject == typeof(DTOUser))
            {
                _dbObject = new DbUser("DefaultName", "DefaultEmail");
            }
        }

        IDbObject IDTOModel.DbObject => _dbObject;

        public bool Equals(IDbObject dbObject)
        {
            if (_dbObject.Id == dbObject.Id &&
                _dbObject.Name == dbObject.Name)
            {
                return true;
            }
            return false;
        }

        public string GetName()
        {
            return _dbObject.Name;
        }
    }
}
