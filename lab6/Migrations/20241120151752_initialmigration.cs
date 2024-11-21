using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab6.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguagesSpoken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsdExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsdExchangeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationTypes",
                columns: table => new
                {
                    OrganizationTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrganizationTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationTypes", x => x.OrganizationTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "ProductAndServiceTypes",
                columns: table => new
                {
                    ProductSvcTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductSvcTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAndServiceTypes", x => x.ProductSvcTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "LocationTypes",
                columns: table => new
                {
                    LocationTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTypes", x => x.LocationTypeCode);
                    table.ForeignKey(
                        name: "FK_LocationTypes_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrganizationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                    table.ForeignKey(
                        name: "FK_Organizations_OrganizationTypes_OrganizationTypeCode",
                        column: x => x.OrganizationTypeCode,
                        principalTable: "OrganizationTypes",
                        principalColumn: "OrganizationTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsAndServices",
                columns: table => new
                {
                    ProductSvcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductSvcTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductSvcDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsAndServices", x => x.ProductSvcId);
                    table.ForeignKey(
                        name: "FK_ProductsAndServices_ProductAndServiceTypes_ProductSvcTypeCode",
                        column: x => x.ProductSvcTypeCode,
                        principalTable: "ProductAndServiceTypes",
                        principalColumn: "ProductSvcTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_LocationTypes_LocationTypeCode",
                        column: x => x.LocationTypeCode,
                        principalTable: "LocationTypes",
                        principalColumn: "LocationTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ShipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromOrganizationId = table.Column<int>(type: "int", nullable: false),
                    ToOrganizationId = table.Column<int>(type: "int", nullable: false),
                    ShipmentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ShipmentId);
                    table.ForeignKey(
                        name: "FK_Shipments_Organizations_FromOrganizationId",
                        column: x => x.FromOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_Organizations_ToOrganizationId",
                        column: x => x.ToOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovementLocations",
                columns: table => new
                {
                    ShipmentLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentId = table.Column<int>(type: "int", nullable: false),
                    FromLocationId = table.Column<int>(type: "int", nullable: false),
                    ToLocationId = table.Column<int>(type: "int", nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementLocations", x => x.ShipmentLocationId);
                    table.ForeignKey(
                        name: "FK_MovementLocations_Locations_FromLocationId",
                        column: x => x.FromLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovementLocations_Locations_ToLocationId",
                        column: x => x.ToLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovementLocations_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentProductsAndServices",
                columns: table => new
                {
                    ShipmentId = table.Column<int>(type: "int", nullable: false),
                    ProductSvcId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentProductsAndServices", x => new { x.ShipmentId, x.ProductSvcId });
                    table.ForeignKey(
                        name: "FK_ShipmentProductsAndServices_ProductsAndServices_ProductSvcId",
                        column: x => x.ProductSvcId,
                        principalTable: "ProductsAndServices",
                        principalColumn: "ProductSvcId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentProductsAndServices_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationTypeCode",
                table: "Locations",
                column: "LocationTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTypes_CountryCode",
                table: "LocationTypes",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_MovementLocations_FromLocationId",
                table: "MovementLocations",
                column: "FromLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementLocations_ShipmentId",
                table: "MovementLocations",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementLocations_ToLocationId",
                table: "MovementLocations",
                column: "ToLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationTypeCode",
                table: "Organizations",
                column: "OrganizationTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsAndServices_ProductSvcTypeCode",
                table: "ProductsAndServices",
                column: "ProductSvcTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentProductsAndServices_ProductSvcId",
                table: "ShipmentProductsAndServices",
                column: "ProductSvcId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_FromOrganizationId",
                table: "Shipments",
                column: "FromOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ToOrganizationId",
                table: "Shipments",
                column: "ToOrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovementLocations");

            migrationBuilder.DropTable(
                name: "ShipmentProductsAndServices");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ProductsAndServices");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "LocationTypes");

            migrationBuilder.DropTable(
                name: "ProductAndServiceTypes");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "OrganizationTypes");
        }
    }
}
