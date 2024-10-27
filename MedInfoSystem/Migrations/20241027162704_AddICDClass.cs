using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddICDClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("1d0aa415-f831-4611-a023-0467f7ed106e"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("233dffbd-d061-4a82-9fc6-88e353a9795a"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("2d36dabd-063f-4473-8819-864de0c84c5c"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("32498c4e-4b10-420e-8a89-9e9098fa78c3"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("5f594002-d4b0-404e-b4e6-31ccbcdba1bf"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("6784743a-f347-499d-b555-55aab2e91f71"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("8ac927e8-86bb-4242-844c-976e8989c7ea"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("8f8e0434-ba72-40d9-ac71-203468dbe0a6"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("9ab9bb5f-377a-4873-b46f-c10f5ccc9269"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("c68946cd-f03d-4bb9-999a-c680a515e448"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("dabbe804-5188-4a25-8a19-b7a3f570ab3c"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("e0dbaf8f-d87b-4b75-9d7e-4ad7b8ad2389"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("eb223e93-4b07-47ea-9717-8269677c0e3c"));

            migrationBuilder.CreateTable(
                name: "ICDs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UniqueIdentifier = table.Column<int>(type: "integer", nullable: false),
                    FieldSort = table.Column<string>(type: "text", nullable: false),
                    CodeICD = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    AdditionalCode = table.Column<int>(type: "integer", nullable: true),
                    Actual = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICDs", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ICDs");

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

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("1d0aa415-f831-4611-a023-0467f7ed106e"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9791), "Кардиолог" },
                    { new Guid("233dffbd-d061-4a82-9fc6-88e353a9795a"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9787), "Дерматовенеролог" },
                    { new Guid("2d36dabd-063f-4473-8819-864de0c84c5c"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9813), "Педиатр" },
                    { new Guid("32498c4e-4b10-420e-8a89-9e9098fa78c3"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9810), "Онколог" },
                    { new Guid("5f594002-d4b0-404e-b4e6-31ccbcdba1bf"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9781), "Акушер-гинеколог" },
                    { new Guid("6784743a-f347-499d-b555-55aab2e91f71"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9785), "Анестезиолог-реаниматолог" },
                    { new Guid("8ac927e8-86bb-4242-844c-976e8989c7ea"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9814), "Ревматолог" },
                    { new Guid("8f8e0434-ba72-40d9-ac71-203468dbe0a6"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9790), "Инфекционист" },
                    { new Guid("9ab9bb5f-377a-4873-b46f-c10f5ccc9269"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9819), "Эндокринолог" },
                    { new Guid("c68946cd-f03d-4bb9-999a-c680a515e448"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9793), "Невролог" },
                    { new Guid("dabbe804-5188-4a25-8a19-b7a3f570ab3c"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9811), "Ортопед" },
                    { new Guid("e0dbaf8f-d87b-4b75-9d7e-4ad7b8ad2389"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9816), "Стоматолог" },
                    { new Guid("eb223e93-4b07-47ea-9717-8269677c0e3c"), new DateTime(2024, 10, 23, 18, 41, 43, 607, DateTimeKind.Utc).AddTicks(9817), "Хирург" }
                });
        }
    }
}
