namespace NewsSite.BL.Abstractions
{
    /// <summary>
    /// Абстракция пользователя сайта. 
    /// <remark>
    ///     Рекомендуется имплементировать для классов-таблиц, сохраняющих данные о пользователях.
    /// </remark>
    /// </summary>
    public interface IUser
    {
        //string NameOfRole { get; }

        /// <summary>
        /// Почтовый адрес имплементатора IUser.
        /// </summary>
        string Email { get; }
    }
}
