using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AssignmentAddressBookMaui.PageModels;

public partial class UpdateContactPageModel : ObservableObject
{
    [ObservableProperty]
    private IContact _contact;

    private readonly IContactService _contactService;

    public UpdateContactPageModel(IContactService contactService, IContact contact)
    {
        _contactService = contactService;
        _contact = contact;
    }

    [RelayCommand]
    public void ContactToUpdate(string email)
    {
        Contact = _contactService.GetOneContactFromList(email);
    }

    [RelayCommand]
    private async Task SaveAndUpdate(IContact contact)
    {
        if (!String.IsNullOrWhiteSpace(Contact.Email))
        {
            var result = _contactService.UpdateContactFromList();

            if (result)
            {
                await Shell.Current.DisplayAlert("Updated", "Contact was updated", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Something went wrong trying to update contact", "OK");
            }
        }
    }
}