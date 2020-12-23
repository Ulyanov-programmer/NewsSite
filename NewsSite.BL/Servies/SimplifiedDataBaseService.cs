using NewsSite.BL.Abstractions;
using NewsSite.BL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IDTOModel ReturnEntityFromDb(string nameOfEntity, Type typeOfEntity)
        {
            IDTOModel dtoModel;

            if (typeOfEntity.Name == "DTONews")
            {
                var dbModel = _context.News.FirstOrDefault(news => news.Name == nameOfEntity);
                dtoModel = new DTONews(dbModel);
            }
            else if (typeOfEntity.Name == "DTOUser")
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
    }
}
