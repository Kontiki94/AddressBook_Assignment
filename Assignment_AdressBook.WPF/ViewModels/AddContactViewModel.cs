using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Assignment_AdressBook.WPF.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    private IContactService _contactService;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private IContact _contact = new Contact();


    public AddContactViewModel(IServiceProvider serviceProvider, IContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
    }

    [RelayCommand]
    public void NavigateToMainMenu()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ViewOptionsModel>();
    }

    [RelayCommand]
    public void AddContactToList()
    {
        if (!string.IsNullOrWhiteSpace(Contact.Email))
        {
            bool contactAdded = _contactService.AddContactToList(Contact);
            if (contactAdded)
            {
                Contact = new Contact();
                MessageBox.Show("Contact added succesfully!");
            }
            else
            {
                MessageBox.Show("A contact with this email already exists!");
            }
        }
    }
}
