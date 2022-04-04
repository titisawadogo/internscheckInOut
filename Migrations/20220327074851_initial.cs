using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace internscheckInOut.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckInOuts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    internName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    positionId = table.Column<int>(type: "int", nullable: false),
                    teamId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    checkinTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    checkoutTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInOuts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckInOuts");
        }
    }
}
