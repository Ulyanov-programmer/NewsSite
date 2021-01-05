using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using NewsSite.BL.Managers;
using System.Collections.Generic;
using System.Linq;

namespace NewsSite.BL.DTOModels
{
    /// <summary>
    /// Представляет DTO-модель, хранящую данные защищённого объекта DbNews.
    /// Доступ к свойствам объекта DbNews реализуется через методы этой модели. 
    /// </summary>
    /// <remarks>
    /// Реализует: <c>IDTOModel</c>
    /// </remarks>
    public class DTONews : IDTOModel
    {
        /// <summary>
        /// Приватный объект DbNews, данные которого являются основой этого DTONews.
        /// </summary>
        private readonly DbNews DbObject;

        /// <summary>
        /// [не функционально] Реализует доступ к свойству DbNews DbObject этого экземпляра DTONews.
        /// </summary>
        IDbObject IDTOModel.DbObjectOfDTOModel => DbObject;

        /// <summary>
        /// Создаёт экземпляр DTONews.
        /// </summary>
        /// <param name="dbNews"> объект DbNews, являющегося основой DTONews. </param>
        internal DTONews(DbNews dbNews)
        {
            DbObject = dbNews;
        }

        /// <summary>
        /// Создаёт экземпляр DTONews, создавая объект DbNews на основе входных параметров.
        /// </summary>
        /// 
        /// <param name="author"> Объект DTOUser, свойство DbObject.Id которого 
        ///                       будет сохранено для DbNews.DbUserId . </param>
        /// <param name="nameOfNews"> Будет применено для значения DbNews.Name. </param>
        /// <param name="nameOfDocument"> Название хранимого документа новостей, 
        ///                               будет использовано для создания DbNews.PathToDocument . </param>
        public DTONews(DTOUser author, string nameOfNews, string nameOfDocument)
        {
            DbObject = new DbNews(author.DbObject.Id, nameOfNews, $@"{FileManager.PathToDocFolder}\{nameOfDocument}");
        }

        /// <summary>
        /// [устарело] 
        /// Возвращает информацию DTO-объекта в виде коллекции строк.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Возвращает значение DbObject.Name этого экземпляра DTONews.
        /// Если значение является null, пустой строкой или состоящей только из пробелов, возвращает "DefaultName".
        /// </summary>
        /// <returns></returns>
        public string GetNameOfNews()
        {
            if (string.IsNullOrWhiteSpace(DbObject.Name) is false)
            {
                return DbObject.Name;
            }
            else
            {
                return "DefaultName";
            }
        }

        /// <summary>
        /// Возвращает значение DbObject.PathToDocument этого экземпляра DTONews.
        /// Если значение является null, пустой строкой или состоящей только из пробелов, возвращает "Path is not found".
        /// </summary>
        /// <returns></returns>
        public string GetPathToDocument()
        {
            if (string.IsNullOrWhiteSpace(DbObject.Name) is false)
            {
                return DbObject.PathToDocument;
            }
            else
            {
                return "Path is not found";
            }
        }

        /// <summary>
        /// Возвращает имя документа, на который ссылается значение DbObject.PathToDocument этого экземпляра DTONews.
        /// Если значение является null, пустой строкой или состоящей только из пробелов, возвращает "Path is not found".
        /// </summary>
        /// <returns></returns>
        public string GetNameOfDoc()
        {
            if (string.IsNullOrWhiteSpace(DbObject.PathToDocument) is false)
            {
                string nameOfDoc = DbObject.PathToDocument.Split('\\').Last();

                return nameOfDoc;
            }
            else
            {
                return "Path is not found";
            }
        }
    }
}
