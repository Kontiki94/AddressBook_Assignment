using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;

namespace AssignmentAddressBookMaui.PageModels;

public partial class AddressBookListPageModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<IContact> _contactlist;

    private readonly IContactService _contactService;
    private readonly UpdateContactPageModel _updateContact;

    public AddressBookListPageModel(IContactService contactService, UpdateContactPageModel updateContact)
    {
        _contactService = contactService;
        Contactlist = _contactService.GetAllContactsFromList();
        _updateContact = updateContact;
    }

    [RelayCommand]
    private async Task NavigateToUpdate(string email)
    {
        _updateContact.ContactToUpdate(email);
        await Shell.Current.GoToAsync("UpdateContactPage");
    }

    [RelayCommand]
    private async Task RemoveContactFromList(string email)
    {
        var removed = _contactService.RemoveContactFromList(email);

        if (removed)
        {
            await Application.Current.MainPage.DisplayAlert("Removed", "Contact was removed!", "OK");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong", "OK");
        }
    }
}
