using System.Windows;
using TransferCo.ViewModels;

namespace TransferCo.Views;

/// <summary>
/// Interaction logic for AddClientWindow.xaml
/// </summary>
public partial class AddClientWindow : Window
{
    public AddClientWindow()
    {
        DataContext = new AddClientViewModel();
        InitializeComponent();
    }
}
