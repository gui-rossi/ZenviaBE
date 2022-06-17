using Microsoft.AspNetCore.Mvc;

namespace UsersWebAPI.Controllers
{
    [Controller]
    [Route("api/")]
    public class UsersController : Controller
    {
        [HttpGet("IsApiUp")]
        public bool IsApiUp()
        {
            return true;
        }
    }
}
