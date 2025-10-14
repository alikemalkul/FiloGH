using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiloGH.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUomRelationships1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FinancialStatementCategory = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BOMCostTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AffectsMetalInventory = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMCostTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BOMTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TrackingUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    IsSystemDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsRateTracked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMetalAccountTransactionTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MovementSign = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMetalAccountTransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyMetalRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UsdRate = table.Column<decimal>(type: "decimal(9,4)", nullable: false),
                    TryRate = table.Column<decimal>(type: "decimal(9,4)", nullable: false),
                    GoldBuyRate = table.Column<decimal>(type: "decimal(9,4)", nullable: false),
                    SilverBuyRate = table.Column<decimal>(type: "decimal(9,4)", nullable: false),
                    PlatinumBuyRate = table.Column<decimal>(type: "decimal(9,4)", nullable: false),
                    PalladiumBuyRate = table.Column<decimal>(type: "decimal(9,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMetalRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SortOrder = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTransactionTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MovementSign = table.Column<short>(type: "smallint", nullable: false),
                    AffectsCost = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceStatuses",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    IsLegalSubmission = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Karats",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fineness = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationDefinitions",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RequiresWorkCenter = table.Column<bool>(type: "bit", nullable: false),
                    IsMetalPurityChanging = table.Column<bool>(type: "bit", nullable: false),
                    StandardDurationHours = table.Column<decimal>(type: "decimal(19,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationStatuses",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AllowTimeEntry = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderFeeAmountTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFeeAmountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineCostType",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AffectsMetalInventory = table.Column<bool>(type: "bit", nullable: false),
                    IsCost = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineCostType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineType",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MovementSign = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderPaymentStatuses",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<byte>(type: "tinyint", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPaymentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatusDefinitions",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<byte>(type: "tinyint", nullable: false),
                    AllowsChanges = table.Column<bool>(type: "bit", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTerms",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DueDateDays = table.Column<short>(type: "smallint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Module = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionOrderStatuses",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionRoutings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TotalTimeHours = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRoutings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTransactionTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsInventoryInflow = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterialTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StockMovementSign = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutingPurposes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutingPurposes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScrapTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockItemTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsTracked = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockMovementTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sign = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMovementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockUnitOfMeasures",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DecimalPlaces = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockUnitOfMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxRates",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RatePercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ValidFromDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UomTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderStatuses",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsInProduction = table.Column<bool>(type: "bit", nullable: false),
                    IsEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountCharts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ParentAccountId = table.Column<int>(type: "int", nullable: true),
                    AccountTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    IsPostingAccount = table.Column<bool>(type: "bit", nullable: false),
                    IsMetalAccount = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountCharts_AccountCharts_ParentAccountId",
                        column: x => x.ParentAccountId,
                        principalTable: "AccountCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountCharts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HasPredefinedCityNames = table.Column<bool>(type: "bit", nullable: false),
                    DefaultCurrencyId = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_DefaultCurrencyId",
                        column: x => x.DefaultCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ValidFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ValidTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsBasePriceList = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceLists_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StockUnitId = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    DesignCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrandId = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_StockUnitOfMeasures_StockUnitId",
                        column: x => x.StockUnitId,
                        principalTable: "StockUnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasures",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UomTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    BaseUnitId = table.Column<byte>(type: "tinyint", nullable: true),
                    ConversionFactor = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UomTypeId1 = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasures_UnitOfMeasures_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasures_UomTypes_UomTypeId",
                        column: x => x.UomTypeId,
                        principalTable: "UomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasures_UomTypes_UomTypeId1",
                        column: x => x.UomTypeId1,
                        principalTable: "UomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRolePermissions",
                columns: table => new
                {
                    UserRoleId = table.Column<byte>(type: "tinyint", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolePermissions", x => new { x.UserRoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserRolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRolePermissions_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderAdditionalFeeDefinitions",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DefaultAccountingAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAdditionalFeeDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAdditionalFeeDefinitions_AccountCharts_DefaultAccountingAccountId",
                        column: x => x.DefaultAccountingAccountId,
                        principalTable: "AccountCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CountryId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BOMStoneTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsPrecious = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseUnitId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMStoneTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOMStoneTypes_UnitOfMeasures_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetalTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BaseUnitId = table.Column<byte>(type: "tinyint", nullable: false),
                    IsPrecious = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetalTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetalTypes_UnitOfMeasures_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MaterialTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    UnitId = table.Column<byte>(type: "tinyint", nullable: false),
                    StandardCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsConsumable = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawMaterials_RawMaterialTypes_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "RawMaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RawMaterials_UnitOfMeasures_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetalPurities",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KaratValue = table.Column<byte>(type: "tinyint", nullable: false),
                    PurityRatio = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseMetalId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetalPurities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetalPurities_MetalTypes_BaseMetalId",
                        column: x => x.BaseMetalId,
                        principalTable: "MetalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MetalPurityId = table.Column<byte>(type: "tinyint", nullable: false),
                    MetalColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<decimal>(type: "decimal(4,1)", nullable: true),
                    BaseUnitId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_MetalPurities_MetalPurityId",
                        column: x => x.MetalPurityId,
                        principalTable: "MetalPurities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariants_UnitOfMeasures_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StockItemTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    BaseUnitId = table.Column<byte>(type: "tinyint", nullable: false),
                    IsMetalItem = table.Column<bool>(type: "bit", nullable: false),
                    MetalTypeId = table.Column<byte>(type: "tinyint", nullable: true),
                    MetalPurityId = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockItems_MetalPurities_MetalPurityId",
                        column: x => x.MetalPurityId,
                        principalTable: "MetalPurities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockItems_MetalTypes_MetalTypeId",
                        column: x => x.MetalTypeId,
                        principalTable: "MetalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockItems_StockItemTypes_StockItemTypeId",
                        column: x => x.StockItemTypeId,
                        principalTable: "StockItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockItems_UnitOfMeasures_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillOfMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RevisionNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MetalWeightNet = table.Column<decimal>(type: "decimal(8,3)", nullable: false),
                    MetalLossRatio = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    BOMTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalLeadTimeHours = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_BOMTypes_BOMTypeId",
                        column: x => x.BOMTypeId,
                        principalTable: "BOMTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SortOrder = table.Column<short>(type: "smallint", nullable: false),
                    AltText = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageTypeId = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_ImageTypes_ImageTypeId",
                        column: x => x.ImageTypeId,
                        principalTable: "ImageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImages_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionRoutingItems",
                columns: table => new
                {
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    ProductionRoutingId = table.Column<int>(type: "int", nullable: false),
                    RoutingPurposeId = table.Column<byte>(type: "tinyint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRoutingItems", x => new { x.ProductVariantId, x.ProductionRoutingId });
                    table.ForeignKey(
                        name: "FK_ProductionRoutingItems_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionRoutingItems_ProductionRoutings_ProductionRoutingId",
                        column: x => x.ProductionRoutingId,
                        principalTable: "ProductionRoutings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionRoutingItems_RoutingPurposes_RoutingPurposeId",
                        column: x => x.RoutingPurposeId,
                        principalTable: "RoutingPurposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalePricingRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceListId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Priority = table.Column<short>(type: "smallint", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: true),
                    RuleType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FixedPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CalculationValue = table.Column<decimal>(type: "decimal(10,5)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ValidFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ValidTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePricingRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalePricingRules_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalePricingRules_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasureConversions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUnitId = table.Column<byte>(type: "tinyint", nullable: false),
                    ToUnitId = table.Column<byte>(type: "tinyint", nullable: false),
                    ConversionRate = table.Column<decimal>(type: "decimal(19,8)", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasureConversions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureConversions_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureConversions_UnitOfMeasures_FromUnitId",
                        column: x => x.FromUnitId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureConversions_UnitOfMeasures_ToUnitId",
                        column: x => x.ToUnitId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockItemId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<byte>(type: "tinyint", nullable: false),
                    MetalPurityId = table.Column<byte>(type: "tinyint", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    TotalMetalWeightGross = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    TotalMetalWeightNet = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    TotalCaratWeight = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    ValuationCost = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryLevels_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLevels_MetalPurities_MetalPurityId",
                        column: x => x.MetalPurityId,
                        principalTable: "MetalPurities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLevels_StockItems_StockItemId",
                        column: x => x.StockItemId,
                        principalTable: "StockItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BOMLabors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BomId = table.Column<int>(type: "int", nullable: false),
                    LaborCostTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BillOfMaterialsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMLabors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOMLabors_BOMCostTypes_LaborCostTypeId",
                        column: x => x.LaborCostTypeId,
                        principalTable: "BOMCostTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BOMLabors_BillOfMaterials_BillOfMaterialsId",
                        column: x => x.BillOfMaterialsId,
                        principalTable: "BillOfMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BOMLabors_BillOfMaterials_BomId",
                        column: x => x.BomId,
                        principalTable: "BillOfMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BOMStones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BomId = table.Column<int>(type: "int", nullable: false),
                    StoneTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    StoneSize = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    CaratTotal = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    CostPerCarat = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMStones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOMStones_BOMStoneTypes_StoneTypeId",
                        column: x => x.StoneTypeId,
                        principalTable: "BOMStoneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BOMStones_BillOfMaterials_BomId",
                        column: x => x.BomId,
                        principalTable: "BillOfMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountingJournalEntries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EntryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false),
                    ReferenceDocumentId = table.Column<int>(type: "int", nullable: true),
                    ReferenceDocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingJournalEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountingJournalEntryLines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryId = table.Column<long>(type: "bigint", nullable: false),
                    LineNumber = table.Column<short>(type: "smallint", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BaseCurrencyDebit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BaseCurrencyCredit = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingJournalEntryLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountingJournalEntryLines_AccountCharts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountingJournalEntryLines_AccountingJournalEntries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "AccountingJournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountingJournalEntryLines_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsIncoming = table.Column<bool>(type: "bit", nullable: false),
                    PaymentTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    JournalEntryId = table.Column<long>(type: "bigint", nullable: false),
                    ReferenceDocumentId = table.Column<int>(type: "int", nullable: true),
                    ReferenceDocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_AccountCharts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_AccountingJournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "AccountingJournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountHolderName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: true),
                    AccountChartId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_AccountCharts_AccountChartId",
                        column: x => x.AccountChartId,
                        principalTable: "AccountCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Banks_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSalesPoint = table.Column<bool>(type: "bit", nullable: false),
                    OwnCompanyId = table.Column<byte>(type: "tinyint", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    DefaultCashLocationId = table.Column<byte>(type: "tinyint", nullable: false),
                    DefaultMetalLocationId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Locations_DefaultCashLocationId",
                        column: x => x.DefaultCashLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Locations_DefaultMetalLocationId",
                        column: x => x.DefaultMetalLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BranchLocations",
                columns: table => new
                {
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    LocationId = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LocationId1 = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchLocations", x => new { x.BranchId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_BranchLocations_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BranchLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BranchLocations_Locations_LocationId1",
                        column: x => x.LocationId1,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountChartId = table.Column<int>(type: "int", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashRegisters_AccountCharts_AccountChartId",
                        column: x => x.AccountChartId,
                        principalTable: "AccountCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashRegisters_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashRegisters_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PrimaryBranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HireDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_PrimaryBranchId",
                        column: x => x.PrimaryBranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    StatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    BomId = table.Column<int>(type: "int", nullable: false),
                    RoutingId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    ScheduledStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ScheduledEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ActualStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ActualEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_BillOfMaterials_BomId",
                        column: x => x.BomId,
                        principalTable: "BillOfMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_ProductionOrderStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ProductionOrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_ProductionRoutings_RoutingId",
                        column: x => x.RoutingId,
                        principalTable: "ProductionRoutings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionWorkCenters",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    CapacityPerShift = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionWorkCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionWorkCenters_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefiningProcesses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MetalCurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    InputWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    InputKaratId = table.Column<byte>(type: "tinyint", nullable: false),
                    OutputWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    OutputKaratId = table.Column<byte>(type: "tinyint", nullable: false),
                    LossWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefiningProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefiningProcesses_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RefiningProcesses_Currencies_MetalCurrencyId",
                        column: x => x.MetalCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RefiningProcesses_Karats_InputKaratId",
                        column: x => x.InputKaratId,
                        principalTable: "Karats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RefiningProcesses_Karats_OutputKaratId",
                        column: x => x.OutputKaratId,
                        principalTable: "Karats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DefaultCurrencyId = table.Column<byte>(type: "tinyint", nullable: true),
                    PrimaryBranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    UserRoleId = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastLogin = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Branches_PrimaryBranchId",
                        column: x => x.PrimaryBranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Currencies_DefaultCurrencyId",
                        column: x => x.DefaultCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkCenters",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    IsMachine = table.Column<bool>(type: "bit", nullable: false),
                    HourlyCostRate = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkCenters_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScrapTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MetalCurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    ScrapTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    KaratId = table.Column<byte>(type: "tinyint", nullable: false),
                    WeightGrams = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    RelatedOrderId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScrapTransactions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScrapTransactions_Currencies_MetalCurrencyId",
                        column: x => x.MetalCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScrapTransactions_Karats_KaratId",
                        column: x => x.KaratId,
                        principalTable: "Karats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScrapTransactions_ProductionOrders_RelatedOrderId",
                        column: x => x.RelatedOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScrapTransactions_ScrapTypes_ScrapTypeId",
                        column: x => x.ScrapTypeId,
                        principalTable: "ScrapTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionRoutingSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoutingId = table.Column<int>(type: "int", nullable: false),
                    Sequence = table.Column<short>(type: "smallint", nullable: false),
                    WorkCenterId = table.Column<byte>(type: "tinyint", nullable: false),
                    TimeRequiredHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CostPerHour = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsInspectionStep = table.Column<bool>(type: "bit", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRoutingSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionRoutingSteps_ProductionRoutings_RoutingId",
                        column: x => x.RoutingId,
                        principalTable: "ProductionRoutings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionRoutingSteps_ProductionWorkCenters_WorkCenterId",
                        column: x => x.WorkCenterId,
                        principalTable: "ProductionWorkCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBranchAccesses",
                columns: table => new
                {
                    UserId = table.Column<byte>(type: "tinyint", nullable: false),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    CanWrite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBranchAccesses", x => new { x.UserId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_UserBranchAccesses_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBranchAccesses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkCenterOperations",
                columns: table => new
                {
                    WorkCenterId = table.Column<byte>(type: "tinyint", nullable: false),
                    OperationDefinitionId = table.Column<byte>(type: "tinyint", nullable: false),
                    OverrideCostRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OperationDefinitionId1 = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkCenterOperations", x => new { x.WorkCenterId, x.OperationDefinitionId });
                    table.ForeignKey(
                        name: "FK_WorkCenterOperations_OperationDefinitions_OperationDefinitionId",
                        column: x => x.OperationDefinitionId,
                        principalTable: "OperationDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkCenterOperations_OperationDefinitions_OperationDefinitionId1",
                        column: x => x.OperationDefinitionId1,
                        principalTable: "OperationDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkCenterOperations_WorkCenters_WorkCenterId",
                        column: x => x.WorkCenterId,
                        principalTable: "WorkCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    RoutingStepId = table.Column<int>(type: "int", nullable: true),
                    TransactionTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    TransactionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ProductionOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    UnitId = table.Column<byte>(type: "tinyint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionTransactions_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionTransactions_ProductionOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionTransactions_ProductionOrders_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionTransactions_ProductionRoutingSteps_RoutingStepId",
                        column: x => x.RoutingStepId,
                        principalTable: "ProductionRoutingSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionTransactions_ProductionTransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "ProductionTransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionTransactions_UnitOfMeasures_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMetalAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MetalCurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    BalanceInGrams = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMetalAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerMetalAccounts_Currencies_MetalCurrencyId",
                        column: x => x.MetalCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMetalAccountTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MetalCurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    TransactionTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    WeightGrams = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    RelatedDocumentId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMetalAccountTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerMetalAccountTransactions_Currencies_MetalCurrencyId",
                        column: x => x.MetalCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerMetalAccountTransactions_CustomerMetalAccountTransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "CustomerMetalAccountTransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSupplier = table.Column<bool>(type: "bit", nullable: false),
                    IsB2BPartner = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomer = table.Column<bool>(type: "bit", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DefaultCurrencyId = table.Column<byte>(type: "tinyint", nullable: true),
                    PaymentTermId = table.Column<byte>(type: "tinyint", nullable: true),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Currencies_DefaultCurrencyId",
                        column: x => x.DefaultCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_PaymentTerms_PaymentTermId",
                        column: x => x.PaymentTermId,
                        principalTable: "PaymentTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RootTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InvoiceDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    RelatedOrderId = table.Column<int>(type: "int", nullable: true),
                    JournalEntryId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    InvoiceStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(19,8)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_AccountingJournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "AccountingJournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceStatuses_InvoiceStatusId",
                        column: x => x.InvoiceStatusId,
                        principalTable: "InvoiceStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_RootTypes_RootTypeId",
                        column: x => x.RootTypeId,
                        principalTable: "RootTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MailingAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CityId = table.Column<byte>(type: "tinyint", nullable: true),
                    CountryId = table.Column<byte>(type: "tinyint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailingAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailingAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MailingAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MailingAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RequiredDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExpectedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeliveryDateTarget = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    StatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    OrderPaymentStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<byte>(type: "tinyint", nullable: false),
                    UpdatedById = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ClosedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TaxesIncluded = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
                    RootTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_MailingAddresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "MailingAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_MailingAddresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "MailingAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderPaymentStatuses_OrderPaymentStatusId",
                        column: x => x.OrderPaymentStatusId,
                        principalTable: "OrderPaymentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatusDefinitions_StatusId",
                        column: x => x.StatusId,
                        principalTable: "OrderStatusDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_RootTypes_RootTypeId",
                        column: x => x.RootTypeId,
                        principalTable: "RootTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OwnCompanies",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BaseCurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    LegalAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnCompanies_Currencies_BaseCurrencyId",
                        column: x => x.BaseCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OwnCompanies_MailingAddresses_LegalAddressId",
                        column: x => x.LegalAddressId,
                        principalTable: "MailingAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovementDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    StockItemId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<byte>(type: "tinyint", nullable: false),
                    TransactionTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    MetalWeightGross = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    MetalWeightNet = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    CaratWeight = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    SourceOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_InventoryTransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "InventoryTransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_Orders_SourceOrderId",
                        column: x => x.SourceOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_StockItems_StockItemId",
                        column: x => x.StockItemId,
                        principalTable: "StockItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderAdditionalFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    AdditionalFeeDefinitionId = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    AmountTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    IsTaxIncluded = table.Column<bool>(type: "bit", nullable: false),
                    AccountingAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAdditionalFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAdditionalFees_AccountCharts_AccountingAccountId",
                        column: x => x.AccountingAccountId,
                        principalTable: "AccountCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderAdditionalFees_OrderAdditionalFeeDefinitions_AdditionalFeeDefinitionId",
                        column: x => x.AdditionalFeeDefinitionId,
                        principalTable: "OrderAdditionalFeeDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderAdditionalFees_OrderFeeAmountTypes_AmountTypeId",
                        column: x => x.AmountTypeId,
                        principalTable: "OrderFeeAmountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderAdditionalFees_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderFulfillments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    StatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<byte>(type: "tinyint", nullable: false),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true),
                    CargoId = table.Column<byte>(type: "tinyint", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CashOnDeliveryPrice = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    PackageControlledAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PackageControlledById = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFulfillments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderFulfillments_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderFulfillments_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderFulfillments_MailingAddresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "MailingAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderFulfillments_OrderStatusDefinitions_StatusId",
                        column: x => x.StatusId,
                        principalTable: "OrderStatusDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderFulfillments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderFulfillments_Users_PackageControlledById",
                        column: x => x.PackageControlledById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    LineTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    RootTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    LineStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<byte>(type: "tinyint", nullable: true),
                    StockQuantity = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    CustomerCurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    StockCurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    FixedExchangeRate = table.Column<decimal>(type: "decimal(19,8)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    CustomerAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    LineNote = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Currencies_CustomerCurrencyId",
                        column: x => x.CustomerCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_Currencies_StockCurrencyId",
                        column: x => x.StockCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_OrderLineType_LineTypeId",
                        column: x => x.LineTypeId,
                        principalTable: "OrderLineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_OrderStatusDefinitions_LineStatusId",
                        column: x => x.LineStatusId,
                        principalTable: "OrderStatusDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_RootTypes_RootTypeId",
                        column: x => x.RootTypeId,
                        principalTable: "RootTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderMetalSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CustomerCurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalWeightOrAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    TotalCaratWeight = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    OrderId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMetalSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderMetalSummaries_Currencies_CustomerCurrencyId",
                        column: x => x.CustomerCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderMetalSummaries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderMetalSummaries_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPaymentLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    CashId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<byte>(type: "tinyint", nullable: false),
                    TransactionNr = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OrderId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPaymentLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPaymentLines_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPaymentLines_CashRegisters_CashId",
                        column: x => x.CashId,
                        principalTable: "CashRegisters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPaymentLines_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPaymentLines_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPaymentLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPaymentLines_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPaymentLines_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderTaxLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ShopTaxBaseAmount = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    PresentmentTaxBaseAmount = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    ShopTaxAmount = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    PresentmentTaxAmount = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(9,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTaxLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTaxLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedById = table.Column<byte>(type: "tinyint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    TargetMetalWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    IssuedMetalWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    CalculatedScrapWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_WorkOrderStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "WorkOrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockItemId = table.Column<int>(type: "int", nullable: true),
                    OrderLineId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    MetalCost = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    WorkmanshipCost = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    OtherCosts = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    TotalUnitCost = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    CalculatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryCosts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryCosts_OrderLines_OrderLineId",
                        column: x => x.OrderLineId,
                        principalTable: "OrderLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryCosts_StockItems_StockItemId",
                        column: x => x.StockItemId,
                        principalTable: "StockItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<short>(type: "smallint", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<byte>(type: "tinyint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LineAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TaxRateId = table.Column<byte>(type: "tinyint", nullable: false),
                    OrderLineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_OrderLines_OrderLineId",
                        column: x => x.OrderLineId,
                        principalTable: "OrderLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_TaxRates_TaxRateId",
                        column: x => x.TaxRateId,
                        principalTable: "TaxRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_UnitOfMeasures_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderLineId = table.Column<int>(type: "int", nullable: false),
                    OrderLineCostTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Fineness = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CustomerRate = table.Column<decimal>(type: "decimal(19,8)", nullable: true),
                    CustomerAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    OrderLineId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLineCost_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLineCost_OrderLineCostType_OrderLineCostTypeId",
                        column: x => x.OrderLineCostTypeId,
                        principalTable: "OrderLineCostType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLineCost_OrderLines_OrderLineId",
                        column: x => x.OrderLineId,
                        principalTable: "OrderLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLineCost_OrderLines_OrderLineId1",
                        column: x => x.OrderLineId1,
                        principalTable: "OrderLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovementTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    TransactionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SourceOrderLineId = table.Column<int>(type: "int", nullable: true),
                    ReferenceDocType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
                    LocationId = table.Column<byte>(type: "tinyint", nullable: false),
                    MetalCurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    MetalPurityId = table.Column<byte>(type: "tinyint", nullable: true),
                    Fineness = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    WeightInGrams = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    BaseExchangeCurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    CostPerGramEUR = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    FixedExchangeRate = table.Column<decimal>(type: "decimal(19,8)", nullable: false),
                    CreatedById = table.Column<byte>(type: "tinyint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTransactions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransactions_Currencies_BaseExchangeCurrencyId",
                        column: x => x.BaseExchangeCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransactions_Currencies_MetalCurrencyId",
                        column: x => x.MetalCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransactions_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransactions_MetalPurities_MetalPurityId",
                        column: x => x.MetalPurityId,
                        principalTable: "MetalPurities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransactions_OrderLines_SourceOrderLineId",
                        column: x => x.SourceOrderLineId,
                        principalTable: "OrderLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransactions_StockMovementTypes_MovementTypeId",
                        column: x => x.MovementTypeId,
                        principalTable: "StockMovementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransactions_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    OperationDefinitionId = table.Column<byte>(type: "tinyint", nullable: false),
                    WorkCenterId = table.Column<byte>(type: "tinyint", nullable: false),
                    StatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false),
                    AssignedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    StartedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CompletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    MetalInputWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    MetalOutputWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    ScrapWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderOperations_OperationDefinitions_OperationDefinitionId",
                        column: x => x.OperationDefinitionId,
                        principalTable: "OperationDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrderOperations_OperationStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "OperationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrderOperations_WorkCenters_WorkCenterId",
                        column: x => x.WorkCenterId,
                        principalTable: "WorkCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrderOperations_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderOperationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<byte>(type: "tinyint", nullable: false),
                    StartTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    MetalAdjustmentWeight = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    AdjustmentType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WorkOrderOperationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderOperationLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderOperationLogs_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrderOperationLogs_WorkOrderOperations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "WorkOrderOperations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrderOperationLogs_WorkOrderOperations_WorkOrderOperationId",
                        column: x => x.WorkOrderOperationId,
                        principalTable: "WorkOrderOperations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UomTypes",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { (byte)1, "WEIGHT", true, "Ağırlık" },
                    { (byte)2, "COUNT", true, "Adet" },
                    { (byte)3, "LENGTH", true, "Uzunluk" },
                    { (byte)4, "VOLUME", true, "Hacim" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountCharts_AccountTypeId",
                table: "AccountCharts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCharts_ParentAccountId",
                table: "AccountCharts",
                column: "ParentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingJournalEntries_BranchId",
                table: "AccountingJournalEntries",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingJournalEntryLines_AccountId",
                table: "AccountingJournalEntryLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingJournalEntryLines_CurrencyId",
                table: "AccountingJournalEntryLines",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingJournalEntryLines_EntryId",
                table: "AccountingJournalEntryLines",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_AccountChartId",
                table: "Banks",
                column: "AccountChartId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_BranchId",
                table: "Banks",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_CurrencyId",
                table: "Banks",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_CustomerId",
                table: "Banks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_BOMTypeId",
                table: "BillOfMaterials",
                column: "BOMTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_ProductVariantId",
                table: "BillOfMaterials",
                column: "ProductVariantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOMLabors_BillOfMaterialsId",
                table: "BOMLabors",
                column: "BillOfMaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMLabors_BomId",
                table: "BOMLabors",
                column: "BomId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMLabors_LaborCostTypeId",
                table: "BOMLabors",
                column: "LaborCostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMStones_BomId",
                table: "BOMStones",
                column: "BomId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMStones_StoneTypeId",
                table: "BOMStones",
                column: "StoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMStoneTypes_BaseUnitId",
                table: "BOMStoneTypes",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_AddressId",
                table: "Branches",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DefaultCashLocationId",
                table: "Branches",
                column: "DefaultCashLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DefaultMetalLocationId",
                table: "Branches",
                column: "DefaultMetalLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_OwnCompanyId",
                table: "Branches",
                column: "OwnCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLocations_LocationId",
                table: "BranchLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLocations_LocationId1",
                table: "BranchLocations",
                column: "LocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_AccountChartId",
                table: "CashRegisters",
                column: "AccountChartId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_BranchId",
                table: "CashRegisters",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_CurrencyId",
                table: "CashRegisters",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_DefaultCurrencyId",
                table: "Countries",
                column: "DefaultCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMetalAccounts_CustomerId",
                table: "CustomerMetalAccounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMetalAccounts_MetalCurrencyId",
                table: "CustomerMetalAccounts",
                column: "MetalCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMetalAccountTransactions_CustomerId",
                table: "CustomerMetalAccountTransactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMetalAccountTransactions_MetalCurrencyId",
                table: "CustomerMetalAccountTransactions",
                column: "MetalCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMetalAccountTransactions_TransactionTypeId",
                table: "CustomerMetalAccountTransactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BillingAddressId",
                table: "Customers",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DefaultCurrencyId",
                table: "Customers",
                column: "DefaultCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PaymentTermId",
                table: "Customers",
                column: "PaymentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ShippingAddressId",
                table: "Customers",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PrimaryBranchId",
                table: "Employees",
                column: "PrimaryBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCosts_CurrencyId",
                table: "InventoryCosts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCosts_OrderLineId",
                table: "InventoryCosts",
                column: "OrderLineId",
                unique: true,
                filter: "[OrderLineId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCosts_StockItemId",
                table: "InventoryCosts",
                column: "StockItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLevels_LocationId",
                table: "InventoryLevels",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLevels_MetalPurityId",
                table: "InventoryLevels",
                column: "MetalPurityId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLevels_StockItemId",
                table: "InventoryLevels",
                column: "StockItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_LocationId",
                table: "InventoryTransactions",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_SourceOrderId",
                table: "InventoryTransactions",
                column: "SourceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_StockItemId",
                table: "InventoryTransactions",
                column: "StockItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_TransactionTypeId",
                table: "InventoryTransactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceId",
                table: "InvoiceLines",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_OrderLineId",
                table: "InvoiceLines",
                column: "OrderLineId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_ProductVariantId",
                table: "InvoiceLines",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_TaxRateId",
                table: "InvoiceLines",
                column: "TaxRateId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_UnitId",
                table: "InvoiceLines",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CurrencyId",
                table: "Invoices",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceStatusId",
                table: "Invoices",
                column: "InvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_JournalEntryId",
                table: "Invoices",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RootTypeId",
                table: "Invoices",
                column: "RootTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MailingAddresses_CityId",
                table: "MailingAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_MailingAddresses_CountryId",
                table: "MailingAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MailingAddresses_CustomerId",
                table: "MailingAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MetalPurities_BaseMetalId",
                table: "MetalPurities",
                column: "BaseMetalId");

            migrationBuilder.CreateIndex(
                name: "IX_MetalTypes_BaseUnitId",
                table: "MetalTypes",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAdditionalFeeDefinitions_DefaultAccountingAccountId",
                table: "OrderAdditionalFeeDefinitions",
                column: "DefaultAccountingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAdditionalFees_AccountingAccountId",
                table: "OrderAdditionalFees",
                column: "AccountingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAdditionalFees_AdditionalFeeDefinitionId",
                table: "OrderAdditionalFees",
                column: "AdditionalFeeDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAdditionalFees_AmountTypeId",
                table: "OrderAdditionalFees",
                column: "AmountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAdditionalFees_OrderId",
                table: "OrderAdditionalFees",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFulfillments_CargoId",
                table: "OrderFulfillments",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFulfillments_LocationId",
                table: "OrderFulfillments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFulfillments_OrderId",
                table: "OrderFulfillments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFulfillments_PackageControlledById",
                table: "OrderFulfillments",
                column: "PackageControlledById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFulfillments_ShippingAddressId",
                table: "OrderFulfillments",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFulfillments_StatusId",
                table: "OrderFulfillments",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineCost_CurrencyId",
                table: "OrderLineCost",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineCost_OrderLineCostTypeId",
                table: "OrderLineCost",
                column: "OrderLineCostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineCost_OrderLineId",
                table: "OrderLineCost",
                column: "OrderLineId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineCost_OrderLineId1",
                table: "OrderLineCost",
                column: "OrderLineId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_CustomerCurrencyId",
                table: "OrderLines",
                column: "CustomerCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_LineStatusId",
                table: "OrderLines",
                column: "LineStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_LineTypeId",
                table: "OrderLines",
                column: "LineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_LocationId",
                table: "OrderLines",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductVariantId",
                table: "OrderLines",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_RootTypeId",
                table: "OrderLines",
                column: "RootTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_StockCurrencyId",
                table: "OrderLines",
                column: "StockCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMetalSummaries_CustomerCurrencyId",
                table: "OrderMetalSummaries",
                column: "CustomerCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMetalSummaries_OrderId",
                table: "OrderMetalSummaries",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMetalSummaries_OrderId1",
                table: "OrderMetalSummaries",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentLines_BankId",
                table: "OrderPaymentLines",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentLines_CashId",
                table: "OrderPaymentLines",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentLines_CreatedById",
                table: "OrderPaymentLines",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentLines_CurrencyId",
                table: "OrderPaymentLines",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentLines_CustomerId",
                table: "OrderPaymentLines",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentLines_OrderId",
                table: "OrderPaymentLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentLines_OrderId1",
                table: "OrderPaymentLines",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BranchId",
                table: "Orders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedById",
                table: "Orders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CurrencyId",
                table: "Orders",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderPaymentStatusId",
                table: "Orders",
                column: "OrderPaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RootTypeId",
                table: "Orders",
                column: "RootTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UpdatedById",
                table: "Orders",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTaxLines_OrderId",
                table: "OrderTaxLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnCompanies_BaseCurrencyId",
                table: "OwnCompanies",
                column: "BaseCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnCompanies_LegalAddressId",
                table: "OwnCompanies",
                column: "LegalAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AccountId",
                table: "Payments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CurrencyId",
                table: "Payments",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_JournalEntryId",
                table: "Payments",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_CurrencyId",
                table: "PriceLists",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ImageTypeId",
                table: "ProductImages",
                column: "ImageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductVariantId",
                table: "ProductImages",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_BomId",
                table: "ProductionOrders",
                column: "BomId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_BranchId",
                table: "ProductionOrders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_ProductVariantId",
                table: "ProductionOrders",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_RoutingId",
                table: "ProductionOrders",
                column: "RoutingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_StatusId",
                table: "ProductionOrders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRoutingItems_ProductionRoutingId",
                table: "ProductionRoutingItems",
                column: "ProductionRoutingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRoutingItems_RoutingPurposeId",
                table: "ProductionRoutingItems",
                column: "RoutingPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRoutingSteps_RoutingId",
                table: "ProductionRoutingSteps",
                column: "RoutingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRoutingSteps_WorkCenterId",
                table: "ProductionRoutingSteps",
                column: "WorkCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactions_OrderId",
                table: "ProductionTransactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactions_ProductionOrderId",
                table: "ProductionTransactions",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactions_ProductVariantId",
                table: "ProductionTransactions",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactions_RoutingStepId",
                table: "ProductionTransactions",
                column: "RoutingStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactions_TransactionTypeId",
                table: "ProductionTransactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTransactions_UnitId",
                table: "ProductionTransactions",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionWorkCenters_BranchId",
                table: "ProductionWorkCenters",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockUnitId",
                table: "Products",
                column: "StockUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_BaseUnitId",
                table: "ProductVariants",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_MetalPurityId",
                table: "ProductVariants",
                column: "MetalPurityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_MaterialTypeId",
                table: "RawMaterials",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_UnitId",
                table: "RawMaterials",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RefiningProcesses_BranchId",
                table: "RefiningProcesses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RefiningProcesses_InputKaratId",
                table: "RefiningProcesses",
                column: "InputKaratId");

            migrationBuilder.CreateIndex(
                name: "IX_RefiningProcesses_MetalCurrencyId",
                table: "RefiningProcesses",
                column: "MetalCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_RefiningProcesses_OutputKaratId",
                table: "RefiningProcesses",
                column: "OutputKaratId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePricingRules_PriceListId",
                table: "SalePricingRules",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePricingRules_ProductVariantId",
                table: "SalePricingRules",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapTransactions_BranchId",
                table: "ScrapTransactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapTransactions_KaratId",
                table: "ScrapTransactions",
                column: "KaratId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapTransactions_MetalCurrencyId",
                table: "ScrapTransactions",
                column: "MetalCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapTransactions_RelatedOrderId",
                table: "ScrapTransactions",
                column: "RelatedOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapTransactions_ScrapTypeId",
                table: "ScrapTransactions",
                column: "ScrapTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_BaseUnitId",
                table: "StockItems",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_MetalPurityId",
                table: "StockItems",
                column: "MetalPurityId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_MetalTypeId",
                table: "StockItems",
                column: "MetalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_StockItemTypeId",
                table: "StockItems",
                column: "StockItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_BaseExchangeCurrencyId",
                table: "StockTransactions",
                column: "BaseExchangeCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_BranchId",
                table: "StockTransactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_CreatedById",
                table: "StockTransactions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_LocationId",
                table: "StockTransactions",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_MetalCurrencyId",
                table: "StockTransactions",
                column: "MetalCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_MetalPurityId",
                table: "StockTransactions",
                column: "MetalPurityId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_MovementTypeId",
                table: "StockTransactions",
                column: "MovementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_SourceOrderLineId",
                table: "StockTransactions",
                column: "SourceOrderLineId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureConversions_FromUnitId",
                table: "UnitOfMeasureConversions",
                column: "FromUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureConversions_ProductVariantId",
                table: "UnitOfMeasureConversions",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureConversions_ToUnitId",
                table: "UnitOfMeasureConversions",
                column: "ToUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasures_BaseUnitId",
                table: "UnitOfMeasures",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasures_UomTypeId",
                table: "UnitOfMeasures",
                column: "UomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasures_UomTypeId1",
                table: "UnitOfMeasures",
                column: "UomTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranchAccesses_BranchId",
                table: "UserBranchAccesses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolePermissions_PermissionId",
                table: "UserRolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DefaultCurrencyId",
                table: "Users",
                column: "DefaultCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PrimaryBranchId",
                table: "Users",
                column: "PrimaryBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkCenterOperations_OperationDefinitionId",
                table: "WorkCenterOperations",
                column: "OperationDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkCenterOperations_OperationDefinitionId1",
                table: "WorkCenterOperations",
                column: "OperationDefinitionId1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkCenters_BranchId",
                table: "WorkCenters",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderOperationLogs_EmployeeId",
                table: "WorkOrderOperationLogs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderOperationLogs_OperationId",
                table: "WorkOrderOperationLogs",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderOperationLogs_WorkOrderOperationId",
                table: "WorkOrderOperationLogs",
                column: "WorkOrderOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderOperations_OperationDefinitionId",
                table: "WorkOrderOperations",
                column: "OperationDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderOperations_StatusId",
                table: "WorkOrderOperations",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderOperations_WorkCenterId",
                table: "WorkOrderOperations",
                column: "WorkCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderOperations_WorkOrderId",
                table: "WorkOrderOperations",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_CreatedById",
                table: "WorkOrders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_OrderId",
                table: "WorkOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_ProductVariantId",
                table: "WorkOrders",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_StatusId",
                table: "WorkOrders",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingJournalEntries_Branches_BranchId",
                table: "AccountingJournalEntries",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_Branches_BranchId",
                table: "Banks",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_Customers_CustomerId",
                table: "Banks",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_MailingAddresses_AddressId",
                table: "Branches",
                column: "AddressId",
                principalTable: "MailingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_OwnCompanies_OwnCompanyId",
                table: "Branches",
                column: "OwnCompanyId",
                principalTable: "OwnCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMetalAccounts_Customers_CustomerId",
                table: "CustomerMetalAccounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMetalAccountTransactions_Customers_CustomerId",
                table: "CustomerMetalAccountTransactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MailingAddresses_BillingAddressId",
                table: "Customers",
                column: "BillingAddressId",
                principalTable: "MailingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MailingAddresses_ShippingAddressId",
                table: "Customers",
                column: "ShippingAddressId",
                principalTable: "MailingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Currencies_DefaultCurrencyId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Currencies_DefaultCurrencyId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_MailingAddresses_Customers_CustomerId",
                table: "MailingAddresses");

            migrationBuilder.DropTable(
                name: "AccountingJournalEntryLines");

            migrationBuilder.DropTable(
                name: "BOMLabors");

            migrationBuilder.DropTable(
                name: "BOMStones");

            migrationBuilder.DropTable(
                name: "BranchLocations");

            migrationBuilder.DropTable(
                name: "CustomerMetalAccounts");

            migrationBuilder.DropTable(
                name: "CustomerMetalAccountTransactions");

            migrationBuilder.DropTable(
                name: "DailyMetalRates");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "InventoryCosts");

            migrationBuilder.DropTable(
                name: "InventoryLevels");

            migrationBuilder.DropTable(
                name: "InventoryTransactions");

            migrationBuilder.DropTable(
                name: "InvoiceLines");

            migrationBuilder.DropTable(
                name: "OrderAdditionalFees");

            migrationBuilder.DropTable(
                name: "OrderFulfillments");

            migrationBuilder.DropTable(
                name: "OrderLineCost");

            migrationBuilder.DropTable(
                name: "OrderMetalSummaries");

            migrationBuilder.DropTable(
                name: "OrderPaymentLines");

            migrationBuilder.DropTable(
                name: "OrderTaxLines");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductionRoutingItems");

            migrationBuilder.DropTable(
                name: "ProductionTransactions");

            migrationBuilder.DropTable(
                name: "RawMaterials");

            migrationBuilder.DropTable(
                name: "RefiningProcesses");

            migrationBuilder.DropTable(
                name: "SalePricingRules");

            migrationBuilder.DropTable(
                name: "ScrapTransactions");

            migrationBuilder.DropTable(
                name: "StockTransactions");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureConversions");

            migrationBuilder.DropTable(
                name: "UserBranchAccesses");

            migrationBuilder.DropTable(
                name: "UserRolePermissions");

            migrationBuilder.DropTable(
                name: "WorkCenterOperations");

            migrationBuilder.DropTable(
                name: "WorkOrderOperationLogs");

            migrationBuilder.DropTable(
                name: "BOMCostTypes");

            migrationBuilder.DropTable(
                name: "BOMStoneTypes");

            migrationBuilder.DropTable(
                name: "CustomerMetalAccountTransactionTypes");

            migrationBuilder.DropTable(
                name: "InventoryTransactionTypes");

            migrationBuilder.DropTable(
                name: "StockItems");

            migrationBuilder.DropTable(
                name: "TaxRates");

            migrationBuilder.DropTable(
                name: "OrderAdditionalFeeDefinitions");

            migrationBuilder.DropTable(
                name: "OrderFeeAmountTypes");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "OrderLineCostType");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "CashRegisters");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "ImageTypes");

            migrationBuilder.DropTable(
                name: "RoutingPurposes");

            migrationBuilder.DropTable(
                name: "ProductionRoutingSteps");

            migrationBuilder.DropTable(
                name: "ProductionTransactionTypes");

            migrationBuilder.DropTable(
                name: "RawMaterialTypes");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "Karats");

            migrationBuilder.DropTable(
                name: "ProductionOrders");

            migrationBuilder.DropTable(
                name: "ScrapTypes");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "StockMovementTypes");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "WorkOrderOperations");

            migrationBuilder.DropTable(
                name: "StockItemTypes");

            migrationBuilder.DropTable(
                name: "AccountCharts");

            migrationBuilder.DropTable(
                name: "ProductionWorkCenters");

            migrationBuilder.DropTable(
                name: "BillOfMaterials");

            migrationBuilder.DropTable(
                name: "ProductionOrderStatuses");

            migrationBuilder.DropTable(
                name: "ProductionRoutings");

            migrationBuilder.DropTable(
                name: "OrderLineType");

            migrationBuilder.DropTable(
                name: "OperationDefinitions");

            migrationBuilder.DropTable(
                name: "OperationStatuses");

            migrationBuilder.DropTable(
                name: "WorkCenters");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "BOMTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "WorkOrderStatuses");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "OrderPaymentStatuses");

            migrationBuilder.DropTable(
                name: "OrderStatusDefinitions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MetalPurities");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AccountingJournalEntries");

            migrationBuilder.DropTable(
                name: "InvoiceStatuses");

            migrationBuilder.DropTable(
                name: "RootTypes");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "MetalTypes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "StockUnitOfMeasures");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "OwnCompanies");

            migrationBuilder.DropTable(
                name: "UomTypes");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MailingAddresses");

            migrationBuilder.DropTable(
                name: "PaymentTerms");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
