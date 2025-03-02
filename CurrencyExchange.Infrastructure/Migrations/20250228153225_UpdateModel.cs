using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyExchange.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Currencies_Currencyid",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Currencyid",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Currencyid",
                table: "Countries");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CourrencyId",
                table: "Countries",
                column: "CourrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Currencies_CourrencyId",
                table: "Countries",
                column: "CourrencyId",
                principalTable: "Currencies",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Currencies_CourrencyId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CourrencyId",
                table: "Countries");

            migrationBuilder.AddColumn<int>(
                name: "Currencyid",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Currencyid",
                table: "Countries",
                column: "Currencyid");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Currencies_Currencyid",
                table: "Countries",
                column: "Currencyid",
                principalTable: "Currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
