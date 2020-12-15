using Microsoft.AspNetCore.Hosting;
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
        static IHostingEnvironment WebHostBuilder;

        public static async Task<bool> SaveFile(IFormFile file)
        {
            using var stream = new FileStream(WebHostBuilder.WebRootPath, FileMode.Create);

            await file.CopyToAsync(stream);

            return true;
        }
    }
}
