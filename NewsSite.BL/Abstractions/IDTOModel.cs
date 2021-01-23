using System.Collections.Generic;

namespace NewsSite.BL.Abstractions
{
    /// <summary>
    /// Представляет абстракцию DTO-объекта, используемого для передачи данных между слоями приложения. 
    /// </summary>
    public interface IDTOModel
    {
        /// <summary>
        /// [устарело] 
        /// Возвращает информацию DTO-объекта в виде коллекции строк.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetInfo();

        /// <summary>
        /// Представляет собой объект IDbObject, данные которого являются основой этого IDTOModel.
        /// </summary>
        internal IDbObject DbObjectOfDTOModel { get; }
    }
}
