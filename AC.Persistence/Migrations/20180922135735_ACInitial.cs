using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AC.Persistence.Migrations
{
    public partial class ACInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PERSONS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DOCUMENT = table.Column<string>(nullable: false),
                    PERSON_TYPE = table.Column<string>(nullable: false),
                    FANTASY_NAME = table.Column<string>(nullable: true),
                    SOCIAL_REASON = table.Column<string>(nullable: true),
                    FULL_NAME = table.Column<string>(nullable: true),
                    BIRTH = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_STATUS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_STATUS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_ACCOUNTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    CREATED = table.Column<DateTime>(nullable: false),
                    MONEY = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MASTER = table.Column<bool>(nullable: false, defaultValue: false),
                    PERSON_ID = table.Column<int>(nullable: false),
                    STATUS_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ACCOUNTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_ACCOUNTS_TB_PERSONS_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "TB_PERSONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ACCOUNTS_TB_STATUS_STATUS_ID",
                        column: x => x.STATUS_ID,
                        principalTable: "TB_STATUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CHILDREN_ACCOUNTS",
                columns: table => new
                {
                    CHILDREN_ACCOUNT_ID = table.Column<int>(nullable: false),
                    PARENT_ACCOUNT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CHILDREN_ACCOUNTS", x => new { x.PARENT_ACCOUNT_ID, x.CHILDREN_ACCOUNT_ID });
                    table.ForeignKey(
                        name: "FK_TB_CHILDREN_ACCOUNTS_TB_ACCOUNTS_CHILDREN_ACCOUNT_ID",
                        column: x => x.CHILDREN_ACCOUNT_ID,
                        principalTable: "TB_ACCOUNTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CHILDREN_ACCOUNTS_TB_ACCOUNTS_PARENT_ACCOUNT_ID",
                        column: x => x.PARENT_ACCOUNT_ID,
                        principalTable: "TB_ACCOUNTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ACCOUNTS_PERSON_ID",
                table: "TB_ACCOUNTS",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ACCOUNTS_STATUS_ID",
                table: "TB_ACCOUNTS",
                column: "STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CHILDREN_ACCOUNTS_CHILDREN_ACCOUNT_ID",
                table: "TB_CHILDREN_ACCOUNTS",
                column: "CHILDREN_ACCOUNT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CHILDREN_ACCOUNTS");

            migrationBuilder.DropTable(
                name: "TB_ACCOUNTS");

            migrationBuilder.DropTable(
                name: "TB_PERSONS");

            migrationBuilder.DropTable(
                name: "TB_STATUS");
        }
    }
}
