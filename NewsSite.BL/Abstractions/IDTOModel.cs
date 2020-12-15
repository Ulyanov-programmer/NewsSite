using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Abstractions
{
    public interface IDTOModel
    {
        public List<string> GetInfo();

        internal IDbObject DbObjectOfDTOModel { get; }
    }
}
