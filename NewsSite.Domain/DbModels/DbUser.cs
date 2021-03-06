﻿using NewsSite.Entities.DBAbstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsSite.Entities.DbModels
{
    /// <summary>
    /// Класс, использующийся и как таблица для Entity Framework. Содержит данные о сохранённых пользователях.
    /// </summary>
    /// <remarks>
    ///     Реализует: IDbObject,
    ///                IUser
    /// </remarks>
    public class DbUser : IUser, IDbObject
    {
        #region params

        /// <summary>
        /// Уникальный идентификатор в базе данных для этого пользователя.
        /// </summary>
        [Key]
        public int Id { get; private set; }

        /// <summary>
        /// Имя этого пользователя.
        /// </summary>
        [Required]
        public string Name { get; private set; }

        //public Role RoleId { get; set; }

        /// <summary>
        /// Почтовый адрес пользователя.
        /// </summary>
        [Required]
        public string Email { get; private set; }

        #endregion

        #region constructors

        /// <summary>
        /// Создаёт новый экземпляр DbUser на основе входных параметров.
        /// </summary>
        /// <param name="nameOfUser"> Имя нового пользователя. </param>
        /// <param name="emailOfUser"> Почтовый адрес пользователя. </param>
        public DbUser(string nameOfUser, string emailOfUser)
        {
            if (string.IsNullOrWhiteSpace(nameOfUser) is false && string.IsNullOrWhiteSpace(emailOfUser) is false)
            {
                Name = nameOfUser;
                Email = emailOfUser;
            }
        }

        /// <summary>
        /// Пустой конструктор, необходимый для инициализации данных из БД.
        /// </summary>
        public DbUser() { }

        #endregion

        #region FK_params

        /// <summary>
        /// Коллекция, представляющая все новости, автором которых является этот пользователь.
        /// </summary>
        public ICollection<DbNews> DbNews { get; private set; }

        #endregion
    }
}
