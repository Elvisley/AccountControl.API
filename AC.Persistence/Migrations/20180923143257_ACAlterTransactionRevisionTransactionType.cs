using Microsoft.EntityFrameworkCore.Migrations;

namespace AC.Persistence.Migrations
{
    public partial class ACAlterTransactionRevisionTransactionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTIONS_TRANSACTION_TYPE_ID",
                table: "TB_TRANSACTIONS");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_TRANSACTION_TYPE_ID",
                table: "TB_TRANSACTIONS",
                column: "TRANSACTION_TYPE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTIONS_TRANSACTION_TYPE_ID",
                table: "TB_TRANSACTIONS");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_TRANSACTION_TYPE_ID",
                table: "TB_TRANSACTIONS",
                column: "TRANSACTION_TYPE_ID",
                unique: true);
        }
    }
}
