using NewsSite.Entities.DBAbstractions;
using System.ComponentModel.DataAnnotations;

namespace NewsSite.Entities.DbModels
{
    /// <summary>
    /// Класс, использующийся и как таблица для Entity Framework. Содержит данные о сохранённых новостях.
    /// </summary>
    /// <remarks>
    ///     Реализует: IDbObject
    /// </remarks>
    public class DbNews : IDbObject
    {
        #region params

        /// <summary>
        /// Уникальный идентификатор в базе данных для этой новости.
        /// </summary>
        [Key]
        public int Id { get; private set; }

        /// <summary>
        /// Имя (представляет заголовок) этой новости базе данных.
        /// </summary>
        [Required]
        public string Name { get; private set; }

        /// <summary>
        /// Путь к документу, в котором находится или будет 
        /// находится документ в формате .docx, содержащий контент новости.
        /// </summary>
        [Required]
        public string PathToDocument { get; set; }

        #endregion

        #region constructors

        /// <summary>
        /// Создаёт новый экземпляр DbNews на основе входных параметров.
        /// </summary>
        /// <param name="authorId"> Значение Id в базе данных от автора этой новости. </param>
        /// <param name="nameOfNews"> Название (заголовок) новости. </param>
        /// <param name="pathToDocument"> Путь к документу, в котором находится или будет 
        ///                               находится документ в формате .docx, содержащий контент новости. </param>
        public DbNews(int authorId, string nameOfNews, string pathToDocument)
        {
            if (string.IsNullOrWhiteSpace(nameOfNews) is false && string.IsNullOrWhiteSpace(pathToDocument) is false)
            {
                DbUserId = authorId;
                Name = nameOfNews;
                PathToDocument = pathToDocument;
            }
        }

        /// <summary>
        /// Пустой конструктор, необходимый для инициализации данных из БД.
        /// </summary>
        public DbNews() { }

        #endregion

        #region FK_params

        /// <summary>
        /// Значение Id в базе данных от автора этой новости.
        /// </summary>
        public int DbUserId { get; set; }
        public DbUser DbUser { get; set; }

        #endregion
    }
}
