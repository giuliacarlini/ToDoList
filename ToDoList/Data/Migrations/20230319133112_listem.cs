using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.data.Migrations
{
    /// <inheritdoc />
    public partial class listem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ListItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ListItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "ListItemId",
                table: "ListItem",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_ListItemId",
                table: "ListItem",
                column: "ListItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_ListItem_ListItemId",
                table: "ListItem",
                column: "ListItemId",
                principalTable: "ListItem",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_ListItem_ListItemId",
                table: "ListItem");

            migrationBuilder.DropIndex(
                name: "IX_ListItem_ListItemId",
                table: "ListItem");

            migrationBuilder.DropColumn(
                name: "ListItemId",
                table: "ListItem");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ListItem",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ListItem",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
