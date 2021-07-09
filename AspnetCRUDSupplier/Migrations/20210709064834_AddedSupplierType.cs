using Microsoft.EntityFrameworkCore.Migrations;

namespace AspnetCRUDSupplier.Migrations
{
    public partial class AddedSupplierType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierType",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierType",
                table: "Supplier");
        }
    }
}
