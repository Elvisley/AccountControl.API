using Microsoft.EntityFrameworkCore.Migrations;

namespace AC.Persistence.Migrations
{
    public partial class ACAlterTransactionColumnNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_DESTINATION_ID",
                table: "TB_TRANSACTIONS");

            migrationBuilder.DropIndex(
                name: "UNIQUE_TRANSACTION_CODE",
                table: "TB_TRANSACTIONS");

            migrationBuilder.AlterColumn<string>(
                name: "TRANSACTION_CODE",
                table: "TB_TRANSACTIONS",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ACCOUNT_DESTINATION_ID",
                table: "TB_TRANSACTIONS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_DESTINATION_ID",
                table: "TB_TRANSACTIONS",
                column: "ACCOUNT_DESTINATION_ID",
                unique: true,
                filter: "[ACCOUNT_DESTINATION_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UNIQUE_TRANSACTION_CODE",
                table: "TB_TRANSACTIONS",
                column: "TRANSACTION_CODE",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_DESTINATION_ID",
                table: "TB_TRANSACTIONS");

            migrationBuilder.DropIndex(
                name: "UNIQUE_TRANSACTION_CODE",
                table: "TB_TRANSACTIONS");

            migrationBuilder.AlterColumn<string>(
                name: "TRANSACTION_CODE",
                table: "TB_TRANSACTIONS",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "ACCOUNT_DESTINATION_ID",
                table: "TB_TRANSACTIONS",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_DESTINATION_ID",
                table: "TB_TRANSACTIONS",
                column: "ACCOUNT_DESTINATION_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNIQUE_TRANSACTION_CODE",
                table: "TB_TRANSACTIONS",
                column: "TRANSACTION_CODE",
                unique: true,
                filter: "[TRANSACTION_CODE] IS NOT NULL");
        }
    }
}
