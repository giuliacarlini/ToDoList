using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Features.v1.Database.DTOs;
using ToDoList.Features.v1.Database.EntityFramework.Data;
using ToDoList.Features.v1.Models;
using ToDoList.Features.v1.Services;

namespace ToDoList.Features.v1.Controllers
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ApiVersion("1.0")]

    public class UserController : ControllerBase
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        //URI sugerida: /api/v{n}/users/{ID}
        //Public: N�O
        //Tipo: GET
        //Return Success: { "user" : OBJECT }
        //Return Fail: { "error" : STRING }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Get(int id)
        {
            try
            {
                var userDTO = _service.GetById(id);

                if (userDTO == null)
                {
                    return NotFound( new { error = "Usu�rio n�o encontrado" });
                }
                else
                {
                    return Ok( new { user = userDTO });
                }
            }
            catch
            {
                return NotFound( new { error = "Erro ao encontrar o usu�rio." });
            }
        }

        //URI sugerida: /api/v{n}/users
        //Public: N�o
        //Tipo: POST
        //Request: { "name": STRING, "email": STRING, "login": STRING; "password": STRING}
        //Return Success: { "user" : OBJECT }
        //Return Fail: { "error" : STRING }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Post([FromBody] UserDTO UserDTO)
        {
            try
            {
                UserDTO userDTO = _service.Add(UserDTO);

                return Ok(new
                {
                    userDTO
                });
            }
            catch
            {
                return BadRequest(new { error = "Erro ao cadastrar o usu�rio." });
            }

        }

        //URI sugerida: /api/v{n}/users/{ID}
        //Public: N�o
        //Tipo: PUT
        //Request: { "name": STRING, "email": STRING, "login": STRING; "password": STRING  }
        //Return Success: { "user" : OBJECT }
        //Return Fail: { "error" : STRING }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Put(int id, [FromBody] UserDTO userDTO)
        {
            try
            {
                _service.Update(id, userDTO);

                userDTO.Id = id;

                return Ok(new
                {
                   user = userDTO
                });
            }
            catch
            {
                return BadRequest(new { error = "Erro ao alterar o usu�rio." });
            }
        }
    }
}