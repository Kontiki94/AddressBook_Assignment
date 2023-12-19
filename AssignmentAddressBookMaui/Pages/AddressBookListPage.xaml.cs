using Assignment_AddressBook.Shared.Interfaces;
using AssignmentAddressBookMaui.PageModels;
using Microsoft.Maui.ApplicationModel.Communication;

namespace AssignmentAddressBookMaui.Pages;

public partial class AddressBookListPage : ContentPage
{
    public AddressBookListPage(AddressBookListPageModel pageModel)
    {
        InitializeComponent();
        BindingContext = pageModel;
    }
}