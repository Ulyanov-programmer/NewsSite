using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL
{
    public class Log
    {
        public Log(string nameOfController, string nameOfMethod, string message, bool result = false)
        {
            Result = result;
            NameOfController = nameOfController;
            NameOfMethod = nameOfMethod;
            Message = message;
        }

        public bool Result { get; set; }

        public string NameOfController { get; set; }
        public string NameOfMethod { get; set; }

        public string Message { get; set; }
    }
}
