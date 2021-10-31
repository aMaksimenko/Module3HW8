using System.Threading.Tasks;

namespace HomeWork
{
    internal class Program
    {
        private static async Task Main()
        {
            var starter = new Starter();

            await starter.Run();
        }
    }
}