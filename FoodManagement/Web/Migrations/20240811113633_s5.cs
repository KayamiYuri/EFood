using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class s5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("2059e034-33c5-47ab-b91f-91f2b0320596"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("6538e27f-0a61-4d7a-8df2-37b18f736a76"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("baf6a4af-201b-46a4-a7c4-e0243e301e90"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("bf6e2b5a-2328-42f4-91f1-1c3c47c2e2dc"));

            migrationBuilder.DropColumn(
                name: "Intro",
                table: "Aticle");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Intro",
                table: "Aticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("2059e034-33c5-47ab-b91f-91f2b0320596"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("614baaa4-3b04-4864-a971-ea62da5e24b0") },
                    { new Guid("6538e27f-0a61-4d7a-8df2-37b18f736a76"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("42d9af50-88e4-46df-9392-e1ea60884c2e") },
                    { new Guid("baf6a4af-201b-46a4-a7c4-e0243e301e90"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("1ef67211-920b-48b6-a9df-512c6ec85ef1") },
                    { new Guid("bf6e2b5a-2328-42f4-91f1-1c3c47c2e2dc"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("69ad0aba-087c-48b0-a7ed-83d7cc9342fb") }
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("357ab6ba-b001-4faa-a151-bb3da1489453"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("51007f20-0d48-493f-b163-d6f37d3bd562"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("72f3845c-ae64-4093-87ec-072b66a943d1"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b7fdfff4-bca6-411b-9b3e-1f1498c64f7b"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("def472c2-1590-4b8d-afff-b84e42b0bbe2"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("e23e4a7c-72fa-499d-8495-a4ea54377aa8"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(858));
        }
    }
}
