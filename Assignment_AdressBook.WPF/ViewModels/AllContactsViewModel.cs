using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;


namespace Assignment_AdressBook.WPF.ViewModels;

public partial class AllContactsViewModel : ObservableObject
{
    private IServiceProvider _serviceProvider;
    private IContactService _contactService;
    private UpdateContactViewModel _updateContactViewModel;

    [ObservableProperty]
    private ObservableCollection<IContact> _contactList;

    [ObservableProperty]
    private IContact? contact;


    public AllContactsViewModel(IServiceProvider serviceProvider, IContactService contactService, UpdateContactViewModel updateContactViewModel)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
        _updateContactViewModel = updateContactViewModel;
        ContactList = _contactService.GetAllContactsFromList();
    }
    [RelayCommand]
    public void RemoveContactFromAddressBook(string email)
    {
        var removed = _contactService.RemoveContactFromList(email);

        if (removed)
        {
            MessageBox.Show("Contact removed!");
        }
        else
        {
            MessageBox.Show("Something went wrong");
        }
    }
    [RelayCommand]
    public void NavigateToUpdateContact(string email)
    {
        _updateContactViewModel.UpdateContactInList(email);
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<UpdateContactViewModel>();
    }

    [RelayCommand]
    public void NavigateToMainMenu()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ViewOptionsModel>();
    }

}
