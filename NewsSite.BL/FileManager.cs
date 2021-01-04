using Aspose.Words;
using Aspose.Words.Saving;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NewsSite.BL
{
    public static class FileManager
    {
        internal static string PathToDocFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsFiles\";

        internal static string PathToTxtDocFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsTxtFiles\";

        public static async Task<bool> SaveFileOfNews(IFormFile fileFromForm, string pathSave)
        {
            if (File.Exists(PathToDocFolder) is false || File.Exists(PathToTxtDocFolder) is false)
            {
                //TODO: Пересоздаёт папки, исправить.
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NewsSite");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsFiles");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NewsSite\NewsTxtFiles");
            }
            using (var stream = new FileStream(pathSave, FileMode.Create))
            {
                await fileFromForm.CopyToAsync(stream);
            }
            SaveNewsAsTxt(pathSave, fileFromForm.FileName);

            return true;
        }

        private static void SaveNewsAsTxt(string pathToDoc, string nameOfFile)
        {
            var loadOptions = new TxtLoadOptions();
            var txtSaveOptions = new TxtSaveOptions();

            Document doc = new Document(pathToDoc, loadOptions);

            doc.Save($"{PathToTxtDocFolder}{nameOfFile}.txt", txtSaveOptions);
        }
    }
}
