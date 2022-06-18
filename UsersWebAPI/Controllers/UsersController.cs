using Microsoft.AspNetCore.Mvc;
using UserBusiness.Interfaces;
using UserDomain.ViewModels;

namespace UsersWebAPI.Controllers
{
    [Controller]
    [Route("api/{controller}/")]
    public class UsersController : Controller
    {
        private readonly IUserRegisterService _service;

        public UsersController(IUserRegisterService service)
        {
            _service = service;
        }

        [HttpPost("AddUser")]
        public async Task PostUser([FromBody] UserViewModel userVM)
        {
            await _service.AddNewUser(userVM);
        }
    }
}
