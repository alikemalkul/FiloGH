using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiloGH.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductVariant_Finalized : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_StockUnitOfMeasures_StockUnitId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_UnitOfMeasures_BaseUnitId",
                table: "ProductVariants");

            migrationBuilder.DropTable(
                name: "StockUnitOfMeasures");

            migrationBuilder.DropIndex(
                name: "IX_Products_StockUnitId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetalColor",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "StockUnitId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "BaseUnitId",
                table: "ProductVariants",
                newName: "StockUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariants_BaseUnitId",
                table: "ProductVariants",
                newName: "IX_ProductVariants_StockUnitId");

            migrationBuilder.AddColumn<byte>(
                name: "DecimalPlaces",
                table: "UnitOfMeasures",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "ProductVariants",
                type: "decimal(6,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "MetalPurityId",
                table: "ProductVariants",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "ProductVariants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsWeightBasedPricing",
                table: "ProductVariants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "ProductVariants",
                type: "decimal(6,1)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MetalColorId",
                table: "ProductVariants",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StandardCost",
                table: "ProductVariants",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "StandardWeight",
                table: "ProductVariants",
                type: "decimal(10,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                table: "ProductVariants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MetalColor",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HexCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetalColor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_MetalColorId",
                table: "ProductVariants",
                column: "MetalColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_MetalColor_MetalColorId",
                table: "ProductVariants",
                column: "MetalColorId",
                principalTable: "MetalColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_UnitOfMeasures_StockUnitId",
                table: "ProductVariants",
                column: "StockUnitId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_MetalColor_MetalColorId",
                table: "ProductVariants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_UnitOfMeasures_StockUnitId",
                table: "ProductVariants");

            migrationBuilder.DropTable(
                name: "MetalColor");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_MetalColorId",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "DecimalPlaces",
                table: "UnitOfMeasures");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "IsWeightBasedPricing",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "MetalColorId",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "StandardCost",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "StandardWeight",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                table: "ProductVariants");

            migrationBuilder.RenameColumn(
                name: "StockUnitId",
                table: "ProductVariants",
                newName: "BaseUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariants_StockUnitId",
                table: "ProductVariants",
                newName: "IX_ProductVariants_BaseUnitId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "ProductVariants",
                type: "decimal(4,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "MetalPurityId",
                table: "ProductVariants",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetalColor",
                table: "ProductVariants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "StockUnitId",
                table: "Products",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "StockUnitOfMeasures",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DecimalPlaces = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockUnitOfMeasures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockUnitId",
                table: "Products",
                column: "StockUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StockUnitOfMeasures_StockUnitId",
                table: "Products",
                column: "StockUnitId",
                principalTable: "StockUnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_UnitOfMeasures_BaseUnitId",
                table: "ProductVariants",
                column: "BaseUnitId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
