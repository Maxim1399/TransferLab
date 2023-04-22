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

partial class AddTransporterViewModel : ObservableObject
{
    [ObservableProperty]
    private string transporterName = string.Empty;

    [ObservableProperty]
    private string transporterPhone = string.Empty;

    [ObservableProperty]
    private string transporterStatus = string.Empty;

    private readonly ITransferService transferService;

    public AsyncRelayCommand CreateTranporterCommand { get; }

    public AddTransporterViewModel()
    {
        transferService = App.TransferService;
        CreateTranporterCommand = new AsyncRelayCommand(AddTransporter);
    }

    private async Task AddTransporter()
    {
        var transporter = new CreateTransporterModel
        {
            Name = transporterName,
            Phone = transporterPhone,
            Status = transporterStatus,
        };

        await transferService.CreateTransporter(transporter);
    }
}
