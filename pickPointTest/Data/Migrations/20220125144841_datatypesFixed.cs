using Microsoft.EntityFrameworkCore.Migrations;

namespace pickPointTest.Data.Migrations
{
    public partial class datatypesFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "customeFio",
                table: "Orders",
                newName: "customerFio");

            migrationBuilder.AddColumn<string>(
                name: "orderList",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orderStatus",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderList",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "orderStatus",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "customerFio",
                table: "Orders",
                newName: "customeFio");
        }
    }
}
