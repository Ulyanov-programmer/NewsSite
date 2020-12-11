using NewsSite.BL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Servies
{
    internal class FullDataBaseService : IService
    {
        private readonly NewsSiteContext _context;

        internal FullDataBaseService(NewsSiteContext context)
        {
            _context = context;
        }

        NewsSiteContext IService.Context
        {
            get => _context;
            set => throw new NotImplementedException();
        }

        IDbObject IService.AddEntityToDb()
        {
            throw new NotImplementedException();
        }

        IDTOModel IService.ReturnEntityFromDb()
        {
            throw new NotImplementedException();
        }
    }
}
