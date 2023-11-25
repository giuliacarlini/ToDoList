using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Repositories;
using Xunit;

namespace ToDoList.Tests.Entities
{
    public class ListItemTests
    {
        public static readonly object[][] CorrectData =
        {
            new object[]
            {
                "Item da Lista 1",
                "Descrição da Lista 1",
                1,
                1,
                true,
                0
            },
            new object[]
            {
                "Item da Lista 2",
                "Descrição da Lista 2",
                1,
                1,
                true,
                0
            },
            new object[]
            {
                "Item da Lista 3",
                "Descrição da Lista 3",
                1,
                1,
                true,
                0
            },
            new object[]
            {
                "Lista",
                "Descrição",
                1,
                1,
                false,
                2

            },
            new object[]
            {
                "                              ",
                "Descrição",
                1,
                1,
                false,
                2
            },
            new object[]
            {
                "Item da Lista 3",
                "Descrição da Lista 3",
                -1,
                -1,
                false,
                2
            },
            new object[]
            {
                "Item da Lista 3",
                "Descrição                      ",
                -1,
                -1,
                false,
                3

            },
        };


        [Theory, MemberData(nameof(CorrectData))]
        public void Test_entity_listItem_create(string title, string description, int idUser, int idList, bool valid, int qtdErrors)
        {
            var listItem = new ListItem(title, description, idUser, idList);

            listItem.Validate();

            Assert.True(listItem.Notifications.Count == qtdErrors, string.Concat("Erros esperados:",qtdErrors," - Erros ocorridos:", listItem.Notifications.Count));
            Assert.True(listItem.IsValid == valid);
        }

        [Fact]
        public void Test_entity_listItem_update()
        {
            var title = "Teste de Titulo";
            var description = "Teste de Descrição";

            var listItem = new ListItem(title, description, 1, 1);
            listItem.Validate();

            var titleUpdate = "Descricao teste";

            listItem.Refresh("", titleUpdate);

            Assert.True(listItem.Title != titleUpdate);

            listItem.Refresh(titleUpdate, "");

            Assert.True(listItem.Title == titleUpdate);
        }
    }
}
