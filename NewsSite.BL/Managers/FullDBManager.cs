using Microsoft.EntityFrameworkCore;
using NewsSite.BL.Abstractions;
using NewsSite.BL.DTOModels;
using NewsSite.BL.DTOModels.NullClasses;
using NewsSite.Entities.DBAbstractions;
using NewsSite.Entities.DbModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.BL.Managers
{
    /// <summary>
    /// Представляет класс, содержащий функционал для доступа к базе данных (с полным функционалом).
    /// </summary>
    /// <remarks>
    /// Реализует: DbManager, IDbManager
    /// </remarks>
    public class FullDBManager : DbManager, IDbManager
    {
        /// <summary>
        /// Объект контекста, необходимый для доступа к данным БД.
        /// </summary>
        private readonly NewsSiteContext _context;

        /// <summary>
        /// Создаёт экземпляр FullDBManager и инициализирует объект контекста на основе опций из appsettings.json.
        /// </summary>
        public FullDBManager(string connectionString = "")
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                _context = new NewsSiteContext(GetDbContextOptions());
            }
            else
            {
                _context = new NewsSiteContext(GetDbContextOptions(connectionString));
            }
        }

        /// <summary>
        /// Добавляет сущность в базу данных на основе параметров входного IDTOModel.
        /// </summary>
        /// 
        /// <param name="inputDTO"> Объект IDTOModel, параметры которого 
        ///                         будут основой для добавляемого объекта. 
        ///                         Тип класса влияет на тип сохраняемой сущности. </param>
        /// <remarks>
        /// Тип входного inputDTO влияет на тип сохраняемой сущности. </remarks>
        /// 
        /// <returns> Task(bool), Result которого true, если операция добавления была успешно выполнена. 
        /// Иначе, если тип класса входного IDTOModel не поддерживается в методе, 
        /// сущность не будет сохранена и Result будет равен false.
        /// </returns>
        public async Task<bool> AddEntityToDb(IDTOModel inputDTO)
        {
            if (inputDTO.GetType() == typeof(DTONews))
            {
                DbNews news = inputDTO.DbObject as DbNews;

                _context.News.Add(news);
                await _context.SaveChangesAsync();
            }
            else if (inputDTO.GetType() == typeof(DTOUser))
            {
                DbUser user = inputDTO.DbObject as DbUser;

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
        /// Добавляет сущность в базу данных на основе параметров входного IDTOModel.
        /// </summary>
        /// 
        /// <param name="inputDbObject"> Объект IDbObject, параметры которого 
        ///                              будут основой для добавляемого объекта. 
        ///                              Тип класса влияет на тип сохраняемой сущности. </param>
        /// <remarks>
        /// Тип входного inputDTO влияет на тип сохраняемой сущности. </remarks>
        /// 
        /// <returns> Task Log, Result которого true, если операция добавления была успешно выполнена. 
        /// Иначе, будет возвращён Log с описанием ошибки и значением Result - false.
        /// Сущность не будет сохранена.
        /// </returns>
        public async Task<Log> AddEntityToDb(IDbObject inputDbObject)
        {
            try
            {
                if (inputDbObject.GetType() == typeof(DbNews))
                {
                    var newNews = inputDbObject as DbNews;

                    _context.News.Add(newNews);
                    await _context.SaveChangesAsync();
                }
                else if (inputDbObject.GetType() == typeof(DbUser))
                {
                    var newUser = inputDbObject as DbUser;

                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new TypeAccessException("Invalid type for IDbObject argument.");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return WriteLog(NameOfManager, "AddEntityToDb", ex);
            }
            catch (DbUpdateException ex)
            {
                return WriteLog(NameOfManager, "AddEntityToDb", ex);
            }
            catch (TypeAccessException ex)
            {
                return WriteLog(NameOfManager, "AddEntityToDb", ex);
            }
            catch (Exception ex)
            {
                return WriteLog(NameOfManager, "AddEntityToDb", ex);
            }

            return WriteLog(NameOfManager, "AddEntityToDb");
        }

        /// <summary>
        /// Возвращает сущность из БД, проводя поиск по входному значению его имени 
        /// (согласно параметру Name, имеющегося у имплементаторов IDbObject).
        /// </summary>
        /// 
        /// <param name="nameOfEntity"> Имя искомой сущности (в базе данных будет проводится поиск по столбцу Name). </param>
        /// <param name="typeOfEntity"> Тип искомой сущности (должен быть реализатором IDTOModel). </param>
        /// 
        /// <returns> 
        /// Объект IDTOModel с данными о найденной сущности. В ином случае - экземпляр NullDTO. 
        /// </returns>
        public IDTOModel ReturnEntityOrNullDTOFromDb(string nameOfEntity, Type typeOfEntity)
        {
            IDTOModel dbEntity;
            try
            {
                if (typeOfEntity == typeof(DTONews))
                {
                    dbEntity = new DTONews(_context.News.First(news => news.Name == nameOfEntity));
                }
                else if (typeOfEntity == typeof(DTOUser))
                {
                    dbEntity = new DTOUser(_context.Users.First(user => user.Name == nameOfEntity));
                }
                else
                {
                    throw new TypeAccessException
                  ("Входной тип данных не соответствует ни одному из поддерживаемых в методе!");
                }


                if (dbEntity != null)
                {
                    return dbEntity;
                }
                else { throw new NullReferenceException("Метод не смог найти сущность для возврата!"); }
            }
            catch (TypeAccessException)
            {
                return new NullDTO(typeOfEntity);
            }
            catch (ArgumentNullException)
            {
                return new NullDTO(typeOfEntity);
            }
            catch (InvalidOperationException)
            {
                return new NullDTO(typeOfEntity);
            }
        }

        /// <summary>
        /// Константа имени этого класса. Используется для быстрой записи в метод WriteLog.
        /// </summary>
        private const string NameOfManager = "FullDBManager";
    }
}
