using Gateway.Application.Orders.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateway.Application.Orders.Queries
{
    public class OrderDetailsDto
    {
        public decimal OrderAmount { get; set; }

        public IReadOnlyCollection<OrderItemDto> OrderItems { get; set; }

        public int OrderId { get; set; }

        public OrderDetailsDto(decimal orderAmount, IReadOnlyCollection<OrderItemDto> orderItems, int orderId)
        {
            OrderAmount = orderAmount;
            OrderItems = orderItems;
            OrderId = orderId;
        }

    }
}
