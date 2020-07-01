using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Estore.DataAccess.Migrations
{
    public partial class deleted_city_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderCities_OrderCityId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderCities");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderCityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCityId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderCityId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderCities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderCityId",
                table: "Orders",
                column: "OrderCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderCities_OrderCityId",
                table: "Orders",
                column: "OrderCityId",
                principalTable: "OrderCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
