using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PhoneBook.m1chael888.Infrastructure;

namespace PhoneBook.m1chael888
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettiongs.json")
                .Build();
            string connectionString = config.GetConnectionString("source");

            var collection = new ServiceCollection();

            collection.AddScoped<IRouter, Router>();
            collection.AddScoped<PhoneBookContext>(x => new PhoneBookContext(connectionString));

            var provider = collection.BuildServiceProvider();

            //resolve controller(s) to pass to router

            var router = provider.GetRequiredService<IRouter>();
            router.Route();
        }
    }
}