using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.DTOModels
{
    public class DTONews : IDTOModel
    {
        private readonly DbNews DbObject;

        IDbObject IDTOModel.DbObjectOfDTOModel => DbObject;

        internal DTONews(DbNews dbObject)
        {
            DbObject = dbObject;
        }

        public DTONews(string nameOfNews, string pathToDocument)
        {
            DbObject = new DbNews(nameOfNews, pathToDocument);
        }

        public List<string> GetInfo()
        {
            var info = new List<string>
            {
                DbObject.Name,
                DbObject.PathToDocument,
                DbObject.UserId.ToString()
            };

            return info;
        }
    }
}
