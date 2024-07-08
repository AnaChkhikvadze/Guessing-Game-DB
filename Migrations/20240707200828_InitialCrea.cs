using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuessTheNumberDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCrea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LowerBound = table.Column<int>(type: "int", nullable: false),
                    UpperBound = table.Column<int>(type: "int", nullable: false),
                    PreviousGuess = table.Column<int>(type: "int", nullable: false),
                    IsGuessed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
