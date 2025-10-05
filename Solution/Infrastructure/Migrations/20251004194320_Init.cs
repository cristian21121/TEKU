using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SUPPLIER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOM_FIELD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOM_FIELD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CUSTOM_FIELD_SUPPLIER_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "SUPPLIER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HourValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SERVICE_SUPPLIER_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "SUPPLIER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_SERVICE_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "SERVICE",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_ServiceId",
                table: "Country",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOM_FIELD_SupplierId",
                table: "CUSTOM_FIELD",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICE_SupplierId",
                table: "SERVICE",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "CUSTOM_FIELD");

            migrationBuilder.DropTable(
                name: "SERVICE");

            migrationBuilder.DropTable(
                name: "SUPPLIER");
        }
    }
}
