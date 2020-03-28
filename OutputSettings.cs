using System.IO;

namespace WebCrawlerCore
{
    public class OutputSettings
    {
        public OutputSettings()
        {
            File = "file.txt";
        }
        public string Folder { get; set; }
        public string File { get; set; }

        public string GetReportFilePath() =>
            Path.Combine(Directory.GetCurrentDirectory(), Folder, File);

        public string GetReportDirectory() => Path.GetDirectoryName(GetReportFilePath());
    }
}
