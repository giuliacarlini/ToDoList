using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.data.migrations
{
    /// <inheritdoc />
    public partial class itemlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListItem_id",
                table: "ListItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListItem_id",
                table: "ListItem");
        }
    }
}
