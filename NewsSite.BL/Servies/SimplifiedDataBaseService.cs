using NewsSite.BL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL
{
    class SimplifiedDataBaseService : ISimplifiedService
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

        public IDTOModel ReturnEntityFromDb()
        {
            throw new NotImplementedException();
        }

        IDTOModel ISimplifiedService.ReturnEntityFromDb()
        {
            throw new NotImplementedException();
        }
    }
}
