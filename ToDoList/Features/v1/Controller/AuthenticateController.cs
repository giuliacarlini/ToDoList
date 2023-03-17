using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Features.v1.Model;

namespace ToDoList.Features.v1.Controller
{
    [Route("api/v{version:apiVersion}/authenticate")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticateController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IConfiguration _configuration;

        public AuthenticateController(DataContext context, IConfiguration configuration)
        {
            _context = context;

            _configuration = configuration;
        }

        public class Autenticacao
        {
            public string? email { get; set; }
            public string? password { get; set; }
        }

        //URI sugerida: /api/v{n}/authenticate
        //Public: SIM
        //Tipo: POST
        //Request: { "login": STRING; "password": STRING }
        //Return Success: { "token": JWT, "user": OBJECT }
        //Return Fail: { "error" : STRING }

        [HttpPost]
        [AllowAnonymous] 
        public async Task<IActionResult> Auth([FromBody] Autenticacao autenticacao)
        {
            try
            {
                if (autenticacao.email != null && autenticacao.password != null) 
                {
                    var userExists = _context.Users.Where(x => x.Email.ToLower() == autenticacao.email.ToLower())
                            .FirstOrDefault();

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
            catch (Exception)
            {
                return BadRequest(new { error = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }

        public class AutenticacaoSSO
        {
            public string? login { get; set; }
            public string? app_token { get; set; }            
        }

        //URI sugerida: /api/v{n}/authenticate/sso
        //Public: SIM
        //Tipo: POST
        //Request: { "login": STRING; "app_token": STRING }
        //Return Success: { "token": JWT, "user": OBJECT }
        //Return Fail: { "error" : STRING }

        [HttpPost("sso")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthSSO([FromBody] AutenticacaoSSO autenticacaoSSO)
        {
            try
            {
                string mensagemErro = "";

                if (autenticacaoSSO.app_token != null && autenticacaoSSO.login != null)
                {               
                    var userExists = _context.Users.Where(x => x.Login.ToLower() == autenticacaoSSO.login.ToLower()).FirstOrDefault();

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
                } else
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