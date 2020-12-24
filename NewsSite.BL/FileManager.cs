using Microsoft.AspNetCore.Http;
using NewsSite.BL.DTOModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NewsSite.BL
{
    public static class FileManager
    {
        internal const string PathToDocFolder = @"C:\Users\colda\source\repos\NewsSite\WebApplication1\wwwroot\NewsFiles\";

        public static async Task<bool> SaveFileOfNews(IFormFile fileFromForm, string pathSave)
        {
            using var stream = new FileStream(pathSave, FileMode.Create);

            await fileFromForm.CopyToAsync(stream);

            return true;
        }
    }
}
