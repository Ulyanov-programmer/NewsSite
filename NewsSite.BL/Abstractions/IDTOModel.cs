using System.Collections.Generic;

namespace NewsSite.BL.Abstractions
{
    public interface IDTOModel
    {
        public List<string> GetInfo();

        internal IDbObject DbObjectOfDTOModel { get; }
    }
}
