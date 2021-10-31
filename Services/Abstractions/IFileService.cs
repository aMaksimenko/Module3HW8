using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeWork.Services.Abstractions
{
    public interface IFileService
    {
        public Task<IEnumerable<string>> ReadAsync(string path);
        public Task WriteAsync(string path, IEnumerable<string> data);
    }
}