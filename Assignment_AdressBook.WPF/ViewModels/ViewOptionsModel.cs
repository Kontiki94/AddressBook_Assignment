using Assignment_AddressBook.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment_AdressBook.WPF.ViewModels;

public partial class ViewOptionsModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public ViewOptionsModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

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
    [RelayCommand]
    public void NavigateToOneContact()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OneContactViewModel>();
    }
}

