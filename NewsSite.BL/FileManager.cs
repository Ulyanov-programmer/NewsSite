using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NewsSite.BL
{
    public static class FileManager
    {
        public static async Task<bool> SaveFile(IFormFile file, string pathTo_wwwroot)
        {
            using var stream = new FileStream($@"{pathTo_wwwroot}\NewsFiles\{file.FileName}", FileMode.Create);

            await file.CopyToAsync(stream);

            return true;
        }
    }
}
