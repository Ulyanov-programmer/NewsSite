using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Abstractions
{
    internal interface IDTOModel
    {
        public string GetInfo();

        internal IDbObject DbObjectOfDTOModel { get; }
    }
}
