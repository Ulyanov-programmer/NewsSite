using NewsSite.BL.Abstractions;
using NewsSite.Entities.DBAbstractions;
using NewsSite.Entities.DbModels;
using System;

namespace NewsSite.BL.DTOModels.NullClasses
{
    /// <summary>
    /// Null-версия имплементатора IDTOModel. Используется для реализации NullObject паттерна.
    /// </summary>
    /// <remarks>
    /// Реализует: IDTOModel
    /// </remarks>
    internal class NullDTO : IDTOModel
    {
        /// <summary>
        /// Приватный объект IDbObject. Используется, как болванка.
        /// </summary>
        private readonly IDbObject _dbObject;

        /// <summary>
        /// Создаёт новый объект NullDTO. 
        /// </summary>
        /// <param name="typeofDbObject"> На основе этого аргумента будет определён тип внутреннего IDbObject.
        ///                               Тип должен быть реализацией IDTOModel. 
        /// </param>
        /// <remarks>
        /// Тип внутреннего IDbObject зависит от входного типа DTO.
        /// </remarks>
        public NullDTO(Type typeofDbObject) 
        {
            if (typeofDbObject == typeof(DTONews))
            {
                _dbObject = new DbNews(-1, "DefaultName", "DefaultPath");
            }
            else if (typeofDbObject == typeof(DTOUser))
            {
                _dbObject = new DbUser("DefaultName", "DefaultEmail");
            }
        }

        /// <summary>
        /// Предоставляет доступ к закрытому объекту IDbObject этого NullDTO. 
        /// </summary>
        IDbObject IDTOModel.DbObject => _dbObject;

        /// <summary>
        /// Сравнивает объект DbObject этой DTO-модели с другим объектом IDbObject.
        /// </summary>
        /// <param name="dbObject"> Объект IDbObject, который будет сравнён с объектом DbObject этой DTO-модели. </param>
        /// <returns></returns>
        public bool Equals(IDbObject dbObject)
        {
            if (_dbObject.Id == dbObject.Id &&
                _dbObject.Name == dbObject.Name)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Возвращает поле Name внутреннего объекта IDbObject.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return _dbObject.Name;
        }
    }
}
