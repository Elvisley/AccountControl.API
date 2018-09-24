using Microsoft.EntityFrameworkCore.Migrations;

namespace AC.Persistence.Migrations
{
    public partial class ACAlterTransactionRevision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_DESTINATION_ID",
                table: "TB_TRANSACTIONS");

            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_SOURCE_ID",
                table: "TB_TRANSACTIONS");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_DESTINATION_ID",
                table: "TB_TRANSACTIONS",
                column: "ACCOUNT_DESTINATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_SOURCE_ID",
                table: "TB_TRANSACTIONS",
                column: "ACCOUNT_SOURCE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_DESTINATION_ID",
                table: "TB_TRANSACTIONS");

            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_SOURCE_ID",
                table: "TB_TRANSACTIONS");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_DESTINATION_ID",
                table: "TB_TRANSACTIONS",
                column: "ACCOUNT_DESTINATION_ID",
                unique: true,
                filter: "[ACCOUNT_DESTINATION_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_SOURCE_ID",
                table: "TB_TRANSACTIONS",
                column: "ACCOUNT_SOURCE_ID",
                unique: true,
                filter: "[ACCOUNT_SOURCE_ID] IS NOT NULL");
        }
    }
}
