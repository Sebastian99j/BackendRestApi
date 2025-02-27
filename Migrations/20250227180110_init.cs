using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendRestApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ai_Identifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingTypeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Reps = table.Column<int>(type: "int", nullable: true),
                    Sets = table.Column<int>(type: "int", nullable: true),
                    RPE = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateOnly>(type: "date", nullable: true),
                    BreaksInSeconds = table.Column<int>(type: "int", nullable: true),
                    Trained = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingSeries_TrainingType_TrainingTypeId",
                        column: x => x.TrainingTypeId,
                        principalTable: "TrainingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingSeries_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSeries_TrainingTypeId",
                table: "TrainingSeries",
                column: "TrainingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSeries_UserId",
                table: "TrainingSeries",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentication");

            migrationBuilder.DropTable(
                name: "TrainingSeries");

            migrationBuilder.DropTable(
                name: "TrainingType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
