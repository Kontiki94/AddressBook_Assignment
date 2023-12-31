﻿using Assignment_AddressBook.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Contact = Assignment_AddressBook.Shared.Models.Contact;

namespace AssignmentAddressBookMaui.PageModels;

public partial class AddContactPageModel : ObservableObject
{
    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

    [ObservableProperty]
    private IContact contact = new Contact();

    private readonly IContactService _contactService;

    public AddContactPageModel(IContactService contactService)
    {
        _contactService = contactService;
    }

    [RelayCommand]
    public async Task AddContactToList()
    {
        Match match = regex.Match(Contact.Email);

        if (match.Success)
        {
            var contactAdded = _contactService.AddContactToList(Contact);
            if (contactAdded)
            {
                await Shell.Current.DisplayAlert("Added","Contact was added!", "OK");
                Contact = new Contact();
            }
            else
            {
                await Shell.Current.DisplayAlert("Unable to add", "Contact already exists", "OK");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "Please enter a valid email", "OK");
        }
    }
}
