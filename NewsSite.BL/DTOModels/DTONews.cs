using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Models
{
    class DTONews : IDTOModel
    {
        readonly DbNews DbObject;

        IDbObject IDTOModel.DbObjectOfDTOModel => DbObject;

        public DTONews(DbNews dbObject)
        {
            DbObject = dbObject;
        }

        public string GetInfo()
        {
            return @$"Новость ""{DbObject.Name}"", путь - {DbObject.PathToDocument}";
        }
    }
}
