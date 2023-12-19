using AssignmentAddressBookMaui.PageModels;

namespace AssignmentAddressBookMaui.Pages;

public partial class UpdateContactPage : ContentPage
{
	public UpdateContactPage(UpdateContactPageModel pageModel)
	{
		InitializeComponent();
		BindingContext = pageModel;
	}
}