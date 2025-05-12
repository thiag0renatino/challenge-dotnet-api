using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace challenge_api_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RM556934");

            migrationBuilder.CreateTable(
                name: "MOTO",
                schema: "RM556934",
                columns: table => new
                {
                    ID_MOTO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PLACA = table.Column<string>(type: "VARCHAR2(7)", unicode: false, maxLength: 7, nullable: true),
                    MODELO = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    STATUS = table.Column<string>(type: "VARCHAR2(65)", unicode: false, maxLength: 65, nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTO", x => x.ID_MOTO);
                });

            migrationBuilder.CreateTable(
                name: "PATIO",
                schema: "RM556934",
                columns: table => new
                {
                    ID_PATIO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    LOCALIZACAO = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    DESCRICAO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATIO", x => x.ID_PATIO);
                });

            migrationBuilder.CreateTable(
                name: "MARCADOR_ARUCO_MOVEL",
                schema: "RM556934",
                columns: table => new
                {
                    ID_MARCADOR_MOVEL = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CODIGO_ARUCO = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    DATA_INSTALACAO = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOTO_ID_MOTO = table.Column<decimal>(type: "NUMBER(38)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARCADOR_ARUCO_MOVEL", x => x.ID_MARCADOR_MOVEL);
                    table.ForeignKey(
                        name: "SYS_C004862169",
                        column: x => x.MOTO_ID_MOTO,
                        principalSchema: "RM556934",
                        principalTable: "MOTO",
                        principalColumn: "ID_MOTO");
                });

            migrationBuilder.CreateTable(
                name: "MARCADOR_FIXO",
                schema: "RM556934",
                columns: table => new
                {
                    ID_MARCADOR_ARUCO_FIXO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CODIGO_ARUCO = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    X_POS = table.Column<decimal>(type: "FLOAT", nullable: true),
                    Y_POS = table.Column<decimal>(type: "FLOAT", nullable: true),
                    PATIO_ID_PATIO = table.Column<decimal>(type: "NUMBER(38)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARCADOR_FIXO", x => x.ID_MARCADOR_ARUCO_FIXO);
                    table.ForeignKey(
                        name: "SYS_C004862167",
                        column: x => x.PATIO_ID_PATIO,
                        principalSchema: "RM556934",
                        principalTable: "PATIO",
                        principalColumn: "ID_PATIO");
                });

            migrationBuilder.CreateTable(
                name: "POSICAO",
                schema: "RM556934",
                columns: table => new
                {
                    ID_POSICAO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    X_POS = table.Column<decimal>(type: "FLOAT", nullable: true),
                    Y_POS = table.Column<decimal>(type: "FLOAT", nullable: true),
                    DATA_HORA = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOTO_ID_MOTO = table.Column<decimal>(type: "NUMBER(38)", nullable: true),
                    PATIO_ID_PATIO = table.Column<decimal>(type: "NUMBER(38)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSICAO", x => x.ID_POSICAO);
                    table.ForeignKey(
                        name: "SYS_C004862164",
                        column: x => x.MOTO_ID_MOTO,
                        principalSchema: "RM556934",
                        principalTable: "MOTO",
                        principalColumn: "ID_MOTO");
                    table.ForeignKey(
                        name: "SYS_C004862165",
                        column: x => x.PATIO_ID_PATIO,
                        principalSchema: "RM556934",
                        principalTable: "PATIO",
                        principalColumn: "ID_PATIO");
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                schema: "RM556934",
                columns: table => new
                {
                    ID_USUARIO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    STATUS = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "'ativo'"),
                    PATIO_ID_PATIO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID_USUARIO);
                    table.ForeignKey(
                        name: "USUARIO_PATIO_FK",
                        column: x => x.PATIO_ID_PATIO,
                        principalSchema: "RM556934",
                        principalTable: "PATIO",
                        principalColumn: "ID_PATIO");
                });

            migrationBuilder.CreateTable(
                name: "MEDICAO_POSICAO",
                schema: "RM556934",
                columns: table => new
                {
                    ID_MEDICAO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DISTANCIA_M = table.Column<decimal>(type: "FLOAT", nullable: true),
                    POSICAO_ID_POSICAO = table.Column<decimal>(type: "NUMBER(38)", nullable: true),
                    MARCADOR_FIXO_ID_MARCADOR_ARUCO_FIXO = table.Column<decimal>(type: "NUMBER(38)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICAO_POSICAO", x => x.ID_MEDICAO);
                    table.ForeignKey(
                        name: "SYS_C004862171",
                        column: x => x.POSICAO_ID_POSICAO,
                        principalSchema: "RM556934",
                        principalTable: "POSICAO",
                        principalColumn: "ID_POSICAO");
                    table.ForeignKey(
                        name: "SYS_C004862172",
                        column: x => x.MARCADOR_FIXO_ID_MARCADOR_ARUCO_FIXO,
                        principalSchema: "RM556934",
                        principalTable: "MARCADOR_FIXO",
                        principalColumn: "ID_MARCADOR_ARUCO_FIXO");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MARCADOR_ARUCO_MOVEL_MOTO_ID_MOTO",
                schema: "RM556934",
                table: "MARCADOR_ARUCO_MOVEL",
                column: "MOTO_ID_MOTO");

            migrationBuilder.CreateIndex(
                name: "IX_MARCADOR_FIXO_PATIO_ID_PATIO",
                schema: "RM556934",
                table: "MARCADOR_FIXO",
                column: "PATIO_ID_PATIO");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICAO_POSICAO_MARCADOR_FIXO_ID_MARCADOR_ARUCO_FIXO",
                schema: "RM556934",
                table: "MEDICAO_POSICAO",
                column: "MARCADOR_FIXO_ID_MARCADOR_ARUCO_FIXO");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICAO_POSICAO_POSICAO_ID_POSICAO",
                schema: "RM556934",
                table: "MEDICAO_POSICAO",
                column: "POSICAO_ID_POSICAO");

            migrationBuilder.CreateIndex(
                name: "IX_MOTO_PLACA",
                schema: "RM556934",
                table: "MOTO",
                column: "PLACA",
                unique: true,
                filter: "\"PLACA\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_POSICAO_MOTO_ID_MOTO",
                schema: "RM556934",
                table: "POSICAO",
                column: "MOTO_ID_MOTO");

            migrationBuilder.CreateIndex(
                name: "IX_POSICAO_PATIO_ID_PATIO",
                schema: "RM556934",
                table: "POSICAO",
                column: "PATIO_ID_PATIO");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_EMAIL",
                schema: "RM556934",
                table: "USUARIO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_PATIO_ID_PATIO",
                schema: "RM556934",
                table: "USUARIO",
                column: "PATIO_ID_PATIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MARCADOR_ARUCO_MOVEL",
                schema: "RM556934");

            migrationBuilder.DropTable(
                name: "MEDICAO_POSICAO",
                schema: "RM556934");

            migrationBuilder.DropTable(
                name: "USUARIO",
                schema: "RM556934");

            migrationBuilder.DropTable(
                name: "POSICAO",
                schema: "RM556934");

            migrationBuilder.DropTable(
                name: "MARCADOR_FIXO",
                schema: "RM556934");

            migrationBuilder.DropTable(
                name: "MOTO",
                schema: "RM556934");

            migrationBuilder.DropTable(
                name: "PATIO",
                schema: "RM556934");
        }
    }
}
