using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferCo.Data;
using TransferCo.Data.Entities;
using TransferCo.Service.Models;

namespace TransferCo.Service;
public class TransporterService : ITransferService
{
    public event Action<Client>? OnClientAdded;
    public event Action<Transporter>? OnTransporterAdded;
    public async Task<Client> CreateClinet(CreateClientModel model)
    {
        await using var context = new AppDbContext();
       
        var client = await context.Clients
          .Where(x => x.Name == model.Name &&
                      x.Adress == model.Adress &&
                      x.Phone == model.Phone)
          .FirstOrDefaultAsync();

        if (client is not null)
            return client;

        client = new Client
        {
            Name = model.Name,
            Phone = model.Phone,
            Adress = model.Adress,

        };
        await context.Clients.AddAsync(client);
        await context.SaveChangesAsync();

        OnClientAdded?.Invoke(client);
        return client;
    }

    public async Task<Transporter> CreateTransporter(CreateTransporterModel model)
    {
        await using var context = new AppDbContext();
        var transporter = await context.Transporters
            .Where(x => x.Name == model.Name &&
                        x.Phone == model.Phone)
            .FirstOrDefaultAsync();

        if (transporter is not null) return transporter;

        transporter = new Transporter
        {
            Name = model.Name,
            Phone = model.Phone,
            Status = model.Status,
        };
        await context.Transporters.AddAsync(transporter);
        await context.SaveChangesAsync();

        OnTransporterAdded?.Invoke(transporter);
        return transporter;
    }

    public async Task<IEnumerable<Client>> GetClients()
    {
        await using var context = new AppDbContext();

        var clients = await context.Clients.AsNoTracking().ToListAsync();
        return clients;
    }

    public async Task<IEnumerable<Transporter>> GetTransporters()
    {
        await using var context = new AppDbContext();

        var transporters = await context.Transporters.AsNoTracking().ToListAsync();
        return transporters;
    }

    public async Task<Order> CreateOrder(CreateOrderModel model)
    {
        await using var context = new AppDbContext();

        var order = new Order
        {
            ClientId = model.ClientId,
            TransporterId = model.TransporterId,
            Created = model.Created,
            Updated = model.Updated,
            OrderStatus = model.OrderStatus,
        };

        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return order;
    }
}
