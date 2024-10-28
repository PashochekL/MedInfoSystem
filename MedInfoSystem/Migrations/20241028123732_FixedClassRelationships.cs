using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixedClassRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("0f31f314-f734-4ead-880d-de9a12932639"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("2be43929-aacc-4bcd-9a06-b1707022c142"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("386febec-fc28-412c-b00f-f66599c5da43"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("48e92120-991b-481c-be00-c6623075c668"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("4da8a738-3e4e-4570-89e1-b3d5b90a85b2"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("7b417b60-3aae-4ecd-84b0-5d73af1d995b"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("bba8cbca-4c17-4da2-aeb1-b5e85893c5a5"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("c431bf82-f3df-4093-b367-00ac52fbff28"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("d5cf4a7d-c171-4b71-b817-68d1c7f3c170"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("d8849ffe-f3ec-4ea9-adbf-4571100647c4"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("dfa5a4e8-176d-4c02-89ae-acb449430057"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("edd355e6-e50c-41ff-8dc8-7337076479fc"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("f52fc6f9-1cb3-42c8-8457-69cc04b8fac4"));

            migrationBuilder.AlterColumn<string>(
                name: "Conclusion",
                table: "Inspections",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("16eba5c8-c5b3-4a2f-acca-87915d3100c6"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9121), "Кардиолог" },
                    { new Guid("21201d71-00ab-434b-90e0-610a030bf852"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9151), "Стоматолог" },
                    { new Guid("29135838-af06-44da-89cd-f1a0c3187577"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9153), "Хирург" },
                    { new Guid("4bda086d-7d07-4421-8745-42ac8a0c15d2"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9106), "Акушер-гинеколог" },
                    { new Guid("6668cf41-9fdd-40d6-a1a9-9f74e3aaec32"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9149), "Ревматолог" },
                    { new Guid("6e391505-d630-46e3-b023-3a61e28cf400"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9123), "Невролог" },
                    { new Guid("7185a783-2873-4594-ae99-7027e381b1f2"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9116), "Дерматовенеролог" },
                    { new Guid("83243d0a-504d-45f1-9efc-1568b5034c72"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9112), "Анестезиолог-реаниматолог" },
                    { new Guid("a2a69975-af5f-4f9f-a4e7-05c675291d8b"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9147), "Педиатр" },
                    { new Guid("b8f2c7ee-5a13-495d-aec2-c06224ff0d68"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9155), "Эндокринолог" },
                    { new Guid("bd796efb-6103-4124-97d7-1960d7d66af7"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9119), "Инфекционист" },
                    { new Guid("cf95cb57-6283-4127-ad60-018643242f07"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9125), "Онколог" },
                    { new Guid("f74ac284-f2af-4102-a2bd-63de429588b1"), new DateTime(2024, 10, 28, 12, 37, 31, 708, DateTimeKind.Utc).AddTicks(9144), "Ортопед" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("16eba5c8-c5b3-4a2f-acca-87915d3100c6"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("21201d71-00ab-434b-90e0-610a030bf852"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("29135838-af06-44da-89cd-f1a0c3187577"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("4bda086d-7d07-4421-8745-42ac8a0c15d2"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("6668cf41-9fdd-40d6-a1a9-9f74e3aaec32"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("6e391505-d630-46e3-b023-3a61e28cf400"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("7185a783-2873-4594-ae99-7027e381b1f2"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("83243d0a-504d-45f1-9efc-1568b5034c72"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("a2a69975-af5f-4f9f-a4e7-05c675291d8b"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("b8f2c7ee-5a13-495d-aec2-c06224ff0d68"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("bd796efb-6103-4124-97d7-1960d7d66af7"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("cf95cb57-6283-4127-ad60-018643242f07"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("f74ac284-f2af-4102-a2bd-63de429588b1"));

            migrationBuilder.AlterColumn<int>(
                name: "Conclusion",
                table: "Inspections",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("0f31f314-f734-4ead-880d-de9a12932639"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9259), "Хирург" },
                    { new Guid("2be43929-aacc-4bcd-9a06-b1707022c142"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9221), "Акушер-гинеколог" },
                    { new Guid("386febec-fc28-412c-b00f-f66599c5da43"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9261), "Эндокринолог" },
                    { new Guid("48e92120-991b-481c-be00-c6623075c668"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9255), "Педиатр" },
                    { new Guid("4da8a738-3e4e-4570-89e1-b3d5b90a85b2"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9237), "Онколог" },
                    { new Guid("7b417b60-3aae-4ecd-84b0-5d73af1d995b"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9258), "Стоматолог" },
                    { new Guid("bba8cbca-4c17-4da2-aeb1-b5e85893c5a5"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9230), "Дерматовенеролог" },
                    { new Guid("c431bf82-f3df-4093-b367-00ac52fbff28"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9235), "Невролог" },
                    { new Guid("d5cf4a7d-c171-4b71-b817-68d1c7f3c170"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9227), "Анестезиолог-реаниматолог" },
                    { new Guid("d8849ffe-f3ec-4ea9-adbf-4571100647c4"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9234), "Кардиолог" },
                    { new Guid("dfa5a4e8-176d-4c02-89ae-acb449430057"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9232), "Инфекционист" },
                    { new Guid("edd355e6-e50c-41ff-8dc8-7337076479fc"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9253), "Ортопед" },
                    { new Guid("f52fc6f9-1cb3-42c8-8457-69cc04b8fac4"), new DateTime(2024, 10, 27, 16, 27, 4, 302, DateTimeKind.Utc).AddTicks(9256), "Ревматолог" }
                });
        }
    }
}
