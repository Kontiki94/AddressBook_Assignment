using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Models;
using Assignment_AddressBook.Shared.Services;
using Assignment_AdressBook.WPF.ViewModels;
using Assignment_AdressBook.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Assignment_AdressBook.WPF;

public partial class App : Application
{
    private IHost? _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<IContactService, ContactService>();
                services.AddSingleton<IContact, Contact>();
                services.AddSingleton<IFileManager, FileManager>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<ViewOptionsModel>();
                services.AddSingleton<ViewOptionsView>();
                services.AddSingleton<AddContactViewModel>();
                services.AddSingleton<AddContactView>();
                services.AddSingleton<AllContactsViewModel>();
                services.AddSingleton<AllContactsView>();
                services.AddSingleton<OneContactViewModel>();
                services.AddSingleton<OneContactView>();
            })
            .Build();
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        _host!.Start();

        var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
