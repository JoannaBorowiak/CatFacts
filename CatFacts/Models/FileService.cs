using CatFacts.Interfaces;

namespace CatFacts.Models
{
    internal class FileService : IFileService
    {
        public void AppendToFile(string path, string content)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            using StreamWriter sw = File.AppendText(path);
            {
                sw.WriteLine(content);
            }
        }
    }
}
