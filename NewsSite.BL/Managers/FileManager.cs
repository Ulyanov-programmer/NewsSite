using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace NewsSite.BL.Managers
{
    /// <summary>
    /// Содержит методы и параметры для работы с файлами, которые хранит и использует проект.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Константа пути к папке, содержащей файлы документов (.doc, .docx) с новостями. 
        /// </summary>
        internal static readonly string PathToDocFolder = Environment.GetFolderPath
                                                (Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsFiles";

        /// <summary>
        /// Константа пути к папке, содержащей текстовые файлы документов (.txt) с новостями. 
        /// </summary>
        internal static readonly string PathToTxtDocFolder = Environment.GetFolderPath
                                                   (Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsTxtFiles";

        /// <summary>
        /// Сохраняет файл новостей из веб-формы, а так-же сохраняет их копии в формате .txt.
        /// </summary>
        /// 
        /// <param name="fileFromForm"> Объект IFormFile, содержащий 
        ///                             непосредственно файл из веб-формы, который будет сохранён. </param>
        /// <param name="pathSave"> 
        /// Путь по которому будет сохранён файл. Может быть (и является по умолчанию) пустой строкой.
        /// В этом случае, путь будет создан в теле метода:
        ///     <code>
        ///         if (string.IsNullOrEmpty(pathSave))
        ///         {
        ///             pathSave = $@"{PathToDocFolder}\{fileFromForm.FileName}";
        ///         }
        ///     </code>
        /// </param>
        /// 
        /// <returns>
        /// Task(bool), Result которого будет true, если операции сохранения были выполнены.
        /// </returns>
        public static async Task<bool> SaveFileOfNews(IFormFile fileFromForm, string pathSave = "")
        {
            if (fileFromForm.ContentType != ".docx")
            { return false; }

            string nameOfDoc = fileFromForm.FileName.Remove
                              (fileFromForm.FileName.IndexOf(".docx"));

            if (string.IsNullOrEmpty(pathSave))
            {
                pathSave = $@"{PathToDocFolder}\{fileFromForm.FileName}";
            }

            ExistsDirectories_IfNotThenCreate();

            using (var stream = new FileStream(pathSave, FileMode.Create))
            { await fileFromForm.CopyToAsync(stream); }

            SaveNewsAsText(pathSave, nameOfDoc);

            return true;
        }

        /// <summary>
        /// Сохраняет текст из файла, конвертируя его в новый файл .txt .
        /// </summary>
        /// <param name="pathToDoc"> Путь к документу, откуда будет взят текст. </param>
        /// <param name="nameOfFile"> Название файла, из которого будет взят текст. </param>
        private static void SaveNewsAsText(string pathToDoc, string nameOfFile)
        {
            string text;

            var nsMgr = new XmlNamespaceManager(new NameTable());
            nsMgr.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");

            using (var archive = ZipFile.OpenRead(pathToDoc))
            {
                #region readingFile

                text = XDocument.Load(archive.GetEntry(@"word/document2.xml").Open())
                                .XPathSelectElements("//w:p", nsMgr)
                                .Aggregate(new StringBuilder(), (sb, p) => p
                                    .XPathSelectElements(".//w:t|.//w:tab|.//w:br", nsMgr)
                                    .Select(e => { return e.Name.LocalName switch { "br" => "\r\n", "tab" => "\t", _ => e.Value, }; })
                                    .Aggregate(sb, (sb1, v) => sb1.Append(v)))
                                .ToString();

                #endregion
            }

            using var sw = new StreamWriter($@"{PathToTxtDocFolder}\{nameOfFile}.dat", true, Encoding.UTF8);
            sw.Write(text);
        }

        /// <summary>
        /// Проверяет, существуют ли директории, в которых должны содержаться файлы новостей. 
        /// Если они не существуют - создаёт их.
        /// </summary>
        private static void ExistsDirectories_IfNotThenCreate()
        {
            if (File.Exists(PathToDocFolder) is false || File.Exists(PathToTxtDocFolder) is false)
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NewsSite");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsFiles");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsTxtFiles");
            }
        }
    }
}
