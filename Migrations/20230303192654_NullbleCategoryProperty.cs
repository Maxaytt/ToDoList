using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    /// <inheritdoc />
    public partial class NullbleCategoryProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_TaskCategories_CategoryId",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TodoTasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_TaskCategories_CategoryId",
                table: "TodoTasks",
                column: "CategoryId",
                principalTable: "TaskCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_TaskCategories_CategoryId",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TodoTasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_TaskCategories_CategoryId",
                table: "TodoTasks",
                column: "CategoryId",
                principalTable: "TaskCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
