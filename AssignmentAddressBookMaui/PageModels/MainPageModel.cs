using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace AssignmentAddressBookMaui.PageModels;

public partial class MainPageModel : ObservableObject
{
    [RelayCommand]
    private async Task NavigateToAddContact()
    {
        await Shell.Current.GoToAsync("AddContactPage");
    }
    [RelayCommand]
    private async Task NavigateToAddressBook()
    {
        await Shell.Current.GoToAsync("AddressBookListPage");
    }
}
