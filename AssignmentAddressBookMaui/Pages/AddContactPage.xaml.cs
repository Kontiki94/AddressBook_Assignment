using Assignment_AddressBook.Shared.Models;
using AssignmentAddressBookMaui.PageModels;

namespace AssignmentAddressBookMaui.Pages;

public partial class AddContactPage : ContentPage
{
	public AddContactPage(AddContactPageModel pageModel)
	{
		InitializeComponent();
		BindingContext = pageModel;
	}
}