using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merck.Migrations
{
    public partial class Complete_Migraion_CreatedOn_BCTId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlockChainTransactionId",
                table: "FileLog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("ceada6c3-d567-405c-a483-3cbbf6807ef3"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("6e3631e0-20f1-48a9-a5d4-5112c99ff068"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("c32c3d53-ce99-49a3-9841-a45e94aac41a"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "GlobalId",
                value: new Guid("7ff16e39-d015-4dee-8a8e-4342480b7e11"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("1b237ddb-a651-43f9-84c2-d37b57e95c66"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("0086a073-aa51-46cc-a776-5abf1858a5a3"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("0f3adbdf-5a60-4cea-bb50-729d568b855c"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("f9012523-58fd-402b-9989-ebd41a7db320"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("3ea00894-9c11-4afb-9b2f-31720992d69c"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("28e89211-50aa-4a94-8917-ac4cfd33b40f"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("94b46501-ab7d-4e62-a008-1b3c572fcf4a"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("afabf00e-0bb0-4232-8b8f-8340af83913f"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("dacdedec-4fde-47b3-8ce1-d399012ab39d"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("65cc86ca-830c-443b-968e-83545f542564"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("d90021cc-e1a9-4d93-a7b9-093db9c1ac4b"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockChainTransactionId",
                table: "FileLog");

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("757009ee-36c9-4391-85de-f45a2ce87703"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("0e6c4d76-3ae2-4247-a644-4799b5f3e3b4"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("bc338801-b672-42a9-92f9-3eac3985779e"));

            migrationBuilder.UpdateData(
                table: "PermissionRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "GlobalId",
                value: new Guid("8eaebd0f-1521-4a6d-87e3-295d49c52ac5"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("8bd20297-28d9-4892-aed3-dd9e2e101c79"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("ab811d1c-c49a-4bdd-a727-b7b19f9d23df"));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("a28e0f1b-c895-419f-95b5-c5b45695d192"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("41ed8302-cd62-4b24-a2b0-2b29ff3722a7"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("9be4f432-6229-4eee-9779-83511cdc20b5"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("be62c816-b7f3-4f3c-a7f1-3ba1a84ada60"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("a83a4ffd-474a-4803-ab57-5baafacc6f9f"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("24d67c42-d107-4e7a-abd2-d09bd81a5593"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GlobalId",
                value: new Guid("6e6a7c40-e437-40e0-96d5-5d379bc63cd5"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GlobalId",
                value: new Guid("449f3a8e-1783-43fa-8f83-11d531280880"));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "GlobalId",
                value: new Guid("dcc5f2f2-6891-4ff0-b87f-811ef03e469d"));
        }
    }
}
