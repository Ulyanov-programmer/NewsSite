using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NewsSite.BL.DTOModels
{
    public class DTONews_Text
    {
        public readonly List<string> Paragraphs = new List<string>();

        public readonly string Title;

        public DTONews_Text(string nameOfDoc, string titleOfNews)
        {
            Paragraphs = EditTextOfNews(nameOfDoc).ToList();
            Title = titleOfNews;
        }

        private static IEnumerable<string> EditTextOfNews(string nameOfDoc)
        {
            string textOfDoc;

            using (StreamReader sr = new StreamReader
                  ($"{FileManager.PathToTxtDocFolder}{nameOfDoc}.txt", Encoding.UTF8))
            {
                textOfDoc = sr.ReadToEnd();
            }

            var paragraphs = Regex.Split(textOfDoc, @"(\r\n?|\n){2}")
                                  .Where(p => p.Any(char.IsLetterOrDigit));
            return paragraphs;
        }
    }
}
