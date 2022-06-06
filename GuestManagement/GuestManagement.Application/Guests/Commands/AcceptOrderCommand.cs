using System;
using GuestManagement.Domain.Guests.Orders;
using MediatR;


namespace GuestManagement.Application.Guests
{

    public class AcceptOrderCommand : IRequest
    {
        public string Email { get; set; }

        public OrderItem [] OrderItems {get; set;}
     
    }
}