using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace WebCrawlerCore
{
    public class Config
    {
        public Config(string[] args)
        {
            var inMemory = new Dictionary<string, string>
            {
                {"site", "https://www.google.co.uk"},
                {"output:folder", "reports" },
            };
            var configBuilder = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemory)
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("checksettings.json", true)
                .AddCommandLine(args)
                .AddEnvironmentVariables();

            var configuration = configBuilder.Build();
            Site = configuration["site"];
            Output = configuration.GetSection("output").Get<OutputSettings>();
            ConfigurationRoot = configuration;
        }

        public OutputSettings Output { get; set; }
        public string Site { get; set; }
        public IConfigurationRoot ConfigurationRoot { get; set; }
    }
}
