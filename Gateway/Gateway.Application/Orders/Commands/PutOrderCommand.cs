using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateway.Application.Orders.Commands
{
    public class PutOrderCommand : IRequest
    {
        public OrderItemDto [] OrderItems { get; set; }

        public string Email {get; set;}

        public PutOrderCommand(string email, OrderItemDto [] orderItems)
        {
           OrderItems = orderItems;
           Email = email;
        }



    }
}
