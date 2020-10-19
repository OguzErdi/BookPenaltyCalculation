using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Weekends_CountryId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_PenaltyPrices_Weekends_CountryId",
                table: "PenaltyPrices");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Countries_CountryId",
                table: "Holidays",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PenaltyPrices_Countries_CountryId",
                table: "PenaltyPrices",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Countries_CountryId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_PenaltyPrices_Countries_CountryId",
                table: "PenaltyPrices");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Weekends_CountryId",
                table: "Holidays",
                column: "CountryId",
                principalTable: "Weekends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PenaltyPrices_Weekends_CountryId",
                table: "PenaltyPrices",
                column: "CountryId",
                principalTable: "Weekends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
