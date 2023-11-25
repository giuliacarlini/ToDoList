using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;
using Xunit;

namespace ToDoList.Tests.Entities
{
    public class UserTests
    {
        public static readonly object[][] CorrectData =
        {
            new object[]
            {
                "Giulia Carlini",
                "giuliacarlini@gmail.com",
                "giuliacarlini",
                "123456780",
                true
            },
            new object[]
            {
                "Giulia Carlini",
                "giuliacarlini@gmail.com",
                "  gcarlini  ",
                "123456780",
                false
            },

            new object[]
            {
                "Maria Aparecida das Neves dos Santos de Almeida Maria Aparecida das Neves dos Santos de Almeida Teste Teste",
                "maria@gmail.com",
                "maria",
                "123",
                false
            },
            new object[]
            {
                "Maria Aparecida das Neves",
                "mariatestetestetestetestetstetestetestetestetestetestetstetestetestetesteteste@gmail.com",
                "maria",
                "123",
                false
            },
            new object[]
            {
                "Maria Aparecida das Neves",
                "maria@gmail.com",
                "mariatestetestetestetestetstetestetestetestetestetestetstetestetestetestetestetestetesteteste",
                "123",
                false
            },
            new object[]
            {
                "Maria Aparecida das Neves",
                "maria@gmail.com",
                "maria",
                "1234567890123456789012345679012345678910",
                false
            },
            new object[]
            {
                "Maria Aparecida das Neves",
                "      ",
                "maria",
                "123",
                false
            },
            new object[]
            {
                "Maria Aparecida das Neves dos Santos de Almeida",
                "maria@gmail.com",
                "    ",
                "123",
                false
            },
            new object[]
            {
                "Maria Aparecida das Neves dos Santos de Almeida",
                "maria@gmail.com",
                "maria",
                "   ",
                false
            },
            new object[]
            {
                "",
                "",
                "",
                "",
                false
            },
        };

        [Theory, MemberData(nameof(CorrectData))]
        public void test_entity_user_creating_user(string nome, string email, string login, string password, bool correct)
        {
            var user = new User(nome, email, login, password);
            Assert.True(user.IsValid == correct);
        }

        [Fact]
        public void test_entity_user_create_and_update()
        {
            var name = "Giulia Carlini";
            var email = "giuliacarlini@gmail.com";
            var login = "giuliacarlini";
            var password = "12345678";

            var user = new User(name, email, login, password);

            Assert.True(user.IsValid);

            var newPassword = "123";

            user.Refresh("","","", newPassword);

            Assert.False(user.IsValid);

            newPassword = "876543210";

            user.Refresh("", "", "", newPassword);

            Assert.True(user.IsValid);

            Assert.True(Equals(user.Name, name));
            Assert.True(Equals(user.Email, email));
            Assert.True(Equals(user.Login, login));
            Assert.True(Equals(user.Password, newPassword));
        }
    }
}
