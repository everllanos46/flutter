using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreAsignatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creditos = table.Column<int>(type: "int", nullable: false),
                    ProgramaAcademico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HDD = table.Column<int>(type: "int", nullable: false),
                    HTP = table.Column<int>(type: "int", nullable: false),
                    HTI = table.Column<int>(type: "int", nullable: false),
                    HTT = table.Column<int>(type: "int", nullable: false),
                    Prerequisitos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Corequisitos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoOferente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAsignatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Habilitable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Homologable = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SobreDocente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "PlanesViejos",
                columns: table => new
                {
                    CodigoPlanViejo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodigoPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAsignatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Presentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Justificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompetenciasGrales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompetenciasEspecificas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metodologias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivoGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivosEspecificos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estrategias = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesViejos", x => x.CodigoPlanViejo);
                });

            migrationBuilder.CreateTable(
                name: "PlanAsignaturas",
                columns: table => new
                {
                    CodigoPlan = table.Column<string>(type: "varchar(10)", nullable: false),
                    AsignaturaCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Presentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Justificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompetenciasGrales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompetenciasEspecificas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metodologias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivoGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivosEspecificos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estrategias = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanAsignaturas", x => x.CodigoPlan);
                    table.ForeignKey(
                        name: "FK_PlanAsignaturas_Asignaturas_AsignaturaCodigo",
                        column: x => x.AsignaturaCodigo,
                        principalTable: "Asignaturas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanSolicitud",
                columns: table => new
                {
                    CodigoPlanSolicitud = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodigoPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAsignatura = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Presentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Justificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompetenciasGrales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompetenciasEspecificas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metodologias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivoGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivosEspecificos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estrategias = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSolicitud", x => x.CodigoPlanSolicitud);
                    table.ForeignKey(
                        name: "FK_PlanSolicitud_Asignaturas_IdAsignatura",
                        column: x => x.IdAsignatura,
                        principalTable: "Asignaturas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    CodigoSolicitud = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlanSolicitudCodigoPlanSolicitud = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Solicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.CodigoSolicitud);
                    table.ForeignKey(
                        name: "FK_Solicitudes_PlanSolicitud_PlanSolicitudCodigoPlanSolicitud",
                        column: x => x.PlanSolicitudCodigoPlanSolicitud,
                        principalTable: "PlanSolicitud",
                        principalColumn: "CodigoPlanSolicitud",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanAsignaturas_AsignaturaCodigo",
                table: "PlanAsignaturas",
                column: "AsignaturaCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSolicitud_IdAsignatura",
                table: "PlanSolicitud",
                column: "IdAsignatura");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_PlanSolicitudCodigoPlanSolicitud",
                table: "Solicitudes",
                column: "PlanSolicitudCodigoPlanSolicitud");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropTable(
                name: "PlanAsignaturas");

            migrationBuilder.DropTable(
                name: "PlanesViejos");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "PlanSolicitud");

            migrationBuilder.DropTable(
                name: "Asignaturas");
        }
    }
}
