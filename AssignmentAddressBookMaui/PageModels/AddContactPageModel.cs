using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Models;
using Assignment_AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Contact = Assignment_AddressBook.Shared.Models.Contact;

namespace AssignmentAddressBookMaui.PageModels;

public partial class AddContactPageModel : ObservableObject
{

    [ObservableProperty]
    private IContact contact = new Contact();

    private readonly IContactService _contactService;

    public AddContactPageModel(IContactService contactService)
    {
        _contactService = contactService;
    }

    [RelayCommand]
    private async Task AddContactToList()
    {
        if (!string.IsNullOrWhiteSpace(Contact.Email))
        {
            bool contactAdded = _contactService.AddContactToList(Contact);
            if (contactAdded)
            {
                await Application.Current.MainPage.DisplayAlert("Added","Contact was added!", "OK");
                Contact = new Contact();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Unable to add", "Contact already exists", "OK");
            }
        }
    }
}
