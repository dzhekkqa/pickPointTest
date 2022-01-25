using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pickPointTest.Data.Migrations
{
    public partial class AddedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    price = table.Column<decimal>(nullable: false),
                    postamatNumber = table.Column<string>(nullable: true),
                    customerPhoneNumber = table.Column<string>(nullable: true),
                    customeFio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderNumber);
                });

            migrationBuilder.CreateTable(
                name: "Postamats",
                columns: table => new
                {
                    pNumber = table.Column<string>(nullable: false),
                    pAddress = table.Column<string>(nullable: true),
                    pStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postamats", x => x.pNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Postamats");
        }
    }
}
