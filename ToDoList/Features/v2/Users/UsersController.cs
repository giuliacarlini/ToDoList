using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers.v2
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ApiVersion("2.0")]
    
    public class UsersController : ControllerBase
    {

        [HttpGet] 
        [MapToApiVersion("2.0")]
        public DateTime GetV2_0()
        {
            return DateTime.Now.AddDays(5);
        }

    }
}