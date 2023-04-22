using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferCo.Service.Models;

public class CreateOrderModel
{
    public int ClientId { get; set; }

    public int TransporterId { get; set; }

    public DateOnly Created { get; set; }

    public DateOnly Updated { get; set; }

    public string OrderStatus { get; set; }
}
