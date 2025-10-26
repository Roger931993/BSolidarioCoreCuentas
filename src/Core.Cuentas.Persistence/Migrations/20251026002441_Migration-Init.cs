using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Cuentas.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "api_log_cuenta_header",
                schema: "dbo",
                columns: table => new
                {
                    api_log_cuenta_header_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_method = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    request_url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    response_code = table.Column<int>(type: "int", nullable: true),
                    id_tracking = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_api_log_cuenta_header", x => x.api_log_cuenta_header_id);
                });

            migrationBuilder.CreateTable(
                name: "cuenta",
                columns: table => new
                {
                    cuenta_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_cuenta = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    cliente_id = table.Column<int>(type: "int", nullable: true),
                    producto_id = table.Column<int>(type: "int", nullable: true),
                    agencia_id = table.Column<int>(type: "int", nullable: true),
                    moneda = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    tipo_cuenta = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    fecha_apertura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fecha_cierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    saldo_actual = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    saldo_disponible = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    tasa_interes = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    fecha_ultima_transaccion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_creacion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    estado = table.Column<int>(type: "int", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuenta", x => x.cuenta_id);
                });

            migrationBuilder.CreateTable(
                name: "secuencial",
                columns: table => new
                {
                    secuencial_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    valor = table.Column<int>(type: "int", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_secuencial", x => x.secuencial_id);
                });

            migrationBuilder.CreateTable(
                name: "api_log_cuenta_detail",
                schema: "dbo",
                columns: table => new
                {
                    api_log_cuenta_detail_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    api_log_cuenta_header_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_code = table.Column<int>(type: "int", nullable: true),
                    type_process = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    data_message = table.Column<string>(type: "text", maxLength: 300, nullable: true),
                    process_component = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_api_log_cuenta_detail", x => x.api_log_cuenta_detail_id);
                    table.ForeignKey(
                        name: "fk_cuenta_header_detail",
                        column: x => x.api_log_cuenta_header_id,
                        principalSchema: "dbo",
                        principalTable: "api_log_cuenta_header",
                        principalColumn: "api_log_cuenta_header_id");
                });

            migrationBuilder.CreateTable(
                name: "movimiento",
                columns: table => new
                {
                    movimiento_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cuenta_id = table.Column<int>(type: "int", nullable: true),
                    fecha_hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipo_movimiento = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    naturaleza = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    saldo_resultante = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    motivo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    referencia = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    estado_movimiento = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    estado = table.Column<int>(type: "int", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimiento", x => x.movimiento_id);
                    table.ForeignKey(
                        name: "FK_movimiento_cuenta_cuenta_id",
                        column: x => x.cuenta_id,
                        principalTable: "cuenta",
                        principalColumn: "cuenta_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_api_log_cuenta_detail_api_log_cuenta_header_id",
                schema: "dbo",
                table: "api_log_cuenta_detail",
                column: "api_log_cuenta_header_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_cuenta_id",
                table: "movimiento",
                column: "cuenta_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "api_log_cuenta_detail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "movimiento");

            migrationBuilder.DropTable(
                name: "secuencial");

            migrationBuilder.DropTable(
                name: "api_log_cuenta_header",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "cuenta");
        }
    }
}
