using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class FinalFixModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock_quantity = table.Column<int>(type: "int", nullable: false),
                    category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    order_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    customer_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    customer_email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delivery_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category", "created_at", "description", "name", "price", "sku", "stock_quantity", "updated_at" },
                values: new object[,]
                {
                    { 1, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6400), "High-end smartphone", "IPhone 15 Pro Max Version 1", 1010m, "IPHONE-15-001", 51, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6401) },
                    { 2, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6405), "High-end smartphone", "IPhone 15 Pro Max Version 2", 1020m, "IPHONE-15-002", 52, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6406) },
                    { 3, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6410), "High-end smartphone", "IPhone 15 Pro Max Version 3", 1030m, "IPHONE-15-003", 53, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6410) },
                    { 4, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6414), "High-end smartphone", "IPhone 15 Pro Max Version 4", 1040m, "IPHONE-15-004", 54, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6414) },
                    { 5, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6417), "High-end smartphone", "IPhone 15 Pro Max Version 5", 1050m, "IPHONE-15-005", 55, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6417) },
                    { 6, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6420), "High-end smartphone", "IPhone 15 Pro Max Version 6", 1060m, "IPHONE-15-006", 56, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6420) },
                    { 7, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6423), "High-end smartphone", "IPhone 15 Pro Max Version 7", 1070m, "IPHONE-15-007", 57, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6423) },
                    { 8, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6426), "High-end smartphone", "IPhone 15 Pro Max Version 8", 1080m, "IPHONE-15-008", 58, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6426) },
                    { 9, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6429), "High-end smartphone", "IPhone 15 Pro Max Version 9", 1090m, "IPHONE-15-009", 59, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6429) },
                    { 10, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6434), "High-end smartphone", "IPhone 15 Pro Max Version 10", 1100m, "IPHONE-15-010", 60, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6435) },
                    { 11, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6438), "High-end smartphone", "IPhone 15 Pro Max Version 11", 1110m, "IPHONE-15-011", 61, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6438) },
                    { 12, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6441), "High-end smartphone", "IPhone 15 Pro Max Version 12", 1120m, "IPHONE-15-012", 62, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6441) },
                    { 13, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6444), "High-end smartphone", "IPhone 15 Pro Max Version 13", 1130m, "IPHONE-15-013", 63, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6444) },
                    { 14, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6446), "High-end smartphone", "IPhone 15 Pro Max Version 14", 1140m, "IPHONE-15-014", 64, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6447) },
                    { 15, "Electronics", new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6449), "High-end smartphone", "IPhone 15 Pro Max Version 15", 1150m, "IPHONE-15-015", 65, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6449) }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "created_at", "customer_email", "customer_name", "delivery_date", "order_date", "order_number", "product_id", "quantity", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6629), "user1@test.com", "User Test 1", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0001", 2, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6629) },
                    { 2, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6673), "user2@test.com", "User Test 2", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0002", 3, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6673) },
                    { 3, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6679), "user3@test.com", "User Test 3", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0003", 4, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6679) },
                    { 4, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6684), "user4@test.com", "User Test 4", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0004", 5, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6685) },
                    { 5, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6689), "user5@test.com", "User Test 5", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0005", 6, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6690) },
                    { 6, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6694), "user6@test.com", "User Test 6", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0006", 7, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6695) },
                    { 7, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6699), "user7@test.com", "User Test 7", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0007", 8, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6699) },
                    { 8, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6703), "user8@test.com", "User Test 8", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0008", 9, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6704) },
                    { 9, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6708), "user9@test.com", "User Test 9", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0009", 10, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6708) },
                    { 10, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6713), "user10@test.com", "User Test 10", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0010", 11, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6713) },
                    { 11, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6718), "user11@test.com", "User Test 11", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0011", 12, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6718) },
                    { 12, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6723), "user12@test.com", "User Test 12", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0012", 13, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6723) },
                    { 13, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6728), "user13@test.com", "User Test 13", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0013", 14, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6728) },
                    { 14, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6732), "user14@test.com", "User Test 14", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0014", 15, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6733) },
                    { 15, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6737), "user15@test.com", "User Test 15", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0015", 1, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6737) },
                    { 16, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6741), "user16@test.com", "User Test 16", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0016", 2, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6741) },
                    { 17, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6745), "user17@test.com", "User Test 17", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0017", 3, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6746) },
                    { 18, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6750), "user18@test.com", "User Test 18", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0018", 4, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6750) },
                    { 19, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6754), "user19@test.com", "User Test 19", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0019", 5, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6754) },
                    { 20, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6759), "user20@test.com", "User Test 20", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0020", 6, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6759) },
                    { 21, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6763), "user21@test.com", "User Test 21", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0021", 7, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6763) },
                    { 22, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6768), "user22@test.com", "User Test 22", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0022", 8, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6768) },
                    { 23, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6772), "user23@test.com", "User Test 23", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0023", 9, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6772) },
                    { 24, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6776), "user24@test.com", "User Test 24", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0024", 10, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6777) },
                    { 25, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6781), "user25@test.com", "User Test 25", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0025", 11, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6781) },
                    { 26, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6785), "user26@test.com", "User Test 26", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0026", 12, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6785) },
                    { 27, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6789), "user27@test.com", "User Test 27", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0027", 13, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6790) },
                    { 28, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6794), "user28@test.com", "User Test 28", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0028", 14, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6794) },
                    { 29, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6798), "user29@test.com", "User Test 29", null, new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0029", 15, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6798) },
                    { 30, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6802), "user30@test.com", "User Test 30", new DateTime(2025, 12, 31, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 12, 28, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6563), "ORD-20251228-0030", 1, 1, new DateTime(2026, 1, 17, 15, 37, 9, 497, DateTimeKind.Local).AddTicks(6803) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer_email",
                table: "orders",
                column: "customer_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_order_number",
                table: "orders",
                column: "order_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_product_id",
                table: "orders",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_name",
                table: "products",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_sku",
                table: "products",
                column: "sku",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
