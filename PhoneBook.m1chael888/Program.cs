using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.m1chael888.Infrastructure;
using PhoneBook.m1chael888.Views;
using PhoneBook.m1chael888.Controllers;

namespace PhoneBook.m1chael888
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var collection = new ServiceCollection();

            collection.AddScoped<IRouter, Router>();
            collection.AddScoped<ContactController>();
            collection.AddScoped<IContactView, ContactView>();

            var provider = collection.BuildServiceProvider();

            //resolve controller(s) to pass to router

            var router = provider.GetRequiredService<IRouter>();
            var contactController = provider.GetRequiredService<ContactController>();
            var contactView = provider.GetRequiredService<IContactView>();

            router.Route(contactController, contactView);
        }
    }
}