using Microsoft.AspNetCore.Hosting;

namespace NewsSite.BL.Abstractions
{
    /// <summary>
    /// Абстракция контроллера, содержит общие для них поля.
    /// </summary>
    public interface IAppController
    {
        public IWebHostEnvironment HostingEnvironment { get; }
    }
}
