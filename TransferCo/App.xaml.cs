using System.IO;
using System.Windows;
using TransferCo.Service;

namespace TransferCo;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static readonly ITransferService TransferService = 
        new TransporterService();
    public App()
    {
        Directory.CreateDirectory("Data");
    }
}
