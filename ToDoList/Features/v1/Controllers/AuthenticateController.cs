using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Features.v1.Database.DTOs;
using ToDoList.Features.v1.Database.EntityFramework.Data;
using ToDoList.Features.v1.Models;
using ToDoList.Features.v1.Services;

namespace ToDoList.Features.v1.Controllers
{
    [Route("api/v{version:apiVersion}/authenticate")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly IUserService _userService;

        public AuthenticateController(IConfiguration configuration, IUserService service)
        {

            _configuration = configuration;

            _userService = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Auth([FromBody] Authenticate autenticacao)
        {
            try
            {
                if (autenticacao.email != null && autenticacao.password != null)
                {
                    if (_userService.Count() == 0)
                    {
                        UserDTO userDTO = new UserDTO()
                        {
                            Name = "Administrador",
                            Email = "adm@adm.com",
                            Login = "adm",
                            Password = "123"
                        };

                        _userService.Add(userDTO);

                    }

                    var userExists = _userService.GetByEmail(autenticacao.email);

                    if (userExists == null)
                        return Unauthorized(new { error = "Email e/ou senha está(ão) inválido(s)." });

                    if (userExists.Password != autenticacao.password)
                        return Unauthorized(new { error = "Email e/ou senha está(ão) inválido(s)." });

                    var _SecretJwtKey = _configuration.GetValue<string>("TokenConfigurations:SecretJwtKey");
                    var _Seconds = _configuration.GetValue<int>("TokenConfigurations:Seconds");

                    var token = JwtAuth.GenerateToken(userExists, _SecretJwtKey, _Seconds);

                    return Ok(new
                    {
                        token,
                        user = userExists
                    });
                }
                else
                {
                    return Unauthorized(new { error = "Email e/ou senha está(ão) inválido(s)." });
                }

            }
            catch
            {
                return BadRequest(new { error = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }


        [HttpPost("sso")]
        [AllowAnonymous]
        public ActionResult AuthSSO([FromBody] AuthenticateSSO autenticacaoSSO)
        {
            try
            {
                string mensagemErro = "";

                if (autenticacaoSSO.app_token != null && autenticacaoSSO.login != null)
                {
                    var userExists = _userService.GetByLogin(autenticacaoSSO.login);

                    if (userExists == null)
                        return Unauthorized(new { error = "Usuário não encontrado." });

                    var _SecretJwtKey = _configuration.GetValue<string>("TokenConfigurations:SecretJwtKey");

                    bool validado = JwtAuth.ValidateToken(
                        _SecretJwtKey, autenticacaoSSO.app_token, out mensagemErro);

                    if (validado)
                    {
                        return Ok(new
                        {
                            token = autenticacaoSSO.app_token,
                            user = userExists
                        });
                    }
                    else
                    {
                        return Unauthorized(new { error = mensagemErro });
                    }
                }
                else
                {
                    return Unauthorized(new { error = "Login e/ou token está(ão) inválido(s)." });
                }
            }
            catch
            {
                return BadRequest(new { error = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }

        }
    }
}