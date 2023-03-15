using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    
    public class UsersController : ControllerBase
    {

        [HttpGet] 
        [MapToApiVersion("1.0")]
        public DateTime GetV1_0()
        {
            return DateTime.Now;
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        public DateTime GetV1_1()
        {
            return DateTime.Now.AddYears(5);
        }
    }
}