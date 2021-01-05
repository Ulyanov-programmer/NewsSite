using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using System.Collections.Generic;

namespace NewsSite.BL.DTOModels
{
    /// <summary>
    /// Представляет DTO-модель, хранящую данные защищённого объекта DbUser.
    /// Доступ к свойствам объекта DbUser реализуется через методы этой модели. 
    /// </summary>
    /// <remarks>
    /// Реализует: <c>IDTOModel</c>
    /// </remarks>
    public class DTOUser : IDTOModel
    {
        /// <summary>
        /// Приватный объект DbNews, данные которого являются основой этого DTONews.
        /// </summary>
        internal readonly DbUser DbObject;

        /// <summary>
        /// [не функционально] Реализует доступ к свойству DbNews DbObject этого экземпляра DTONews.
        /// </summary>
        IDbObject IDTOModel.DbObjectOfDTOModel => DbObject;

        /// <summary>
        /// Создаёт экземпляр DTOUser.
        /// </summary>
        /// <param name="dbUser"> объект DbUser, являющегося основой DTOUser. </param>
        internal DTOUser(DbUser dbUser)
        {
            DbObject = dbUser;
        }
        /// <summary>
        /// Создаёт экземпляр DTOUser, создавая объект DbUser на основе входных параметров.
        /// </summary>
        /// <param name="name"> Будет применено для значения DbUser.Name. </param>
        /// <param name="email"> Будет применено для значения DbUser.Email. </param>
        public DTOUser(string name, string email)
        {
            DbObject = new DbUser(name, email);
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
                DbObject.Email
            };

            return info;
        }
    }
}
