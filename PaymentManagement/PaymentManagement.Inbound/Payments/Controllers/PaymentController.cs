using Microsoft.AspNetCore.Mvc;

namespace PaymentManagement.Inbound.Payments.Controllers
{  
    [Route("api/[controller]/")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
      
        
        
        [HttpPost]
        public Task<ActionResult> Create(){
            return Task.FromResult<ActionResult>(Ok());
        }

    }
}