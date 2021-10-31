using HomeWork.Models;

namespace HomeWork.Services.Abstractions
{
    public interface IDataService
    {
        public User StringToUser(string source);
        public Order StringToOrder(string source);
        public string ResultToString(Result source);
    }
}