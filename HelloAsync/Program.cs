using System;
using System.Threading.Tasks;

namespace HelloAsync
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DoAsyncShenanigans();
            Console.ReadKey();
        }

        private static async void DoAsyncShenanigans()
        {
            // tasks started here
            Task<string> aTask = AAsync();
            Task<string> bTask = BAsync();

            // do something else on the current thread while the tasks are running 
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(100);
                Console.WriteLine($"C: {i}");
            }

            // wait for both tasks to complete
            string resultA = await aTask;
            string resultB = await bTask;

            Console.WriteLine($"{resultA}, {resultB}");
        }

        private static async Task<string> BAsync()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(250);
                Console.WriteLine($"B: {i}");
            }
            return "B Result";
        }

        private static async Task<string> AAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(500);
                Console.WriteLine($"A: {i}");
            }
            return "A Result";
        }
    }
}