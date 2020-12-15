using NewsSite.BL.Abstractions;
using System;
using System.Collections.Generic;
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

        public IDTOModel ReturnEntityFromDb(IDTOModel inputDTO)
        {
            throw new NotImplementedException();
        }
    }
}
