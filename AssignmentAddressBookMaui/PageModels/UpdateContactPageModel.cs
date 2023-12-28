using Assignment_AddressBook.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.RegularExpressions;

namespace AssignmentAddressBookMaui.PageModels;

public partial class UpdateContactPageModel : ObservableObject
{
    private readonly IContactService _contactService;
    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");


    [ObservableProperty]
    private IContact _contact;


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
        Match match = regex.Match(Contact.Email);

        if (match.Success)
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
        else
        {
            await Shell.Current.DisplayAlert("Error", "Please enter a valid email", "OK");
        }
    }
}