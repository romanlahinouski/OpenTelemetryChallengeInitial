using System;
using MediatR;

namespace Gateway.Application.Guests.Commands
{
    
public class CancelRegistrationCommand : IRequest
{
    public int VisitId { get; set; }             

}

}