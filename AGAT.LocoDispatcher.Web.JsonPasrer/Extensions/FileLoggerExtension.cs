using AGAT.LocoDispatcher.Web.JsonPasrer.Providers;
using Microsoft.Extensions.Logging;

namespace AGAT.LocoDispatcher.Web.JsonPasrer
{
    public static class FileLoggerExtension
    {
        public static ILoggerFactory AddLogger(this ILoggerFactory factory, string path)
        {
            factory.AddProvider(new FileLoggerProvider(path));
            return factory;
        }
    }
}
