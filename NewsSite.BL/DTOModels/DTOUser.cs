using NewsSite.BL.Abstractions;
using NewsSite.Entities.DBAbstractions;
using NewsSite.Entities.DbModels;
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
        internal readonly DbUser _dbObject;

        /// <summary>
        /// [не функционально] Реализует доступ к свойству DbNews DbObject этого экземпляра DTONews.
        /// </summary>
        IDbObject IDTOModel.DbObject => _dbObject;

        /// <summary>
        /// Создаёт экземпляр DTOUser.
        /// </summary>
        /// <param name="dbUser"> объект DbUser, являющегося основой DTOUser. </param>
        internal DTOUser(DbUser dbUser)
        {
            _dbObject = dbUser;
        }

        /// <summary>
        /// Создаёт экземпляр DTOUser, создавая объект DbUser на основе входных параметров.
        /// </summary>
        /// <param name="name"> Будет применено для значения DbUser.Name. </param>
        /// <param name="email"> Будет применено для значения DbUser.Email. </param>
        public DTOUser(string name, string email)
        {
            _dbObject = new DbUser(name, email);
        }

        /// <summary>
        /// Возвращает информацию DTO-объекта в виде строки.
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"{GetName()}, {GetEmail()}";
        }

        public string GetName()
        {
            if (string.IsNullOrWhiteSpace(_dbObject.Name) is false)
            {
                return _dbObject.Name;
            }
            else
            {
                return "NameIsNullOrWhiteSpace";
            }
        }

        public string GetEmail()
        {
            if (string.IsNullOrWhiteSpace(_dbObject.Email) is false)
            {
                return $"***{_dbObject.Email.Remove(0, 3)}";
            }
            else
            {
                return "EmailIsNullOrWhiteSpace";
            }
        }

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
