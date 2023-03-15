using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUsuarioController")]
        public void Get()
        {

        }
    }
}