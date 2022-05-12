using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using RestaurantManagement.Restaurants.Protos;
using MediatR;
using RestaurantManagement.Application.Restaurants.Commands;

namespace RestaurantManagement.Restaurants
{
    public class GuestRegistrationGRPCService : RestaurantManagementService.RestaurantManagementServiceBase
    {
        private readonly IMediator mediator;

        public GuestRegistrationGRPCService(IMediator mediator)

        {
            this.mediator = mediator;
        }


        public override async Task<Empty> RegisterGuest(GuestRegistrationRequest request, ServerCallContext context)
        {
           
                await mediator.Send(new VisitRegistrationCommand(
                   request.RestaurantId,
                   request.GuestId
                   ));
          

            return new Empty();
        }
    }
}