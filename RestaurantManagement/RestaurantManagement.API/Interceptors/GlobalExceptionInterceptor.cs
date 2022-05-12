using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.AspNetCore.Http;
using RestaurantManagement.Application.Restaurants.Commands;
using System;
using System.Threading.Tasks;

namespace RestaurantManagement.API.Interceptors
{
    public class GlobalExceptionInterceptor : Interceptor
    {


        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, 
            ServerCallContext context, 
            UnaryServerMethod<TRequest, TResponse> continuation)             
        {
            try
            {
                var response = await continuation(request, context);
           
                return response;
            }
            catch (Exception ex)
            {
          
                Status status;

                switch (ex)
                {
                    case NoRestaurantInTheSystemException noRestExc:
                      status  = new Status(StatusCode.NotFound, noRestExc.Message);
                        break;
                    case NoUserInTheSystemException noUserExc:
                        status = new Status(StatusCode.NotFound, noUserExc.Message);
                        break;
                    default:
                        status = new Status(StatusCode.Unknown, ex.Message);
                        break;
                 }
                
                throw new RpcException(status);
            }
        }
    }
  
}
