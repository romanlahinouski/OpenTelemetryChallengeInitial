using Microsoft.AspNetCore.Mvc;

namespace Gateway.API
{
    public class DefaultController : ControllerBase
    {
        
        public RedirectResult Swagger(){
            return Redirect("/swagger/");
        }
    }
}