using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using NewsSite.BL.DTOModels;
using System;
using System.Collections.Generic;
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

        public IDbObject ReturnEntityFromDb(IDTOModel inputDTO)
        {
            throw new NotImplementedException();
        }   
    }
}
