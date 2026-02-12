using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.m1chael888.Infrastructure;

namespace PhoneBook.m1chael888
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var collection = new ServiceCollection();

            collection.AddScoped<IRouter, Router>();

            var provider = collection.BuildServiceProvider();

            //resolve controller(s) to pass to router

            var router = provider.GetRequiredService<IRouter>();
            router.Route();
        }
    }
}
