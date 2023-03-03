using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskCategoryToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userStatistics",
                table: "userStatistics");

            migrationBuilder.RenameTable(
                name: "userStatistics",
                newName: "UserStatistics");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TodoTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStatistics",
                table: "UserStatistics",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStatistics",
                table: "UserStatistics");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TodoTasks");

            migrationBuilder.RenameTable(
                name: "UserStatistics",
                newName: "userStatistics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userStatistics",
                table: "userStatistics",
                column: "Id");
        }
    }
}
