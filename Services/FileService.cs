using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Services.Abstractions;

namespace HomeWork.Services
{
    public class FileService : IFileService
    {
        public async Task<IEnumerable<string>> ReadAsync(string path)
        {
            var result = new List<string>();

            using (var sr = new StreamReader(path, Encoding.Default))
            {
                string line;

                while ((line = await sr.ReadLineAsync()) != null)
                {
                    result.Add(line);
                }

                return result;
            }
        }

        public async Task WriteAsync(string path, IEnumerable<string> data)
        {
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }

            try
            {
                using (var sw = new StreamWriter(path, false, Encoding.Default))
                {
                    foreach (var line in data)
                    {
                        await sw.WriteLineAsync(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}