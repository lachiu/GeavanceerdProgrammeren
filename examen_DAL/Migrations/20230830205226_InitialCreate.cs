using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace examen_DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VatPercentages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatPercentages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketsProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    VatPercentageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketsProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketsProducts_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketsProducts_VatPercentages_VatPercentageId",
                        column: x => x.VatPercentageId,
                        principalTable: "VatPercentages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Koelkast garage" },
                    { 2, "Koelkast keuken" },
                    { 3, "Bankje kelder links 1" },
                    { 4, "Bankje kelder links 2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Description", "Name" },
                values: new object[,]
                {
                    { 7, "7", "Flesje koffie melk.", "Koffie melk 330cl" },
                    { 6, "6", "Appel van de lokale boer zonder pesticide.", "Appel" },
                    { 5, "5", "Halfvolle melk van de lokale boer.", "Brik halfvolle melk 1L" },
                    { 8, "8", "Een fruitdrink met de verrassende smaakcombinatie ananas en guave. Een fruitdrink met de verrassende smaakcombinatie ananas en guave.", "Dubbeldrank Ananas & guave" },
                    { 3, "3", "Taart.", "Taart" },
                    { 2, "2", "Glazen potje.", "Crème brûlée" },
                    { 1, "1", "Verse banaan uit Colombia.", "Verse banaan" },
                    { 4, "4", "Wit brood, 900g.", "Wit brood" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lidl" },
                    { 2, "Carrefour" },
                    { 3, "Spar" },
                    { 4, "Action" },
                    { 5, "Aldi" },
                    { 6, "Delhaize" },
                    { 7, "Albert Heijn" },
                    { 8, "Jumbo" }
                });

            migrationBuilder.InsertData(
                table: "VatPercentages",
                columns: new[] { "Id", "Percentage" },
                values: new object[,]
                {
                    { 3, 11 },
                    { 1, 0 },
                    { 2, 6 },
                    { 4, 21 }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "LocationId", "ProductId", "Qty" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 3 },
                    { 3, 1, 3, 1 },
                    { 4, 3, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "PurchaseDate", "StoreId", "Total" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 30, 22, 52, 26, 492, DateTimeKind.Local).AddTicks(8484), 1, 2.0 },
                    { 2, new DateTime(2023, 8, 30, 22, 52, 26, 494, DateTimeKind.Local).AddTicks(7813), 7, 7.0 }
                });

            migrationBuilder.InsertData(
                table: "TicketsProducts",
                columns: new[] { "Id", "ProductId", "Qty", "TicketId", "UnitPrice", "VatPercentageId" },
                values: new object[] { 1, 1, 2, 1, 1.0, 1 });

            migrationBuilder.InsertData(
                table: "TicketsProducts",
                columns: new[] { "Id", "ProductId", "Qty", "TicketId", "UnitPrice", "VatPercentageId" },
                values: new object[] { 2, 8, 5, 2, 1.3999999999999999, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_LocationId",
                table: "Stocks",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StoreId",
                table: "Tickets",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsProducts_ProductId",
                table: "TicketsProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsProducts_TicketId",
                table: "TicketsProducts",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsProducts_VatPercentageId",
                table: "TicketsProducts",
                column: "VatPercentageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "TicketsProducts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "VatPercentages");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
