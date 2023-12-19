using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Models;
using Assignment_AddressBook.Shared.Services;
using AssignmentAddressBookMaui.PageModels;
using AssignmentAddressBookMaui.Pages;
using Contact = Assignment_AddressBook.Shared.Models.Contact;

namespace AssignmentAddressBookMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IContact, Contact>();
            builder.Services.AddSingleton<IContactService, ContactService>();
            builder.Services.AddSingleton<IFileManager, FileManager>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageModel>();
            builder.Services.AddSingleton<AddContactPage>();
            builder.Services.AddSingleton<AddContactPageModel>();
            builder.Services.AddSingleton<AddressBookListPage>();
            builder.Services.AddSingleton<AddressBookListPageModel>();
            builder.Services.AddSingleton<UpdateContactPage>();
            builder.Services.AddSingleton<UpdateContactPageModel>();


            return builder.Build();
        }
    }
}
