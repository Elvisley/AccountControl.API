using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AC.Persistence.Migrations
{
    public partial class ACTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MONEY",
                table: "TB_ACCOUNTS",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.CreateTable(
                name: "TB_TRANSACTIONS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TRANSACTION_CODE = table.Column<string>(maxLength: 100, nullable: true),
                    CREATED = table.Column<DateTime>(nullable: false),
                    MONEY = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TRANSACTION_TYPE_ID = table.Column<int>(nullable: false),
                    ACCOUNT_DESTINATION_ID = table.Column<int>(nullable: false),
                    ACCOUNT_SOURCE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TRANSACTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_TRANSACTIONS_TB_ACCOUNTS_ACCOUNT_DESTINATION_ID",
                        column: x => x.ACCOUNT_DESTINATION_ID,
                        principalTable: "TB_ACCOUNTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_TRANSACTIONS_TB_ACCOUNTS_ACCOUNT_SOURCE_ID",
                        column: x => x.ACCOUNT_SOURCE_ID,
                        principalTable: "TB_ACCOUNTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_TRANSACTIONS_TB_TRANSACTION_TYPE_TRANSACTION_TYPE_ID",
                        column: x => x.TRANSACTION_TYPE_ID,
                        principalTable: "TB_TRANSACTION_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_DESTINATION_ID",
                table: "TB_TRANSACTIONS",
                column: "ACCOUNT_DESTINATION_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_ACCOUNT_SOURCE_ID",
                table: "TB_TRANSACTIONS",
                column: "ACCOUNT_SOURCE_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNIQUE_TRANSACTION_CODE",
                table: "TB_TRANSACTIONS",
                column: "TRANSACTION_CODE",
                unique: true,
                filter: "[TRANSACTION_CODE] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTIONS_TRANSACTION_TYPE_ID",
                table: "TB_TRANSACTIONS",
                column: "TRANSACTION_TYPE_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TRANSACTIONS");

            migrationBuilder.AlterColumn<decimal>(
                name: "MONEY",
                table: "TB_ACCOUNTS",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");
        }
    }
}
