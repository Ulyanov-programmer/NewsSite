using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using System.Collections.Generic;
using System.Linq;

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

        public DTONews(DTOUser author, string nameOfNews, string nameOfDocument)
        {
            DbObject = new DbNews(author.DbObject.Id, nameOfNews, $"{FileManager.PathToDocFolder}{nameOfDocument}");
        }

        public List<string> GetInfo()
        {
            var info = new List<string>
            {
                DbObject.Name,
                DbObject.PathToDocument,
                DbObject.DbUserId.ToString()
            };

            return info;
        }

        public string GetNameOfNews()
        {
            if (string.IsNullOrWhiteSpace(DbObject.Name) is false)
            {
                return DbObject.Name;
            }
            else
            {
                return "";
            }
        }
        public string GetPathToDocument()
        {
            if (string.IsNullOrWhiteSpace(DbObject.Name) is false)
            {
                return DbObject.PathToDocument;
            }
            else
            {
                return "";
            }
        }
        public string GetNameOfDoc()
        {
            if (string.IsNullOrWhiteSpace(DbObject.PathToDocument) is false)
            {
                string nameOfDoc = DbObject.PathToDocument.Split('\\').Last();

                return nameOfDoc;
            }
            else
            {
                return "";
            }
        }
    }
}
