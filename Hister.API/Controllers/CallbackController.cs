using Microsoft.AspNetCore.Mvc;

namespace Hister.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallbackController : ControllerBase
    {
        [HttpGet]
        public void Get(string code, string state)
        {
            //call spotify api/token with code
        }
    }
}
