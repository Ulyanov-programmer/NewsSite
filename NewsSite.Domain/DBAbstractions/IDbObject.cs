namespace NewsSite.BL.Abstractions
{
    /// <summary>
    /// Представляет абстракцию объекта базы данных. Рекомендуется имплементировать классам, 
    /// использующихся в Entity Framework для создания таблиц.
    /// </summary>
    public interface IDbObject
    {
        /// <summary>
        /// Уникальный идентификатор этого имплементатора IDbObject.
        /// </summary>
        int Id
        {
            get;
            set;
        }
        /// <summary>
        /// Имя этого имплементатора IDbObject.
        /// </summary>
        string Name
        {
            get;
            set;
        }
    }
}
