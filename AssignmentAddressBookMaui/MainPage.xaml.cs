using AssignmentAddressBookMaui.PageModels;
using CommunityToolkit.Mvvm.Input;

namespace AssignmentAddressBookMaui
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageModel pageModel)
        {
            InitializeComponent();
            BindingContext = pageModel;
        }
    }

}
