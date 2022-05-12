using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Application.Restaurants;
using RestaurantManagement.Application.Restaurants.Commands;
using RestaurantManagement.Application.Restaurants.Queries;


namespace RestaurantManagement.Restaurants
{
    [Route("api/Restaurant/{RestaurantId}/Administration")]
    [Route("api/Restaurant/")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator mediator;

        [FromRoute]
        public int RestaurantId { get; set; }

        public RestaurantController(IMediator mediator)
        {
            this.mediator = mediator;
        }
       
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] RegisterRestaurantRequest request)
        {          
            await mediator.Send(new CreateRestaurantCommand
            {
                Name = request.RestaurantName,
                MaxNumberOfGuests = request.MaxNumberOfGuests,
                Street = request.Street,
                City = request.City,
                Cuisine = request.Cuisine
            });
            return Created(string.Empty, null);
        }

        [HttpGet("Capacity")]
        [ProducesResponseType(typeof(int),StatusCodes.Status200OK)]
        public async Task<ActionResult> GetRemainingCapacity()
        {
            int capacity =
                await mediator.Send(new GetRestaurantRemainingCapacityQuery { RestaurantId = RestaurantId });

            return Ok(capacity);
        }

    
        [HttpPost("VisitRegistraion")]
        public async Task<ActionResult> RegisterGuest([FromBody] RegisterGuestRequest registerGuestRequest)
        {
            try
            {

             await mediator.Send(new VisitRegistrationCommand(
                 registerGuestRequest.RestaurantId,
                 registerGuestRequest.UserId));

            }
            catch (NoUserInTheSystemException ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }


            return Ok();
        }

        [HttpPost("UnregisterGuest")]
        public Task<ActionResult> UnregisterGuest(int guestId)
        {
            return Task.FromResult<ActionResult>(Ok());
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public Task<ActionResult> Get()
        {
            return Task.FromResult<ActionResult>(Ok());
        }
        
    }
}