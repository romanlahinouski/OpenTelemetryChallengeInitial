using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway.Infrastructure.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Users
{
    [Authorize]
    [Route("api/Users/[action]/")]
    public class UsersController : ControllerBase 
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserRepository userRepository;

        public UsersController(UserManager<User> userManager, 
        SignInManager<User> signInManager,
        IUserRepository userRepository
        )
    {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userRepository = userRepository;
        }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Register([FromBody] RegisterDto userRegisterRequest){

        User user = new User(){UserName = userRegisterRequest.Email, Email = userRegisterRequest.Email};

        var result = await userManager.CreateAsync(user, userRegisterRequest.Password);

        if(!result.Succeeded){
           return BadRequest(result.Errors);           
        }
        
        return Ok();
        }   

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> SignIn([FromBody] SignInDto signInDto){
      
        var user = await userManager.FindByEmailAsync(signInDto.Email);
        
        if(user == null)
          return NotFound();
        
        var result = await signInManager.PasswordSignInAsync(user, signInDto.Password,true,false);

        if(result.Succeeded)
           return Ok();

      return Unauthorized();
    }

      [HttpGet]
      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      public Task<dynamic> GetAll([FromQuery] int numberOfUsers)
      {     
        if(numberOfUsers > 1000)
        {
          numberOfUsers = 1000;
        }

        return  Task.FromResult<dynamic>(userRepository.GetAll(numberOfUsers).Select(x => x.Email));
        }     
    }  
}
