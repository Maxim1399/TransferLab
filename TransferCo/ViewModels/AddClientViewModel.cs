using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferCo.Service;
using TransferCo.Service.Models;

namespace TransferCo.ViewModels;

public partial class AddClientViewModel : ObservableObject
{
    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string adress = string.Empty;

    [ObservableProperty]
    private string phone = string.Empty;

    private readonly ITransferService transferService;

    public AsyncRelayCommand CreateClinetCommand { get; }

    public AddClientViewModel()
    {
        transferService = App.TransferService;
        CreateClinetCommand = new AsyncRelayCommand(AddClient);
    }

    private async Task AddClient()
    {
        var client = new CreateClientModel
        {
            Name = name,
            Adress = adress,
            Phone = phone,
        };

        await transferService.CreateClinet(client);
    }
}
