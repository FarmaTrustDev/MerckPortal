using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merck.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    GlobalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DOB = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "Address", "City", "CreatedAt", "CreatedBy", "DOB", "DeletedAt", "Email", "FirstName", "Gender", "GlobalId", "LastName", "Password", "Phone", "PostCode", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { 1, true, null, null, null, null, null, null, "ahmed@gmail.com", "User", (byte)0, new Guid("3526463f-4ba5-4120-a160-7cffc59a8167"), "Ahmed", "sf/WPJ/YEvZZrFchRMF92A==", null, null, null, null, "AhmedHassan" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "Address", "City", "CreatedAt", "CreatedBy", "DOB", "DeletedAt", "Email", "FirstName", "Gender", "GlobalId", "LastName", "Password", "Phone", "PostCode", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { 2, true, null, null, null, null, null, null, "paige@loop.com", "Paige", (byte)0, new Guid("2d836b5c-043c-4d1f-85a8-a0b00874d335"), "Turner", "sf/WPJ/YEvZZrFchRMF92A==", null, null, null, null, "PaigeTurner" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "Address", "City", "CreatedAt", "CreatedBy", "DOB", "DeletedAt", "Email", "FirstName", "Gender", "GlobalId", "LastName", "Password", "Phone", "PostCode", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { 3, true, null, null, null, null, null, null, "raja@loop.com", "Raja", (byte)0, new Guid("fde141cc-e840-4148-84b9-8b70eb626934"), "Sharif", "sf/WPJ/YEvZZrFchRMF92A==", null, null, null, null, "RajaSharif" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
