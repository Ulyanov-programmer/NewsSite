using Aspose.Words;
using Aspose.Words.Saving;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

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
        internal static string PathToDocFolder = Environment.GetFolderPath
                                                (Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsFiles";

        /// <summary>
        /// Константа пути к папке, содержащей текстовые файлы документов (.txt) с новостями. 
        /// </summary>
        internal static string PathToTxtDocFolder = Environment.GetFolderPath
                                                   (Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsTxtFiles";

        /// <summary>
        /// Сохраняет файл новостей из веб-формы, а так-же сохраняет их копии в формате .txt.
        /// </summary>
        /// 
        /// <param name="fileFromForm"> Объект IFormFile, содержащий 
        ///                             непосредственно файл из веб-формы, который будет сохранён. </param>
        /// <param name="pathSave"> 
        /// Путь по которому будет сохранён файл. Может быть (и является по умолчанию) null или пустой строкой.
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
            if (string.IsNullOrEmpty(pathSave))
            {
                pathSave = $@"{PathToDocFolder}\{fileFromForm.FileName}";
            }

            ExistsDirectories_IfNotThenCreate();

            using (var stream = new FileStream(pathSave, FileMode.Create))
            {
                await fileFromForm.CopyToAsync(stream);
            }
            SaveNewsAsTxt(pathSave, fileFromForm.FileName);

            return true;
        }

        /// <summary>
        /// Сохраняет текст из файла, конвертируя его в новый файл .txt .
        /// </summary>
        /// <param name="pathToDoc"> Путь к документу, откуда будет взят текст. </param>
        /// <param name="nameOfFile"> Название файла, из которого будет взят текст. </param>
        private static void SaveNewsAsTxt(string pathToDoc, string nameOfFile)
        {
            var loadOptions = new TxtLoadOptions();
            var txtSaveOptions = new TxtSaveOptions();

            Document doc = new Document(pathToDoc, loadOptions);

            doc.Save($@"{PathToTxtDocFolder}\{nameOfFile}.txt", txtSaveOptions);
        }

        /// <summary>
        /// Проверяет, существуют ли директории, в которых должны содержаться файлы новостей. 
        /// Если они не существуют - создаёт их.
        /// </summary>
        private static void ExistsDirectories_IfNotThenCreate()
        {
            if (File.Exists(PathToDocFolder) is false || File.Exists(PathToTxtDocFolder) is false)
            {
                //TODO: Возможно пересоздаёт папки, исправить.
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NewsSite");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsFiles");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsTxtFiles");
            }
        }
    }
}
