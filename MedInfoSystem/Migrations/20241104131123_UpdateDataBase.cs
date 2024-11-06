using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("16c8b249-3ce2-4dd4-acdf-48296bb2c63b"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8534), "Онколог" },
                    { new Guid("1badb30c-f3a6-4641-ac56-eae08c35567a"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8536), "Ортопед" },
                    { new Guid("1e16056e-aff2-428b-b92e-c935f6648401"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8543), "Хирург" },
                    { new Guid("53f0a983-6bdb-41b1-b6c8-656c4afb5975"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8508), "Анестезиолог-реаниматолог" },
                    { new Guid("5e38d2d8-51e8-4d59-b11a-7bd2fe12d668"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8516), "Невролог" },
                    { new Guid("65a3b39b-1339-45e1-a6ef-8da8d8b25c83"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8539), "Ревматолог" },
                    { new Guid("6c50bc6c-1b01-4024-9f01-b2ba931c80be"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8545), "Эндокринолог" },
                    { new Guid("8007162f-eec4-4683-a558-f317d100d3fc"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8513), "Инфекционист" },
                    { new Guid("a2f8289d-c805-44e4-90f0-649ec989428a"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8538), "Педиатр" },
                    { new Guid("a35bf7a9-a6e3-4e8d-baa1-48048f238f11"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8541), "Стоматолог" },
                    { new Guid("a38a2838-8247-4d79-8499-9d009e80f2b8"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8511), "Дерматовенеролог" },
                    { new Guid("c4216c22-ed51-4670-ad20-d0305115d55c"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8515), "Кардиолог" },
                    { new Guid("f4bcb23e-68ef-47a6-be57-fe1d0931fbc7"), new DateTime(2024, 11, 4, 13, 11, 22, 686, DateTimeKind.Utc).AddTicks(8503), "Акушер-гинеколог" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("16c8b249-3ce2-4dd4-acdf-48296bb2c63b"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("1badb30c-f3a6-4641-ac56-eae08c35567a"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("1e16056e-aff2-428b-b92e-c935f6648401"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("53f0a983-6bdb-41b1-b6c8-656c4afb5975"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("5e38d2d8-51e8-4d59-b11a-7bd2fe12d668"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("65a3b39b-1339-45e1-a6ef-8da8d8b25c83"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("6c50bc6c-1b01-4024-9f01-b2ba931c80be"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("8007162f-eec4-4683-a558-f317d100d3fc"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("a2f8289d-c805-44e4-90f0-649ec989428a"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("a35bf7a9-a6e3-4e8d-baa1-48048f238f11"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("a38a2838-8247-4d79-8499-9d009e80f2b8"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("c4216c22-ed51-4670-ad20-d0305115d55c"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("f4bcb23e-68ef-47a6-be57-fe1d0931fbc7"));

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
    }
}
