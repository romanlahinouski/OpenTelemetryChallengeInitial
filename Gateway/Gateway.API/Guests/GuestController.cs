using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gateway.Application.Guests.Commands;
using Microsoft.AspNetCore.Authorization;
using Gateway.Application.Guests.Queries;

namespace Gateway.Guests
{
    [Authorize(Policy ="GroupUsers")]
    [Route("api/[controller]/")]  
    [Produces("application/json")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IMediator mediator;
  

        public GuestController(IMediator mediator)
        {
            this.mediator = mediator;          
        }

        [ProducesResponseType(StatusCodes.Status201Created)]   
        [HttpPost]       
        public async Task<ActionResult> Post([FromBody] CreateGuestDto createGuestRequest)
        {       
            await mediator.Send(new CreateGuestCommand(createGuestRequest.PhoneNumber,
                createGuestRequest.FirstName,
                createGuestRequest.LastName,
                createGuestRequest.Email,
                createGuestRequest.DateOfBirth));
            return Created("",null);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("RegisterForAVisit")]
        public async Task<ActionResult> RegisterForAVisit([FromBody] RegisterGuestDto registerGuestRequest )
        {
            await mediator.Send(new RegisterGuestCommand(
                registerGuestRequest.RestaurantId,
                registerGuestRequest.Email          
                ));
        
            return Ok();         
        }  


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CancelRegistration")]
        public async  Task<ActionResult> CancelRegistration(CancelRegistrationDto cancelRegistrationRequest){
                         
            return Ok();
        }    
        

        [HttpDelete]
        [Authorize(Policy ="GroupAdmins")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]    
        public Task<ActionResult> Delete(){
            throw new NotImplementedException();

        } 



        [HttpGet]
        [Authorize(Policy ="GroupAdmins")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]    
        public async Task<ActionResult> Get(int guestsNumber){
           
           return Ok(await mediator.Send(new GetGuestsQuery(guestsNumber)));
        }
    }      
}