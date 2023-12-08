using Assignment_AddressBook.ConsoleApp.Services;
using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Models;
using Assignment_AddressBook.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Assignment_AddressBook.ConsoleApp;

public class Program
{
    static void Main()
    {
        var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
        {
            services.AddSingleton<IContact, Contact>();
            services.AddSingleton<IContactService, ContactService>();
            services.AddSingleton<ContactServiceConsoleApp>();
            services.AddSingleton<MenuService>();

        }).Build();

        builder.Start();
        Console.Clear();
        var menuService = builder.Services.GetRequiredService<MenuService>();
        menuService.Run();
    }
}
