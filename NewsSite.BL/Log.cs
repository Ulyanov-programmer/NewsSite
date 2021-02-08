namespace NewsSite.BL
{
    /// <summary>
    /// Содержит данные о результате работы метода.
    /// </summary>
    /// <remarks>
    /// Рекомендуется использовать в качестве возвращаемого объекта для методов, 
    /// которые без этого не возвращают ничего.
    /// </remarks>
    public class Log
    {
        /// <summary>
        /// Создаёт объект Log на основе входных аргументов.
        /// </summary>
        /// <param name="nameOfController"> Имя класса, метод которого был завершён. </param>
        /// <param name="nameOfMethod"> Имя метода, который был завершён. </param>
        /// <param name="message"> Сообщение, описывающее результат работы метода. </param>
        /// <param name="result"> Значение оценивающее результат работы метода. По умолчанию - false. </param>
        public Log(string nameOfController, string nameOfMethod, string message, bool result = false)
        {
            Result = result;
            NameOfController = nameOfController;
            NameOfMethod = nameOfMethod;
            Message = message;
        }

        #region params

        /// <summary>
        /// Значение оценивающее результат работы метода. 
        /// </summary>
        public bool Result { get; set; }


        /// <summary>
        /// Имя класса, метод которого был завершён.
        /// </summary>
        public string NameOfController { get; set; }

        /// <summary>
        /// Имя метода, который был завершён.
        /// </summary>
        public string NameOfMethod { get; set; }

        /// <summary>
        /// Сообщение, описывающее результат работы метода.
        /// </summary>
        public string Message { get; set; }

        #endregion
    }
}
