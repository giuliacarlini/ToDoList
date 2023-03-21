using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Features.v1.Database.DTOs;
using ToDoList.Features.v1.Services;

namespace ToDoList.Features.v1.Controllers
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ApiVersion("1.0")]

    public class UserController : ControllerBase
    {

        private readonly IUserService _serviceUser;

        public UserController(IUserService service)
        {
            _serviceUser = service;
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Get(int id)
        {
            try
            {
                var userDTO = _serviceUser.GetById(id);

                if (userDTO == null)
                {
                    return NotFound( new { error = "Usuário não encontrado" });
                }
                else
                {
                    return Ok( new { user = userDTO });
                }
            }
            catch
            {
                return NotFound( new { error = "Erro ao encontrar o usuário." });
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Post([FromBody] UserDTO UserDTO)
        {
            try
            {
                UserDTO userDTO = _serviceUser.Add(UserDTO);

                return Ok( new { user = userDTO });
            }
            catch
            {
                return BadRequest(new { error = "Erro ao cadastrar o usuário." });
            }

        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Put(int id, [FromBody] UserDTO userDTO)
        {
            try
            {
                _serviceUser.Update(id, userDTO);

                userDTO.Id = id;

                return Ok( new { user = userDTO });
            }
            catch
            {
                return BadRequest( new { error = "Erro ao alterar o usuário." });
            }
        }
    }
}