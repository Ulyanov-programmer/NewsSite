using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using NewsSite.BL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.BL.Servies
{
    internal class FullDataBaseService : IService
    {
        private readonly NewsSiteContext _context;

        internal FullDataBaseService(NewsSiteContext context)
        {
            _context = context;
        }

        public NewsSiteContext Context
        {
            get => _context;
        }

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
