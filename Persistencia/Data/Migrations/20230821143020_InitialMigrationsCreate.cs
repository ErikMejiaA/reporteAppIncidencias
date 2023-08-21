using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationsCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AreaIncidencias",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_areaIncidencia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaIncidencias", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Arl",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_arl = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arl", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_categoria = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Eps",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_eps = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eps", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EquipoPcs",
                columns: table => new
                {
                    Id_codigo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre_referenciaPc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Marca = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoPcs", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_genero = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_pais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoEmails",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_tipoEmail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmails", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoNivelIncidencias",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_tipoNivelIncidencia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNivelIncidencias", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoPersonas",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_tipoPersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersonas", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposSangre",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_tipoSangre = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSangre", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoTelefonoMoviles",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_tipoTelMov = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTelefonoMoviles", x => x.Id_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Salones",
                columns: table => new
                {
                    Id_codigo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre_salon = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capasidad = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_areaIncidenciaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salones", x => x.Id_codigo);
                    table.ForeignKey(
                        name: "FK_Salones_AreaIncidencias_Id_areaIncidenciaFK",
                        column: x => x.Id_areaIncidenciaFK,
                        principalTable: "AreaIncidencias",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RecursoHwSwPcs",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_recursoHwSwPc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Marca = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Version = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_categoriaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursoHwSwPcs", x => x.Id_codigo);
                    table.ForeignKey(
                        name: "FK_RecursoHwSwPcs_Categorias_Id_categoriaFK",
                        column: x => x.Id_categoriaFK,
                        principalTable: "Categorias",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_dep = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_paisFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id_codigo);
                    table.ForeignKey(
                        name: "FK_Departamentos_Paises_Id_paisFK",
                        column: x => x.Id_paisFK,
                        principalTable: "Paises",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id_codigo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre_puesto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_salonFK = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_equipoFK = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id_codigo);
                    table.ForeignKey(
                        name: "FK_Puestos_EquipoPcs_Id_equipoFK",
                        column: x => x.Id_equipoFK,
                        principalTable: "EquipoPcs",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Puestos_Salones_Id_salonFK",
                        column: x => x.Id_salonFK,
                        principalTable: "Salones",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EquipoPcRecursoHwSwPcs",
                columns: table => new
                {
                    Id_equipoFK = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_recursoHwSwPcFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoPcRecursoHwSwPcs", x => new { x.Id_equipoFK, x.Id_recursoHwSwPcFK });
                    table.ForeignKey(
                        name: "FK_EquipoPcRecursoHwSwPcs_EquipoPcs_Id_equipoFK",
                        column: x => x.Id_equipoFK,
                        principalTable: "EquipoPcs",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipoPcRecursoHwSwPcs_RecursoHwSwPcs_Id_recursoHwSwPcFK",
                        column: x => x.Id_recursoHwSwPcFK,
                        principalTable: "RecursoHwSwPcs",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_ciudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_departamentoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id_codigo);
                    table.ForeignKey(
                        name: "FK_Ciudades_Departamentos_Id_departamentoFK",
                        column: x => x.Id_departamentoFK,
                        principalTable: "Departamentos",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id_codigo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Nro_documento = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estrato_social = table.Column<int>(type: "int(2)", nullable: false),
                    Cargo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_ciudadFK = table.Column<int>(type: "int", nullable: false),
                    Id_generoFK = table.Column<int>(type: "int", nullable: false),
                    Id_tipoSangreFK = table.Column<int>(type: "int", nullable: false),
                    Id_tipoPersonaFK = table.Column<int>(type: "int", nullable: false),
                    Id_epsFK = table.Column<int>(type: "int", nullable: false),
                    Id_arlFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id_codigo);
                    table.ForeignKey(
                        name: "FK_Personas_Arl_Id_arlFK",
                        column: x => x.Id_arlFK,
                        principalTable: "Arl",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Ciudades_Id_ciudadFK",
                        column: x => x.Id_ciudadFK,
                        principalTable: "Ciudades",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Eps_Id_epsFK",
                        column: x => x.Id_epsFK,
                        principalTable: "Eps",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Generos_Id_generoFK",
                        column: x => x.Id_generoFK,
                        principalTable: "Generos",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_TipoPersonas_Id_tipoPersonaFK",
                        column: x => x.Id_tipoPersonaFK,
                        principalTable: "TipoPersonas",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_TiposSangre_Id_tipoSangreFK",
                        column: x => x.Id_tipoSangreFK,
                        principalTable: "TiposSangre",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Calle = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Carrera = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Letra = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Diagonal = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Barrio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nro_puerta = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo_residencia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_personaFK = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.Id_codigo);
                    table.ForeignKey(
                        name: "FK_Direcciones_Personas_Id_personaFK",
                        column: x => x.Id_personaFK,
                        principalTable: "Personas",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_incidencia = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha_reporte = table.Column<DateTime>(type: "datetime", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_categoriaFK = table.Column<int>(type: "int", nullable: false),
                    Id_tipoNivelIncidenciaFK = table.Column<int>(type: "int", nullable: false),
                    Id_areaIncidenciaFK = table.Column<int>(type: "int", nullable: false),
                    Id_salonFK = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_puestoFK = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_personaFK = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.Id_codigo);
                    table.ForeignKey(
                        name: "FK_Incidencias_AreaIncidencias_Id_areaIncidenciaFK",
                        column: x => x.Id_areaIncidenciaFK,
                        principalTable: "AreaIncidencias",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidencias_Categorias_Id_categoriaFK",
                        column: x => x.Id_categoriaFK,
                        principalTable: "Categorias",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidencias_Personas_Id_personaFK",
                        column: x => x.Id_personaFK,
                        principalTable: "Personas",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidencias_Puestos_Id_puestoFK",
                        column: x => x.Id_puestoFK,
                        principalTable: "Puestos",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidencias_Salones_Id_salonFK",
                        column: x => x.Id_salonFK,
                        principalTable: "Salones",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidencias_TipoNivelIncidencias_Id_tipoNivelIncidenciaFK",
                        column: x => x.Id_tipoNivelIncidenciaFK,
                        principalTable: "TipoNivelIncidencias",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonaEmails",
                columns: table => new
                {
                    Id_personaFK = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_tipoEmailFK = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaEmails", x => new { x.Id_personaFK, x.Id_tipoEmailFK });
                    table.ForeignKey(
                        name: "FK_PersonaEmails_Personas_Id_personaFK",
                        column: x => x.Id_personaFK,
                        principalTable: "Personas",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaEmails_TipoEmails_Id_tipoEmailFK",
                        column: x => x.Id_tipoEmailFK,
                        principalTable: "TipoEmails",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonaTelefonoMovils",
                columns: table => new
                {
                    Id_personaFK = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_tipoTelefonoMovilFK = table.Column<int>(type: "int", nullable: false),
                    Numero_telefonoMovil = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaTelefonoMovils", x => new { x.Id_personaFK, x.Id_tipoTelefonoMovilFK });
                    table.ForeignKey(
                        name: "FK_PersonaTelefonoMovils_Personas_Id_personaFK",
                        column: x => x.Id_personaFK,
                        principalTable: "Personas",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaTelefonoMovils_TipoTelefonoMoviles_Id_tipoTelefonoMov~",
                        column: x => x.Id_tipoTelefonoMovilFK,
                        principalTable: "TipoTelefonoMoviles",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadoIncidencias",
                columns: table => new
                {
                    Id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_incidenciaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoIncidencias", x => x.Id_codigo);
                    table.ForeignKey(
                        name: "FK_EstadoIncidencias_Incidencias_Id_incidenciaFK",
                        column: x => x.Id_incidenciaFK,
                        principalTable: "Incidencias",
                        principalColumn: "Id_codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AreaIncidencias_Nombre_areaIncidencia",
                table: "AreaIncidencias",
                column: "Nombre_areaIncidencia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Nombre_categoria",
                table: "Categorias",
                column: "Nombre_categoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_Id_departamentoFK",
                table: "Ciudades",
                column: "Id_departamentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_Nombre_ciudad",
                table: "Ciudades",
                column: "Nombre_ciudad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Id_paisFK",
                table: "Departamentos",
                column: "Id_paisFK");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Nombre_dep",
                table: "Departamentos",
                column: "Nombre_dep",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_Id_personaFK",
                table: "Direcciones",
                column: "Id_personaFK");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoPcRecursoHwSwPcs_Id_recursoHwSwPcFK",
                table: "EquipoPcRecursoHwSwPcs",
                column: "Id_recursoHwSwPcFK");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoPcs_Id_codigo",
                table: "EquipoPcs",
                column: "Id_codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipoPcs_Nombre_referenciaPc",
                table: "EquipoPcs",
                column: "Nombre_referenciaPc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadoIncidencias_Id_incidenciaFK",
                table: "EstadoIncidencias",
                column: "Id_incidenciaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_Nombre_genero",
                table: "Generos",
                column: "Nombre_genero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_Id_areaIncidenciaFK",
                table: "Incidencias",
                column: "Id_areaIncidenciaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_Id_categoriaFK",
                table: "Incidencias",
                column: "Id_categoriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_Id_personaFK",
                table: "Incidencias",
                column: "Id_personaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_Id_puestoFK",
                table: "Incidencias",
                column: "Id_puestoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_Id_salonFK",
                table: "Incidencias",
                column: "Id_salonFK");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_Id_tipoNivelIncidenciaFK",
                table: "Incidencias",
                column: "Id_tipoNivelIncidenciaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_Nombre_pais",
                table: "Paises",
                column: "Nombre_pais",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonaEmails_Email",
                table: "PersonaEmails",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonaEmails_Id_tipoEmailFK",
                table: "PersonaEmails",
                column: "Id_tipoEmailFK");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_arlFK",
                table: "Personas",
                column: "Id_arlFK");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_ciudadFK",
                table: "Personas",
                column: "Id_ciudadFK");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_codigo",
                table: "Personas",
                column: "Id_codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_epsFK",
                table: "Personas",
                column: "Id_epsFK");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_generoFK",
                table: "Personas",
                column: "Id_generoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_tipoPersonaFK",
                table: "Personas",
                column: "Id_tipoPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_tipoSangreFK",
                table: "Personas",
                column: "Id_tipoSangreFK");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaTelefonoMovils_Id_tipoTelefonoMovilFK",
                table: "PersonaTelefonoMovils",
                column: "Id_tipoTelefonoMovilFK");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_Id_codigo",
                table: "Puestos",
                column: "Id_codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_Id_equipoFK",
                table: "Puestos",
                column: "Id_equipoFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_Id_salonFK",
                table: "Puestos",
                column: "Id_salonFK");

            migrationBuilder.CreateIndex(
                name: "IX_RecursoHwSwPcs_Id_categoriaFK",
                table: "RecursoHwSwPcs",
                column: "Id_categoriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Salones_Id_areaIncidenciaFK",
                table: "Salones",
                column: "Id_areaIncidenciaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Salones_Id_codigo",
                table: "Salones",
                column: "Id_codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoPersonas_Nombre_tipoPersona",
                table: "TipoPersonas",
                column: "Nombre_tipoPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposSangre_Nombre_tipoSangre",
                table: "TiposSangre",
                column: "Nombre_tipoSangre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "EquipoPcRecursoHwSwPcs");

            migrationBuilder.DropTable(
                name: "EstadoIncidencias");

            migrationBuilder.DropTable(
                name: "PersonaEmails");

            migrationBuilder.DropTable(
                name: "PersonaTelefonoMovils");

            migrationBuilder.DropTable(
                name: "RecursoHwSwPcs");

            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "TipoEmails");

            migrationBuilder.DropTable(
                name: "TipoTelefonoMoviles");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "TipoNivelIncidencias");

            migrationBuilder.DropTable(
                name: "Arl");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Eps");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "TipoPersonas");

            migrationBuilder.DropTable(
                name: "TiposSangre");

            migrationBuilder.DropTable(
                name: "EquipoPcs");

            migrationBuilder.DropTable(
                name: "Salones");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "AreaIncidencias");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
