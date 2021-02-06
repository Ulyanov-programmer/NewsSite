using System.Collections.Generic;

namespace NewsSite.BL.Abstractions
{
    /// <summary>
    /// Представляет абстракцию DTO-объекта, используемого для передачи данных между слоями приложения. 
    /// </summary>
    public interface IDTOModel
    {
        /// <summary>
        /// Возвращает имя этого DTO объекта.
        /// </summary>
        /// <returns></returns>
        public string GetName();

        /// <summary>
        /// Представляет собой объект IDbObject, данные которого являются основой этого IDTOModel.
        /// </summary>
        internal IDbObject DbObject { get; }

        public bool Equals(IDbObject dbObject);
    }
}
