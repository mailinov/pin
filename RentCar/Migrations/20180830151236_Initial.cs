using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RentCar.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarkaID",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MarkaID",
                table: "Cars",
                column: "MarkaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Marka_MarkaID",
                table: "Cars",
                column: "MarkaID",
                principalTable: "Marka",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Marka_MarkaID",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropIndex(
                name: "IX_Cars_MarkaID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MarkaID",
                table: "Cars");
        }
    }
}
