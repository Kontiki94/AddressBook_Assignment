using Assignment_AddressBook.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Assignment_AdressBook.WPF.ViewModels;

public partial class UpdateContactViewModel : ObservableObject
{
    private IContactService _contactService;
    private ViewOptionsModel _viewOptionsModel;

    [ObservableProperty]
    private IContact? _contact;

    public UpdateContactViewModel(IContactService contactService, IContact contact, ViewOptionsModel viewOptionsModel)
    {
        _contactService = contactService;
        _contact = contact;
        _viewOptionsModel = viewOptionsModel;
    }

    [RelayCommand]
    public void UpdateContactInList(string email)
    {
        Contact = _contactService.GetOneContactFromList(email);
    }

    [RelayCommand]
    public void SaveAndUpdate(IContact contact)
    {
        if (!String.IsNullOrWhiteSpace(contact.Email))
        {
            var result = _contactService.UpdateContactFromList();
            if (result)
            {
                MessageBox.Show("Contact updated!");
                _viewOptionsModel.NavigateToAllContacts();
            }
            else
            {
                Console.WriteLine("Something went wrong while updating");
            }
        }
        else if (String.IsNullOrWhiteSpace(contact.Email))
        {
            MessageBox.Show("Email is needed to update!");
        }
    }
}
