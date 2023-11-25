using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;
using Xunit;

namespace ToDoList.Tests.Entities
{
    public class ListTests
    {
        public static readonly object[][] CorrectData =
        {
            new object[]
            {
                "Teste de Lista",
                1,
                true
            },
            new object[]
            {
                "                     ",
                1,
                false
            },
            new object[]
            {
                "   ",
                0,
                false
            },
        };

        [Theory, MemberData(nameof(CorrectData))]
        public void test_list_entity_create_sucess(string title, int idUser, bool valid)
        {
            var list = new List(title, idUser);

            Assert.True(list.IsValid == valid);
        }
    }
}
