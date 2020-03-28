using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebCrawlerCore
{
    public static class Logs
    {
        public static ILoggerFactory Factory;
        public static void Init(IConfiguration config)
        {
            Factory = LoggerFactory.Create(builder =>
            {
                builder
                    .ClearProviders()
                    .SetMinimumLevel(LogLevel.Trace)
                    .AddConfiguration(config.GetSection("Logging"))
                    .AddConsole(options => { options.IncludeScopes = true; })
                    .AddFile("logs/crawlerCore-{Date}.json", LogLevel.Trace, isJson: true);
            });
        }
    }
}
