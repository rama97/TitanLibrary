using Database.Model;
using Helpers;
using Logic;
using Logic.Model;
using Logic.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace TitanLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet(Name = "LogIn")]
        public async Task<IActionResult> Get()
        {
            var result =  await userService.LogInAsync();
            return new OkObjectResult(new Response<LogInResponse>
            {
                Data = result
            }) ;
        }
    }
}
