using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferCo.Data.Entities;
using TransferCo.Service.Models;

namespace TransferCo.Service;
public interface ITransferService
{
    public event Action<Client>? OnClientAdded;
    public event Action<Transporter>? OnTransporterAdded;

    public Task<Client> CreateClinet(CreateClientModel client);
    public Task<Transporter> CreateTransporter(CreateTransporterModel model);
    public Task<Order> CreateOrder(CreateOrderModel model);


    public Task<IEnumerable<Client>> GetClients();
    public Task<IEnumerable<Transporter>> GetTransporters();
}
