using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using NewsSite.BL.DTOModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.BL.Servies
{
    /// <summary>
    /// Представляет класс, содержащий функционал для доступа к базе данных (с полным функционалом).
    /// </summary>
    /// <remarks>
    /// Реализует: <c>IDbManager</c>
    /// </remarks>
    internal class FullDBManager : IDbManager
    {
        /// <summary>
        /// Объект контекста, необходимый для доступа к данным БД.
        /// </summary>
        private readonly NewsSiteContext _context;

        /// <summary>
        /// Создаёт экземпляр FullDBManager.
        /// </summary>
        /// <param name="context"> Объект контекста для этого экземпляра, необходимый для доступа к БД. </param>
        internal FullDBManager(NewsSiteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Реализует публичный доступ к чтению приватного параметра <c>NewsSiteContext _context</c>.
        /// </summary>
        public NewsSiteContext Context
        {
            get => _context;
        }

        /// <summary>
        /// Добавляет сущность в базу данных на основе параметров входного IDTOModel.
        /// Поддерживает асинхронность.
        /// </summary>
        /// 
        /// <param name="inputDTO"> Объект IDTOModel, параметры которого 
        ///                         будут основой для добавляемого объекта. 
        ///                         Тип класса влияет на тип сохраняемой сущности. </param>
        /// <remarks>
        /// Тип класса inputDTO влияет на тип сохраняемой сущности.
        /// </remarks>
        /// 
        /// <returns> Task(bool), Result которого true, если операция добавления была успешно выполнена. 
        /// Иначе, если тип класса входного IDTOModel не поддерживается в методе, 
        /// сущность не будет сохранена и Result будет равен false.
        /// </returns>
        public async Task<bool> AddEntityToDb(IDTOModel inputDTO)
        {
            if (inputDTO.GetType().Name == "DTONews")
            {
                DbNews news = inputDTO.DbObjectOfDTOModel as DbNews;
                _context.News.Add(news);
                await _context.SaveChangesAsync();
            }
            else if (inputDTO.GetType().Name == "DTOUser")
            {
                DbUser user = inputDTO.DbObjectOfDTOModel as DbUser;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Возвращает сущность из БД, проводя поиск по входному значению его имени 
        /// (согласно параметру Name, имеющегося у имплементаторов IDbObject).
        /// </summary>
        /// 
        /// <param name="nameOfEntity"> Имя искомой сущности (в базе данных будет проводится поиск по столбцу Name). </param>
        /// <param name="typeOfEntity"> Тип искомой сущности (должен быть реализатором IDTOModel). </param>
        /// 
        /// <returns> Объект IDTOModel с данными о найденной сущности. </returns>
        /// 
        /// <exception cref="TypeAccessException"> Если значение typeOfEntity не соответствует ни одному из поддерживаемых в методе. </exception>
        /// <exception cref="NullReferenceException"> Если не была найдена сущность для возврата. </exception>
        public IDTOModel ReturnEntityFromDb(string nameOfEntity, Type typeOfEntity)
        {
            IDTOModel dbEntity;

            if (typeOfEntity.GetType().Name == "DTONews")
            {
                dbEntity = new DTONews(_context.News.FirstOrDefault(news => news.Name == nameOfEntity));
            }
            else if (typeOfEntity.GetType().Name == "DTOUser")
            {
                dbEntity = new DTOUser(_context.Users.FirstOrDefault(user => user.Name == nameOfEntity));
            }
            else
            {
                throw new TypeAccessException("Входной тип данных не соответствует ни одному из поддерживаемых в методе!");
            }

            if (dbEntity != null)
            {
                return dbEntity;
            }
            else { throw new NullReferenceException("Метод не смог найти сущность для возврата!"); }
        }   
    }
}
