using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class s1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aticle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Intro = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KeyWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aticle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Intro = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LoginName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Authorized",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorized", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authorized_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Authorized_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "ParentId" },
                values: new object[] { new Guid("357ab6ba-b001-4faa-a151-bb3da1489453"), new Guid("e23e4a7c-72fa-499d-8495-a4ea54377aa8"), new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(904), null, null, "Root", null });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), "Admin" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("51007f20-0d48-493f-b163-d6f37d3bd562"), new Guid("e23e4a7c-72fa-499d-8495-a4ea54377aa8"), new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(915), null, null, "Article", new Guid("357ab6ba-b001-4faa-a151-bb3da1489453") },
                    { new Guid("b7fdfff4-bca6-411b-9b3e-1f1498c64f7b"), new Guid("e23e4a7c-72fa-499d-8495-a4ea54377aa8"), new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(950), null, null, "Product", new Guid("357ab6ba-b001-4faa-a151-bb3da1489453") },
                    { new Guid("def472c2-1590-4b8d-afff-b84e42b0bbe2"), new Guid("e23e4a7c-72fa-499d-8495-a4ea54377aa8"), new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(906), null, null, "Authorized", new Guid("357ab6ba-b001-4faa-a151-bb3da1489453") }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "GroupId", "LastLogin", "LoginName", "ModifiedBy", "ModifiedOn", "Name", "Password", "Picture" },
                values: new object[] { new Guid("e23e4a7c-72fa-499d-8495-a4ea54377aa8"), null, new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(858), "ngoc.phuc@dla.edu.vn", new Guid("fec47abf-51ad-42b9-8538-286bb0ec93f1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ngoc.phuc", null, null, "Nguyen Ngoc Phuc", "c4ca4238a0b923820dcc509a6f75849b", "/img/users/avatar (1).png" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "ParentId" },
                values: new object[] { new Guid("72f3845c-ae64-4093-87ec-072b66a943d1"), new Guid("e23e4a7c-72fa-499d-8495-a4ea54377aa8"), new DateTime(2024, 8, 11, 16, 11, 25, 377, DateTimeKind.Local).AddTicks(911), null, null, "Nhom Quyen", new Guid("def472c2-1590-4b8d-afff-b84e42b0bbe2") });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CategoryId", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("1ef67211-920b-48b6-a9df-512c6ec85ef1"), new Guid("72f3845c-ae64-4093-87ec-072b66a943d1"), "view-groups", "Xem danh sach Nhom" },
                    { new Guid("42d9af50-88e4-46df-9392-e1ea60884c2e"), new Guid("72f3845c-ae64-4093-87ec-072b66a943d1"), "delete-group", "Xoa Nhom" },
                    { new Guid("614baaa4-3b04-4864-a971-ea62da5e24b0"), new Guid("72f3845c-ae64-4093-87ec-072b66a943d1"), "save-group", "Luu Nhom" },
                    { new Guid("69ad0aba-087c-48b0-a7ed-83d7cc9342fb"), new Guid("72f3845c-ae64-4093-87ec-072b66a943d1"), "edit-group", "Cap Nhat Nhom" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Authorized_GroupId",
                table: "Authorized",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorized_RoleId",
                table: "Authorized",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_GroupId",
                table: "Member",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CategoryId",
                table: "Role",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aticle");

            migrationBuilder.DropTable(
                name: "Authorized");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
