using Assignment_AdressBook.WPF.ViewModels;
using System.Windows;
namespace Assignment_AdressBook.WPF;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}