using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Abstractions
{
    public interface ILogger
    {
        //TODO: Сделать конструктор с передачей в него опций для создания контекста.
        public Log WriteLog(string nameOfController, string nameOfMethod, Exception ex);

        public Log WriteLog(string nameOfController, string nameOfMethod);
    }
}
