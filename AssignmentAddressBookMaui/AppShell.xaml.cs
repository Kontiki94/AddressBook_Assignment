using AssignmentAddressBookMaui.Pages;

namespace AssignmentAddressBookMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(AddressBookListPage), typeof(AddressBookListPage));
            Routing.RegisterRoute(nameof(UpdateContactPage), typeof(UpdateContactPage));

        }
    }
}
