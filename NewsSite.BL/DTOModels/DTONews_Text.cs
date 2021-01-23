using NewsSite.BL.Managers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NewsSite.BL.DTOModels
{
    /// <summary>
    /// Содержит форматированный текст документа, определяемого при создании объекта.
    /// </summary>
    public class DTONews_Text
    {
        /// <summary>
        /// Содержит текст документа, разбитый на параграфы.
        /// </summary>
        public IEnumerable<string> Paragraphs { get; private set; }

        /// <summary>
        /// Заголовок новости.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Создаёт новый экземпляр DTONews_Text.
        /// </summary>
        /// <param name="nameOfDoc"> Имя документа (не полный путь и без формата файла), из которого будет взят текст для этого объекта. </param>
        /// <param name="titleOfNews"> Название (заголовок) новости. </param>
        public DTONews_Text(string nameOfDoc, string titleOfNews)
        {
            Paragraphs = EditTextFromFIle(nameOfDoc).ToList();
            Title = titleOfNews;
        }

        /// <summary>
        /// Форматирует текст документа из файла.
        /// </summary>
        /// 
        /// <param name="nameOfDoc"> Имя документа (не полный путь и без формата файла), из которого будет взят текст для этого объекта. </param>
        /// 
        /// <returns>
        /// Коллекция строк на которые был разбит текст документа (разбивает по параграфам).
        /// </returns>
        private static IEnumerable<string> EditTextFromFIle(string nameOfDoc)
        {
            
            string textOfDoc;

            using (StreamReader sr = new StreamReader
                  ($@"{FileManager.PathToTxtDocFolder}\{nameOfDoc}.txt", Encoding.UTF8))
            {
                textOfDoc = sr.ReadToEnd();
            }

            var paragraphs = Regex.Split(textOfDoc, @"(\r\n?|\n){2}")
                                  .Where(p => p.Any(char.IsLetterOrDigit));
            return paragraphs;
        }
    }
}
