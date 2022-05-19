using Gateway.Application.Orders.Commands;
using System.Collections.Generic;

namespace Gateway.Orders.Administration
{
    public class OrderRequest
    {
        public OrderItemDto [] OrderItems { get; set; }

        public string Email { get; set; }

    }
}