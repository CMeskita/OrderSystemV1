using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderSystemV1.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "RefenceProduct",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "ReferenceClient",
                startValue: 1000L);

            migrationBuilder.CreateTable(
                name: "TB_CLIENT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CLIENT_REF = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ReferenceClient"),
                    CLIENT_NAME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CLIENT_EMAIL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CLIENT_BIRTHDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PRODUCT_NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PRODUCT_REFERENCE = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR RefenceProduct"),
                    PRODUCT_PRICE = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CLIENT");

            migrationBuilder.DropTable(
                name: "TB_PRODUCT");

            migrationBuilder.DropSequence(
                name: "RefenceProduct");

            migrationBuilder.DropSequence(
                name: "ReferenceClient");
        }
    }
}
