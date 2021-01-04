using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using NewsSite.BL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsSite.BL.Servies
{
    internal class SimplifiedDataBaseService : ISimplifiedService
    {
        private readonly NewsSiteContext _context;

        internal SimplifiedDataBaseService(NewsSiteContext context)
        {
            _context = context;
        }

        public NewsSiteContext Context
        {
            get => _context;
            set => throw new NotImplementedException();
        }

        public IDTOModel ReturnEntityFromDb(string nameOfEntity, Type typeOfReturnedDTOs)
        {
            IDTOModel dtoModel;

            if (typeOfReturnedDTOs.Name == "DTONews")
            {
                var dbModel = _context.News.FirstOrDefault(news => news.Name == nameOfEntity);
                dtoModel = new DTONews(dbModel);
            }
            else if (typeOfReturnedDTOs.Name == "DTOUser")
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

        public List<DTONews> ReturnMultipleNews(int count, bool lastNews)
        {
            List<DTONews> dtoNews = new List<DTONews>();
            List<DbNews> DbNews;

            if (lastNews)
            {
                // Пропускает все элементы, кроме последних (их количество является count).
                DbNews = _context.News.Skip(Math.Max(0, _context.News.Count() - count)).ToList();
            }
            else
            {
                DbNews = _context.News.Take(count).ToList();
            }

            foreach (var entity in DbNews)
            {
                dtoNews.Add(new DTONews(entity));
            }

            #region IDTO realization

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
