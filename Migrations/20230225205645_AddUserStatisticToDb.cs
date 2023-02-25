using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    /// <inheritdoc />
    public partial class AddUserStatisticToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TasksCount = table.Column<int>(type: "int", nullable: false),
                    OverdueTasksCount = table.Column<int>(type: "int", nullable: false),
                    TimelyCompletedTasksCount = table.Column<int>(type: "int", nullable: false),
                    DeleteTasksCount = table.Column<int>(type: "int", nullable: false),
                    AvgExecutionTime = table.Column<float>(type: "real", nullable: false),
                    AvgDelayTime = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userStatistics", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userStatistics");
        }
    }
}
