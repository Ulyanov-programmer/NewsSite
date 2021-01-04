using Microsoft.AspNetCore.Hosting;

namespace NewsSite.BL.Abstractions
{
    public interface IAppController
    {
        public NewsSiteContext Context { get; }

        public IWebHostEnvironment HostingEnvironment { get; }
    }
}
