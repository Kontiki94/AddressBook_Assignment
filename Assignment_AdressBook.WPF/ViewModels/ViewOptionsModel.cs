using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Models;
using Assignment_AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Assignment_AdressBook.WPF.ViewModels;

public partial class ViewOptionsModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private IContactService _contactService;


    [ObservableProperty]
    private ObservableCollection<IContact> _contactList;

    public ViewOptionsModel(IServiceProvider serviceProvider, IContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
        _contactList = _contactService.GetAllContactsFromList();
    }

    [RelayCommand]
    public void NavigateToAllContacts()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AllContactsViewModel>();
    }

    [RelayCommand]
    public void NavigateToAddContact()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddContactViewModel>();
    }
}

