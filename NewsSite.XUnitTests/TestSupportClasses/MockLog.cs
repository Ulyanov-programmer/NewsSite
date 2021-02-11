using NewsSite.BL;
using NewsSite.Tests.Abstractions;

namespace NewsSite.Tests.TestSupportClasses
{
    /// <summary>
    /// Логгирует результат работы с Mosk-объектами, для них и рекомендуется. 
    /// </summary>
    /// <remarks>
    /// Наследует: Log
    /// </remarks>
    internal class MockLog : Log
    {
        /// <summary>
        /// Создаёт новый объект MoskLog на основе входных параметров.
        /// </summary>
        /// <param name="initVariant"> Вариант инициализации объекта, лог которого ведётся. </param>
        /// <param name="nameOfController"> Имя класса, метод которого был завершён. </param>
        /// <param name="nameOfMethod"> Имя метода, который был завершён. </param>
        /// <param name="message"> Сообщение, описывающее результат работы метода. </param>
        /// <param name="result"> Значение оценивающее результат работы метода. По умолчанию - true. </param>
        internal MockLog(InitializationVariants initVariant, string nameOfController, 
                         string nameOfMethod, string message, bool result = true)
                  : base(nameOfController, nameOfMethod, message, result)
        {
            InitVariant = initVariant;
        }

        /// <summary>
        /// Создаёт новый объект MoskLog на основе входных параметров.
        /// </summary>
        /// <param name="initVariant"> Вариант инициализации объекта, лог которого ведётся. </param>
        /// <param name="log"> Объект Log, данные которого будет использованы для этого MoskLog. </param>
        internal MockLog(InitializationVariants initVariant, Log log)
                  : base(log.NameOfController, log.NameOfMethod, log.Message, log.Result)
        {
            InitVariant = initVariant;
        }

        internal readonly InitializationVariants InitVariant;
    }
}
