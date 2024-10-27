using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddRevokedToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("00261b73-461b-4301-b343-e9e755385ecd"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("35ed9da3-b212-4ef9-9e0a-44811be770ec"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("3749e7e9-0255-4b76-ad60-5a9c6e4cdeea"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("533a4457-cb20-45ee-881a-98eb43a32b54"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("57163c84-11be-4a05-9313-ea583f4a1de3"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("77f422b7-fe13-4653-8dcb-1b4ddbbe5fd5"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("78dfe648-3829-48b3-9c76-d0b0987647e8"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("7de43cb8-b34a-4455-9cf6-b2d54f40597d"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("851e66ed-e55a-4e0f-b855-1f0bf7f16ad4"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("a769f80d-9385-4a78-b189-5b565d54c82b"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("d0da12fb-2bb4-417b-b1ba-eb7d7da45ce0"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("d5a52689-999c-46ae-a413-2b838b907c75"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("eee10541-6d2b-4afe-9ba5-175225614561"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RevokedTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevokedTokens", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevokedTokens");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("00261b73-461b-4301-b343-e9e755385ecd"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8454), "Инфекционист" },
                    { new Guid("35ed9da3-b212-4ef9-9e0a-44811be770ec"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8446), "Акушер-гинеколог" },
                    { new Guid("3749e7e9-0255-4b76-ad60-5a9c6e4cdeea"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8483), "Эндокринолог" },
                    { new Guid("533a4457-cb20-45ee-881a-98eb43a32b54"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8480), "Стоматолог" },
                    { new Guid("57163c84-11be-4a05-9313-ea583f4a1de3"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8479), "Ревматолог" },
                    { new Guid("77f422b7-fe13-4653-8dcb-1b4ddbbe5fd5"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8477), "Педиатр" },
                    { new Guid("78dfe648-3829-48b3-9c76-d0b0987647e8"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8482), "Хирург" },
                    { new Guid("7de43cb8-b34a-4455-9cf6-b2d54f40597d"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8450), "Анестезиолог-реаниматолог" },
                    { new Guid("851e66ed-e55a-4e0f-b855-1f0bf7f16ad4"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8452), "Дерматовенеролог" },
                    { new Guid("a769f80d-9385-4a78-b189-5b565d54c82b"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8456), "Кардиолог" },
                    { new Guid("d0da12fb-2bb4-417b-b1ba-eb7d7da45ce0"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8476), "Ортопед" },
                    { new Guid("d5a52689-999c-46ae-a413-2b838b907c75"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8458), "Невролог" },
                    { new Guid("eee10541-6d2b-4afe-9ba5-175225614561"), new DateTime(2024, 10, 22, 13, 58, 3, 393, DateTimeKind.Utc).AddTicks(8460), "Онколог" }
                });
        }
    }
}
