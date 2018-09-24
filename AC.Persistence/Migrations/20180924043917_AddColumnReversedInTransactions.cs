using Microsoft.EntityFrameworkCore.Migrations;

namespace AC.Persistence.Migrations
{
    public partial class AddColumnReversedInTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "REVERSED",
                table: "TB_TRANSACTIONS",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "REVERSED",
                table: "TB_TRANSACTIONS");
        }
    }
}
