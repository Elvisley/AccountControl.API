using Microsoft.EntityFrameworkCore.Migrations;

namespace AC.Persistence.Migrations
{
    public partial class ACAlterTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_SOURCE_ID",
                table: "TB_TRANSACTIONS");

            migrationBuilder.AlterColumn<int>(
                name: "ACCOUNT_SOURCE_ID",
                table: "TB_TRANSACTIONS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_SOURCE_ID",
                table: "TB_TRANSACTIONS",
                column: "ACCOUNT_SOURCE_ID",
                unique: true,
                filter: "[ACCOUNT_SOURCE_ID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_SOURCE_ID",
                table: "TB_TRANSACTIONS");

            migrationBuilder.AlterColumn<int>(
                name: "ACCOUNT_SOURCE_ID",
                table: "TB_TRANSACTIONS",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_SOURCE_ID",
                table: "TB_TRANSACTIONS",
                column: "ACCOUNT_SOURCE_ID",
                unique: true);
        }
    }
}
