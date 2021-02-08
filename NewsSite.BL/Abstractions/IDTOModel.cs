using NewsSite.Entities.DBAbstractions;

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
        //TODO: Переместить этот функционал в абстрактный класс.
        internal IDbObject DbObject { get; }

        /// <summary>
        /// Сравнивает объект DbObject этой DTO-модели с другим объектом IDbObject.
        /// </summary>
        /// <param name="dbObject"> Объект IDbObject, который будет сравнён с объектом DbObject этой DTO-модели. </param>
        /// <returns></returns>
        //TODO: Переместить этот функционал в абстрактный класс.
        public bool Equals(IDbObject dbObject);
    }
}
