using Microsoft.AspNetCore.Hosting;

namespace NewsSite.BL.Abstractions
{
    public interface IAppController
    {
        public IWebHostEnvironment HostingEnvironment { get; }
    }
}
