using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projebeycelik.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKeyToDepo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunTipi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depo");
        }
    }
}
