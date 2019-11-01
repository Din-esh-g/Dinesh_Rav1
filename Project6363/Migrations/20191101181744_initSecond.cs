using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project6363.Migrations
{
    public partial class initSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true),
                    accountNumber = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    period = table.Column<int>(nullable: false),
                    dateAndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_CustomerId",
                table: "Business",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business");
        }
    }
}
