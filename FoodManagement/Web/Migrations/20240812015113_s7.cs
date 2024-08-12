using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class s7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsComming",
                table: "Product",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("8324e518-cd71-44d6-8e86-7a9c769de145"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("614baaa4-3b04-4864-a971-ea62da5e24b0") },
                    { new Guid("839b7599-a369-430e-96bf-3f76b2cbff53"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("69ad0aba-087c-48b0-a7ed-83d7cc9342fb") },
                    { new Guid("ca093a18-46d0-4a9d-b6ab-61ffdaf40184"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("42d9af50-88e4-46df-9392-e1ea60884c2e") },
                    { new Guid("df409e02-003e-483c-b5be-775dc68148fa"), new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new Guid("1ef67211-920b-48b6-a9df-512c6ec85ef1") }
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("357ab6ba-b001-4faa-a151-bb3da1489453"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 12, 8, 51, 12, 761, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("51007f20-0d48-493f-b163-d6f37d3bd562"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 12, 8, 51, 12, 761, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("72f3845c-ae64-4093-87ec-072b66a943d1"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 12, 8, 51, 12, 761, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b7fdfff4-bca6-411b-9b3e-1f1498c64f7b"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 12, 8, 51, 12, 761, DateTimeKind.Local).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("def472c2-1590-4b8d-afff-b84e42b0bbe2"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 12, 8, 51, 12, 761, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("e23e4a7c-72fa-499d-8495-a4ea54377aa8"),
                column: "CreatedOn",
                value: new DateTime(2024, 8, 12, 8, 51, 12, 761, DateTimeKind.Local).AddTicks(4835));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("8324e518-cd71-44d6-8e86-7a9c769de145"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("839b7599-a369-430e-96bf-3f76b2cbff53"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("ca093a18-46d0-4a9d-b6ab-61ffdaf40184"));

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("df409e02-003e-483c-b5be-775dc68148fa"));

            migrationBuilder.DropColumn(
                name: "IsComming",
                table: "Product");

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
        }
    }
}
