﻿using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using NewsSite.BL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsSite.BL.Managers
{
    /// <summary>
    /// Представляет класс, содержащий функционал для доступа к базе данных (с частичным функционалом).
    /// </summary>
    /// <remarks>
    /// Реализует: <c>ISimplifiedDbManager</c>
    /// </remarks>
    internal class SimplifiedDBManager : ISimplifiedDbManager
    {
        /// <summary>
        /// Объект контекста, необходимый для доступа к данным БД.
        /// </summary>
        private readonly NewsSiteContext _context;

        /// <summary>
        /// Создаёт экземпляр SimplifiedDBManager.
        /// </summary>
        /// <param name="context"> Объект контекста для этого экземпляра, необходимый для доступа к БД. </param>
        internal SimplifiedDBManager(NewsSiteContext context)
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
        public IDTOModel ReturnEntityFromDb(string nameOfEntity, Type typeOfReturnedDTOs)
        {
            IDTOModel dtoModel;

            if (typeOfReturnedDTOs == typeof(DTONews))
            {
                var dbModel = _context.News.FirstOrDefault(news => news.Name == nameOfEntity);
                dtoModel = new DTONews(dbModel);
            }
            else if (typeOfReturnedDTOs == typeof(DTOUser))
            {
                var users = _context.Users.ToList();

                var dbModel = users.FirstOrDefault(user => user.Name == nameOfEntity);
                dtoModel = new DTOUser(dbModel);
            }
            else
            {
                throw new TypeAccessException("Входной тип данных не соответствует ни одному из поддерживаемых в методе!");
            }

            if (dtoModel != null)
            {
                return dtoModel;
            }
            else { throw new NullReferenceException("Метод не смог найти сущность для возврата!"); }
        }

        /// <summary>
        /// Возвращает несколько объектов DTONews с начала или конца таблицы в БД.
        /// </summary>
        /// 
        /// <param name="count"> Количество возвращаемых сущностей. </param>
        /// <param name="lastNews"> Если true - осуществляет отбор с конца, false - с начала. </param>
        /// 
        /// <returns>
        /// Коллекция объектов DTONews, содержащих сведения о найденных сущностях.
        /// </returns>
        /// 
        /// <exception cref="NullReferenceException"> Если не была найдена сущность для возврата. </exception>
        public ICollection<DTONews> ReturnMultipleNews(int count, bool lastNews)
        {
            ICollection<DTONews> dtoNews = new List<DTONews>();
            IEnumerable<DbNews> dbNews;

            if (lastNews)
            {
                // Пропускает все элементы, кроме последних (их количество является значением входного count).
                dbNews = _context.News.Skip(Math.Max(0, _context.News.Count() - count)).ToList();
            }
            else
            {
                dbNews = _context.News.Take(count).ToList();
            }

            foreach (var entity in dbNews)
            {
                dtoNews.Add(new DTONews(entity));
            }

            #region IDTO realization
            // Реализация метода для возврата коллекции одного из имплементаторов IDTOModel, 
            // а не одного конкретного типа.

            /*if (typeOfReturnedDTOs.Name == "DbNews")
            {
                List<DbNews> news;

                if (lastEntities)
                {
                    news = _context.News.Skip(Math.Max(0, _context.News.Count() - count)).ToList();
                }
                else
                {
                    news = _context.News.Take(count).ToList();
                }

                foreach (var entity in news)
                {
                    dtoModels.Add(new DTONews(entity));
                }
            }
            else if (typeOfReturnedDTOs.Name == "DbUser")
            {
                List<DbUser> users;

                if (lastEntities)
                {
                    users = _context.Users.Skip(Math.Max(0, _context.Users.Count() - count)).ToList();
                }
                else
                {
                    users = _context.Users.Take(count).ToList();
                }

                foreach (var entity in users)
                {
                    dtoModels.Add(new DTOUser(entity));
                }
            }*/

            #endregion

            if (dtoNews != null && dtoNews.Count() > 0)
            {
                return dtoNews;
            }
            else { throw new NullReferenceException("Метод не смог найти сущности для возврата!"); }
        }
    }
}
