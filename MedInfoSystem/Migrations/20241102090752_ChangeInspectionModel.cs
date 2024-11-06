using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInspectionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("0f0af2f1-56ac-48ee-b712-839530c90d77"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("19e7995b-cabc-430a-9ccf-17b6c7465875"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("219efdb9-f5fe-4247-93b9-ca41f3244d03"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("38ec8cdf-db21-48e9-8a6b-834ef19137e8"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("453c7b23-c164-4bef-9d91-26a025cfa499"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("4d4dc5e0-4bd6-43d6-999a-ed5c7682cf45"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("61977184-c22e-47dd-a9de-035521a0b015"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("622741bd-4652-4c45-858e-f8fe32ff0a82"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("7b6e01ae-6b49-48e9-a5b6-706f79c2689c"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("7c77a89a-1a41-4256-bd72-51d91cfbca0b"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("9150701f-da80-4bed-88e0-83fb97a7a5ec"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("bc6437a4-6f97-4915-a000-315683620a37"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("e0f6ebaa-7d21-41e9-833a-8ecc138c08e0"));

            migrationBuilder.DropColumn(
                name: "LastVisitDate",
                table: "Inspections");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Inspections",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("235072f7-ce29-45e4-93e5-e5f398b70a5f"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2542), "Невролог" },
                    { new Guid("265f0b6d-83f5-4e57-acd0-cac9c5a9d70d"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2574), "Хирург" },
                    { new Guid("3199b206-9bba-4a79-95ee-7f5df580efda"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2522), "Акушер-гинеколог" },
                    { new Guid("3d963c65-1839-448f-8290-d52e0c9785fa"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2565), "Ортопед" },
                    { new Guid("4260350c-b147-4bf6-96d0-8af304cfdffe"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2540), "Кардиолог" },
                    { new Guid("5fef6ca1-4f3a-4274-b6fb-b0969e6dd26b"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2572), "Стоматолог" },
                    { new Guid("60e25948-6d19-428b-87a0-1daeb51241e9"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2567), "Педиатр" },
                    { new Guid("73d26c1c-fdc2-434d-b89c-3835b19e2684"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2576), "Эндокринолог" },
                    { new Guid("ac77e905-0fb9-4d79-95ca-944003a48855"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2535), "Дерматовенеролог" },
                    { new Guid("c8796829-7df1-4b23-8de4-6967935819b1"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2569), "Ревматолог" },
                    { new Guid("cdea51e1-2d5e-43e6-ae58-2ecfae981e9f"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2562), "Онколог" },
                    { new Guid("d4d931c6-bd21-44f3-8e65-b47d96e05338"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2532), "Анестезиолог-реаниматолог" },
                    { new Guid("e1ec8704-e3f0-4022-a338-8daaf0d801f9"), new DateTime(2024, 11, 2, 9, 7, 51, 756, DateTimeKind.Utc).AddTicks(2538), "Инфекционист" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("235072f7-ce29-45e4-93e5-e5f398b70a5f"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("265f0b6d-83f5-4e57-acd0-cac9c5a9d70d"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("3199b206-9bba-4a79-95ee-7f5df580efda"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("3d963c65-1839-448f-8290-d52e0c9785fa"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("4260350c-b147-4bf6-96d0-8af304cfdffe"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("5fef6ca1-4f3a-4274-b6fb-b0969e6dd26b"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("60e25948-6d19-428b-87a0-1daeb51241e9"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("73d26c1c-fdc2-434d-b89c-3835b19e2684"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("ac77e905-0fb9-4d79-95ca-944003a48855"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("c8796829-7df1-4b23-8de4-6967935819b1"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("cdea51e1-2d5e-43e6-ae58-2ecfae981e9f"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("d4d931c6-bd21-44f3-8e65-b47d96e05338"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("e1ec8704-e3f0-4022-a338-8daaf0d801f9"));

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Inspections");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastVisitDate",
                table: "Inspections",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("0f0af2f1-56ac-48ee-b712-839530c90d77"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(148), "Кардиолог" },
                    { new Guid("19e7995b-cabc-430a-9ccf-17b6c7465875"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(126), "Дерматовенеролог" },
                    { new Guid("219efdb9-f5fe-4247-93b9-ca41f3244d03"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(149), "Невролог" },
                    { new Guid("38ec8cdf-db21-48e9-8a6b-834ef19137e8"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(199), "Ревматолог" },
                    { new Guid("453c7b23-c164-4bef-9d91-26a025cfa499"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(146), "Инфекционист" },
                    { new Guid("4d4dc5e0-4bd6-43d6-999a-ed5c7682cf45"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(153), "Ортопед" },
                    { new Guid("61977184-c22e-47dd-a9de-035521a0b015"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(118), "Акушер-гинеколог" },
                    { new Guid("622741bd-4652-4c45-858e-f8fe32ff0a82"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(207), "Эндокринолог" },
                    { new Guid("7b6e01ae-6b49-48e9-a5b6-706f79c2689c"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(124), "Анестезиолог-реаниматолог" },
                    { new Guid("7c77a89a-1a41-4256-bd72-51d91cfbca0b"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(200), "Стоматолог" },
                    { new Guid("9150701f-da80-4bed-88e0-83fb97a7a5ec"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(205), "Хирург" },
                    { new Guid("bc6437a4-6f97-4915-a000-315683620a37"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(155), "Педиатр" },
                    { new Guid("e0f6ebaa-7d21-41e9-833a-8ecc138c08e0"), new DateTime(2024, 11, 1, 16, 42, 33, 282, DateTimeKind.Utc).AddTicks(151), "Онколог" }
                });
        }
    }
}
