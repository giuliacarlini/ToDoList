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
        [Fact]
        public void test_create_and_update_user()
        {
            var user = new User("Giulia", "giuliacarlini@gmail.com", "gcarlini", "123");

            user.Refresh("","","","321");

            Assert.True(Equals(user.Name, "Giulia"));
            Assert.True(Equals(user.Email, "giuliacarlini@gmail.com"));
            Assert.True(Equals(user.Login, "gcarlini"));
            Assert.True(Equals(user.Password, "321"));
        }
    }
}
