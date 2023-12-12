using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Models;
using Assignment_AdressBook.WPF.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Assignment_AdressBook.WPF.ViewModels;

public partial class AllContactsViewModel : ObservableObject
{
    private IContactService _contactService;

    [ObservableProperty]
    private IEnumerable<IContact> _contactList = [];

    public AllContactsViewModel(IContactService contactService)
    {
        _contactService = contactService;
        _contactList = contactService.GetAllContactsFromList();
    }



    [RelayCommand]
    public void ShowAllContacts()
    {

    }
}
