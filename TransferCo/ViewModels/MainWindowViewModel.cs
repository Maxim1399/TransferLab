using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using TransferCo.Data.Entities;
using TransferCo.Service;
using TransferCo.Service.Models;

namespace TransferCo.ViewModels;

class MainWindowViewModel
{
    public EventHandler OnTransporterAddedHandler;
    public EventHandler OnClientAddedHandler;
    public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
    public ObservableCollection<Transporter> Transporters { get; set; } = new ObservableCollection<Transporter> { };
    public IEnumerable<string> Status { get; set; }

    public string SelectedClient { get; set; }

    public string SelectedTransporters { get; set; }

    public string SelectedStatus { get; set; }

    public DateOnly CreateDate { get; set; }

    public DateOnly UpdateDate { get; set; }

    public AsyncRelayCommand AddOrderCommand { get; set; }

    private readonly ITransferService transporterService;

    public MainWindowViewModel()
    {

        transporterService = App.TransferService;

        CreateStatusList();

        foreach (var item in transporterService.GetClients().Result)
            Clients.Add(item);

        foreach (var item in transporterService.GetTransporters().Result)
            Transporters.Add(item);       

        AddOrderCommand = new AsyncRelayCommand(AddOrder);
        transporterService.OnClientAdded += UpdateClientList;
        transporterService.OnTransporterAdded += UpdateTransporterList;
    }

    private async Task AddOrder()
    {
        var clinetId = Clients
            .Where(x => x.Name == SelectedClient).FirstOrDefault();
        var transporterId = Transporters
            .Where(x => x.Name == SelectedTransporters).FirstOrDefault();

        var order = new CreateOrderModel
        {
            ClientId = clinetId.ClientId,
            TransporterId = transporterId.TransporterId,
            Created = CreateDate,
            Updated = UpdateDate,
            OrderStatus = SelectedStatus,
        };

        await transporterService.CreateOrder(order);
    }

    private void CreateStatusList()
    {
        Status = new List<string>()
        {
            "Принят",
            "Доставляется",
            "Готов к выдаче",
            "Отменен",
        };
    }

    private void UpdateClientList(Client client)
    {
        Clients.Add(client);
    }

    private void UpdateTransporterList(Transporter transporter)
    {
        Transporters.Add(transporter);
    }


}
