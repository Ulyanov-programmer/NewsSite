using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Abstractions
{
    public interface IAppController
    {
        public NewsSiteContext Context { get; }

        public IWebHostEnvironment HostingEnvironment { get; }
    }
}
