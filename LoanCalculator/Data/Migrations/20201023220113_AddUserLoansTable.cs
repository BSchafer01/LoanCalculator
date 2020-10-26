using Microsoft.EntityFrameworkCore.Migrations;
using System.Data.SqlTypes;

namespace LoanCalculator.Data.Migrations
{
    public partial class AddUserLoansTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLoans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanName = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LoanAmount = table.Column<decimal>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    AdditionalPrincipal = table.Column<decimal>(nullable: false),
                    LoanTerm = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLoans_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLoans_UserId",
                table: "UserLoans",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoans");
        }
    }
}
