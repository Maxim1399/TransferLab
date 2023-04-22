using System.Windows;
using TransferCo.ViewModels;

namespace TransferCo.Views;

/// <summary>
/// Interaction logic for AddTransporterWindow.xaml
/// </summary>
public partial class AddTransporterWindow : Window
{
    public AddTransporterWindow()
    {
        DataContext = new AddTransporterViewModel();
        InitializeComponent();
    }
}
