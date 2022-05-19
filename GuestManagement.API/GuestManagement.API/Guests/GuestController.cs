using AutoMapper;
using GuestManagement.Application.Guests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Http;
using GuestManagement.Application.Guests.Queries;
using GuestManagement.API.Guests.Binders;
using GuestManagement.Application.Guests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuestManagement.API.Guests
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public GuestController(
            IMediator mediator,
            IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }


        // GET: api/<GuestController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IEnumerable<Guest>> Get(int numberOfGuests)
        {
           return await mediator.Send<IEnumerable<Guest>>(new GetAllGuestsQuery(numberOfGuests));
        }

        // GET api/<GuestController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpGet("{email}")]
        public async Task<ActionResult<Guest>> Get([FromRoute] string email)
        {
            var guest = await mediator.Send<Guest>(new GetGuestByEmailQuery { Email = email });

            if (guest == null)
                return NotFound(email);

            return Ok(guest);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Guest>> Get([FromRoute] Guid id)
        {
            // var guest = await mediator.Send<Guest>(new GetGuestByEmailQuery { Email = email });

            // if (guest == null)
            //     return NotFound(email);

            return Ok();
        }

        // POST api/<GuestController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RegisterGuestRequest registerGuestDto)
        {
            await mediator.Send(mapper.Map<CreateGuestCommand>(registerGuestDto));

            return Created($"/api/Guest/{registerGuestDto.Email}", null);
        }

        [HttpPost("VisitRegistration")]
        public async Task<ActionResult> RegisterForVisit([FromBody] VisitRegistrationDto visitRegistrationDto)
        {
            await mediator.Send(mapper.Map<VisitRegistrationCommand>(visitRegistrationDto));

            return Ok();
        }


        // PUT api/<GuestController>/email
        [HttpPut("{email}")]
        public void Put(string value, PutGuestDto putGuestDto)
        {

        }

        // DELETE api/<GuestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        //get the existing guest from db
        //patch the existing guest
        //check the validity 
        //save
        [HttpPatch("{email}")]
        public async Task<ActionResult> Patch(JsonPatchDocument<PatchGuestDto> patchDocument, [FromRoute] string email)
        {

            PatchGuestDto patchGuestDto = new PatchGuestDto();

            patchDocument.ApplyTo(patchGuestDto, ModelState);

            await mediator.Send(new UpdateGuestCommand(new Guest
            {
                Email = patchGuestDto.Email,
                PhoneNumber = patchGuestDto.PhoneNumber,
                FirstName = patchGuestDto.FirstName,
                LastName = patchGuestDto.LastName
            }, email
            ));

            return NoContent();
        }
    }
}
