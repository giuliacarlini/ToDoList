using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ToDoList.API;
using ToDoList.Domain.Handlers;
using ToDoList.Infrastructure.Repositories;
using Xunit;
using System.Security.Cryptography;
using System.Text.Json;
using System.Security.Claims;

namespace ToDoList.Tests.Handlers
{
    public class AuthenticateHandlerTest
    {
        private readonly UserRepository _userRepository;

        private static RandomNumberGenerator _rgn = RandomNumberGenerator.Create();

        public string chave;

        public AuthenticateHandlerTest()
        {
            _userRepository = new UserRepository(new Configuration().ConfigureContext());

        }

        [Fact]
        public void Test_authenticate_success()
        {


        }

    }
}
