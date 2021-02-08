using NewsSite.BL.Abstractions;
using NewsSite.BL.Managers;
using NewsSite.Entities.DBAbstractions;
using NewsSite.Entities.DbModels;
using System.Linq;

namespace NewsSite.BL.DTOModels
{
    /// <summary>
    /// Представляет DTO-модель, хранящую данные защищённого объекта DbNews.
    /// Доступ к свойствам внутреннего объекта DbNews реализуется через методы этой модели. 
    /// </summary>
    /// <remarks>
    /// Реализует: IDTOModel
    /// </remarks>
    public class DTONews : IDTOModel
    {
        #region params
        
        /// <summary>
        /// Приватный объект DbNews, данные которого являются основой этого DTONews.
        /// </summary>
        private readonly DbNews _dbObject;

        /// <summary>
        /// Реализует доступ к свойству DbNews DbObject этого экземпляра DTONews.
        /// </summary>
        IDbObject IDTOModel.DbObject => _dbObject;

        #endregion

        #region constructors
        
        /// <summary>
        /// Создаёт экземпляр DTONews.
        /// </summary>
        /// <param name="dbNews"> объект DbNews, являющегося основой DTONews. </param>
        internal DTONews(DbNews dbNews)
        {
            _dbObject = dbNews;
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
            _dbObject = new DbNews(author._dbObject.Id, nameOfNews, $@"{FileManager.PathToDocFolder}\{nameOfDocument}");
        }

        #endregion

        #region methods

        /// <summary>
        /// [дублирует GetName()] 
        /// Возвращает информацию DTO-объекта в виде коллекции строк.
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"{GetName()}";
        }

        /// <summary>
        /// Возвращает значение DbObject.Name этого экземпляра DTONews.
        /// Если значение является null, пустой строкой или состоящей только из пробелов, возвращает "DefaultName".
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            if (string.IsNullOrWhiteSpace(_dbObject.Name) is false)
            {
                return _dbObject.Name;
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
            if (string.IsNullOrWhiteSpace(_dbObject.Name) is false)
            {
                return _dbObject.PathToDocument;
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
            if (string.IsNullOrWhiteSpace(_dbObject.PathToDocument) is false)
            {
                string nameOfDocWithFormat = _dbObject.PathToDocument.Split('\\').Last();

                string nameOfDoc = nameOfDocWithFormat.Remove
                                  (nameOfDocWithFormat.IndexOf(".docx"));

                return nameOfDoc;
            }
            else
            {
                return "Path is not found";
            }
        }

        #endregion

        /// <summary>
        /// Сравнивает объект DbObject этой DTO-модели с другим объектом IDbObject.
        /// </summary>
        /// <param name="dbObject"> Объект IDbObject, который будет сравнён с объектом DbObject этой DTO-модели. </param>
        /// <returns></returns>
        public bool Equals(IDbObject dbObject)
        {
            if (_dbObject.Id == dbObject.Id &&
                _dbObject.Name == dbObject.Name)
            {
                return true;
            }
            return false;
        }
    }
}
