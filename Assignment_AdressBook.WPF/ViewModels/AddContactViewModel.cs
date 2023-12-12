using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;

namespace Assignment_AdressBook.WPF.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    [ObservableProperty]
    private IContact _contact = new Contact();

    private IContactService _contactService;
    private readonly IServiceProvider _serviceProvider;


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
        IEnumerable<IContact> _contactList = _contactService.GetAllContactsFromList();
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
        else
        {
            MessageBox.Show("Something went wrong while trying to add contact");
        }
    }
}
