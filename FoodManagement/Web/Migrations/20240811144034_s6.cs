using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class s6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("1ff98313-c611-463c-888b-2699858baf3b"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("6d207995-701f-429a-a4dd-8fd550539de0"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("7f718c35-6bda-49b7-bf32-9708b18e7c0a"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("9ddd495b-8e5f-448f-b1f8-9f1ef187e007"));

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Details_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("13fa3400-6e4b-4f51-91a1-791fb40c6756"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("42d9af50-88e4-46df-9392-e1ea60884c2e") },
                    { new Guid("4a695010-e118-4ad7-8a0e-d7bd8536a133"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("1ef67211-920b-48b6-a9df-512c6ec85ef1") },
                    { new Guid("747c59ab-399d-4c8f-9e40-470543fd3910"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("614baaa4-3b04-4864-a971-ea62da5e24b0") },
                    { new Guid("ca23700e-f58c-4439-b0a4-6c20c8f207fa"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("69ad0aba-087c-48b0-a7ed-83d7cc9342fb") }
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("357ab6ba-b001-4faa-a151-bb3da1489453"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 21, 40, 32, 572, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("51007f20-0d48-493f-b163-d6f37d3bd562"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 21, 40, 32, 572, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("72f3845c-ae64-4093-87ec-072b66a943d1"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 21, 40, 32, 572, DateTimeKind.Local).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b7fdfff4-bca6-411b-9b3e-1f1498c64f7b"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 21, 40, 32, 572, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("def472c2-1590-4b8d-afff-b84e42b0bbe2"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 21, 40, 32, 572, DateTimeKind.Local).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("e23e4a7c-72fa-499d-8495-a4ea54377aa8"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 21, 40, 32, 572, DateTimeKind.Local).AddTicks(638));

            migrationBuilder.CreateIndex(
                name: "IX_Details_OrderId",
                table: "Details",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ProductId",
                table: "Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("13fa3400-6e4b-4f51-91a1-791fb40c6756"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("4a695010-e118-4ad7-8a0e-d7bd8536a133"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("747c59ab-399d-4c8f-9e40-470543fd3910"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("ca23700e-f58c-4439-b0a4-6c20c8f207fa"));

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1ff98313-c611-463c-888b-2699858baf3b"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("42d9af50-88e4-46df-9392-e1ea60884c2e") },
                    { new Guid("6d207995-701f-429a-a4dd-8fd550539de0"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("1ef67211-920b-48b6-a9df-512c6ec85ef1") },
                    { new Guid("7f718c35-6bda-49b7-bf32-9708b18e7c0a"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("614baaa4-3b04-4864-a971-ea62da5e24b0") },
                    { new Guid("9ddd495b-8e5f-448f-b1f8-9f1ef187e007"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("69ad0aba-087c-48b0-a7ed-83d7cc9342fb") }
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("357ab6ba-b001-4faa-a151-bb3da1489453"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 18, 36, 32, 454, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("51007f20-0d48-493f-b163-d6f37d3bd562"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 18, 36, 32, 454, DateTimeKind.Local).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("72f3845c-ae64-4093-87ec-072b66a943d1"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 18, 36, 32, 454, DateTimeKind.Local).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b7fdfff4-bca6-411b-9b3e-1f1498c64f7b"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 18, 36, 32, 454, DateTimeKind.Local).AddTicks(3405));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("def472c2-1590-4b8d-afff-b84e42b0bbe2"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 18, 36, 32, 454, DateTimeKind.Local).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("e23e4a7c-72fa-499d-8495-a4ea54377aa8"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 18, 36, 32, 454, DateTimeKind.Local).AddTicks(3351));
        }
    }
}
