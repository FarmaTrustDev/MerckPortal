using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merck.Migrations
{
    public partial class User_Permission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "DeletedAt", "GlobalId", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, null, null, null, new Guid("92326b85-311a-418b-836e-cd28184d41e9"), "View", null, null },
                    { 2, true, null, null, null, new Guid("c42212d4-6a4b-46a1-a94d-26575b31e54f"), "Edit", null, null },
                    { 3, true, null, null, null, new Guid("cefaf8da-7070-44d7-b8db-f813b0d4f468"), "Delete", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "DeletedAt", "GlobalId", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, null, null, null, new Guid("d6421b18-05b6-4a75-8ede-a561eb0690d0"), "Admin", null, null },
                    { 2, true, null, null, null, new Guid("9afae10f-827d-41a8-a093-575b519d4826"), "Operator", null, null }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "GlobalId", "LastName" },
                values: new object[] { "Ahmed", new Guid("73389982-6bd1-4c68-8e3d-d51f4775fa2a"), "Hassan" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("477475ff-3b63-4ca1-9e2b-1fa9281844a4"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("0af6dc0b-c3b0-4086-a089-a5dc47f6b2cf"));

            migrationBuilder.InsertData(
                table: "PermissionRoles",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "DeletedAt", "GlobalId", "PermissionId", "RoleId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, null, null, null, new Guid("e183cab6-41db-4a13-a7fd-ddd7f61fcbb8"), 1, 1, null, null },
                    { 2, true, null, null, null, new Guid("883bce5c-38e7-46c5-a7fe-b8e46ed660b3"), 2, 1, null, null },
                    { 3, true, null, null, null, new Guid("5552c350-d419-40b6-82b5-5b4a7d3a9fe8"), 3, 1, null, null },
                    { 4, true, null, null, null, new Guid("828a2137-2549-4342-bbc8-585bde73c9a7"), 1, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "DeletedAt", "GlobalId", "RoleId", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[,]
                {
                    { 3, true, null, null, null, new Guid("5d311a41-7adb-455e-93dd-b27deb2b4081"), 1, null, null, 3 },
                    { 1, true, null, null, null, new Guid("598eb157-ebfc-4b43-b9b2-b9ed758f292d"), 2, null, null, 1 },
                    { 2, true, null, null, null, new Guid("50cf642e-abc4-4c08-a56b-3c8be683603f"), 2, null, null, 2 },
                    { 4, true, null, null, null, new Guid("a288f08f-8cb9-4d15-a958-bc274459d20b"), 2, null, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoles_PermissionId",
                table: "PermissionRoles",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoles_RoleId",
                table: "PermissionRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionRoles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "GlobalId", "LastName" },
                values: new object[] { "User", new Guid("5f7146e3-34d0-4c93-b387-873d22eb65a4"), "Ahmed" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("359713ae-fb53-4f53-b647-5c2d990e91c7"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("57eeeb95-26f9-48eb-82f3-eecd172122c6"));
        }
    }
}
