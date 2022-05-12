using Gateway.Application.Orders.Commands;
using Gateway.Application.Orders.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Application.Orders
{
   public interface IOrderFulfilmentService
    {

        Task PutOrder(PutOrderCommand putOrderCommand);

        Task<List<object>> GetDishes();

        Task<OrderDetailsDto> GetOrderDetailsById(int orderId);

    }
}
