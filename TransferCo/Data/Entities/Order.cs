using System;

namespace TransferCo.Data.Entities;
public class Order
{
    public int OrderId { get; set; }

    public Client Client { get; set; }
    public int ClientId { get; set; }

    public Transporter Transporter { get; set; }
    public int TransporterId { get; set; }

    public DateOnly Created { get; set; }

    public DateOnly Updated { get; set; }

    public string OrderStatus { get; set; }
}
    
