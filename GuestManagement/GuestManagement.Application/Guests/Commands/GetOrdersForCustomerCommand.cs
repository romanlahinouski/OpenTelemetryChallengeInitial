using System.Collections.Generic;
using GuestManagement.Domain.Guests.Orders;
using MediatR;

namespace GuestManagement.Application.Guests.Commands
{
    public class GetOrdersForCustomerCommand : IRequest<List<Order>>
    {
        
        public string Email { get; set; }
        
        
    }
}