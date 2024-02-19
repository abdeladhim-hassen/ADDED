using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADDED.API.Migrations
{
    public partial class finalVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anomalies",
                columns: table => new
                {
                    IdAno = table.Column<string>(nullable: false),
                    LibAno = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anomalies", x => x.IdAno);
                });

            migrationBuilder.CreateTable(
                name: "BASE20231",
                columns: table => new
                {
                    DIST = table.Column<int>(nullable: false),
                    TOU = table.Column<int>(nullable: false),
                    ORD = table.Column<int>(nullable: false),
                    ZAN = table.Column<int>(nullable: true),
                    ZTRI = table.Column<int>(nullable: true),
                    ZTIER = table.Column<int>(nullable: true),
                    ZSIX = table.Column<int>(nullable: true),
                    POL = table.Column<string>(nullable: true),
                    POSIT = table.Column<int>(nullable: true),
                    CATEG = table.Column<int>(nullable: true),
                    NOMADR = table.Column<string>(nullable: true),
                    CODONAS = table.Column<int>(nullable: true),
                    CODCTR = table.Column<int>(nullable: true),
                    CODMARQ = table.Column<int>(nullable: true),
                    NUMCTR = table.Column<string>(nullable: true),
                    CODONAN = table.Column<int>(nullable: true),
                    AINDEX = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    RELEVE = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    CONSMOY = table.Column<decimal>(type: "numeric(6, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASE20231", x => new { x.DIST, x.TOU, x.ORD });
                });

            migrationBuilder.CreateTable(
                name: "BASECPTR",
                columns: table => new
                {
                    DIST = table.Column<int>(nullable: false),
                    TOU = table.Column<int>(nullable: false),
                    ORD = table.Column<int>(nullable: false),
                    CODCTR = table.Column<int>(nullable: true),
                    CODMARQ = table.Column<int>(nullable: true),
                    CLE3 = table.Column<string>(maxLength: 17, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASECPTR", x => new { x.DIST, x.TOU, x.ORD });
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    CodDist = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomDist = table.Column<string>(nullable: true),
                    AdrDist = table.Column<string>(nullable: true),
                    TelDist = table.Column<string>(nullable: true),
                    MailDist = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.CodDist);
                });

            migrationBuilder.CreateTable(
                name: "HISTO1",
                columns: table => new
                {
                    ZDIS = table.Column<int>(nullable: false),
                    ZTOU = table.Column<int>(nullable: false),
                    ZORD = table.Column<int>(nullable: false),
                    ZTRIM = table.Column<int>(nullable: false),
                    ZANNE = table.Column<int>(nullable: false),
                    ZPOL = table.Column<string>(nullable: true),
                    ZCONS = table.Column<decimal>(type: "decimal(6,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTO1", x => new { x.ZDIS, x.ZTOU, x.ZORD, x.ZTRIM, x.ZANNE });
                });

            migrationBuilder.CreateTable(
                name: "Creations",
                columns: table => new
                {
                    IdCrea = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAno = table.Column<string>(nullable: true),
                    CreaNumCtr = table.Column<string>(nullable: true),
                    CreaAdressse = table.Column<string>(nullable: true),
                    CreaTour = table.Column<int>(nullable: true),
                    CreaOrdr = table.Column<int>(nullable: true),
                    CreaIndex = table.Column<decimal>(type: "decimal(6,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creations", x => x.IdCrea);
                    table.ForeignKey(
                        name: "FK_Creations_Anomalies_IdAno",
                        column: x => x.IdAno,
                        principalTable: "Anomalies",
                        principalColumn: "IdAno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChefBureau",
                columns: table => new
                {
                    IdChef = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodDist = table.Column<int>(nullable: false),
                    NomChef = table.Column<string>(nullable: true),
                    PrenomChef = table.Column<string>(nullable: true),
                    TelChef = table.Column<int>(nullable: false),
                    MailChef = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefBureau", x => x.IdChef);
                    table.ForeignKey(
                        name: "FK_ChefBureau_Districts_CodDist",
                        column: x => x.CodDist,
                        principalTable: "Districts",
                        principalColumn: "CodDist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localites",
                columns: table => new
                {
                    CodLocalite = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodDist = table.Column<int>(nullable: false),
                    LibLocalite = table.Column<string>(nullable: true),
                    TelLocalite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localites", x => x.CodLocalite);
                    table.ForeignKey(
                        name: "FK_Localites_Districts_CodDist",
                        column: x => x.CodDist,
                        principalTable: "Districts",
                        principalColumn: "CodDist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChoixPlans",
                columns: table => new
                {
                    IdPeriode = table.Column<string>(nullable: false),
                    IdChef = table.Column<int>(nullable: false),
                    DatExploi = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoixPlans", x => x.IdPeriode);
                    table.ForeignKey(
                        name: "FK_ChoixPlans_ChefBureau_IdChef",
                        column: x => x.IdChef,
                        principalTable: "ChefBureau",
                        principalColumn: "IdChef",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Releveurs",
                columns: table => new
                {
                    IdReleveur = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodLocalite = table.Column<int>(nullable: false),
                    TSPUsername = table.Column<string>(nullable: true),
                    TSPPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releveurs", x => x.IdReleveur);
                    table.ForeignKey(
                        name: "FK_Releveurs_Localites_CodLocalite",
                        column: x => x.CodLocalite,
                        principalTable: "Localites",
                        principalColumn: "CodLocalite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portables",
                columns: table => new
                {
                    IdPort = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdReleveur = table.Column<int>(nullable: true),
                    MarquePort = table.Column<string>(nullable: true),
                    EtatPort = table.Column<int>(nullable: true),
                    DatAffect = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portables", x => x.IdPort);
                    table.ForeignKey(
                        name: "FK_Portables_Releveurs_IdReleveur",
                        column: x => x.IdReleveur,
                        principalTable: "Releveurs",
                        principalColumn: "IdReleveur",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tournees",
                columns: table => new
                {
                    IdTour = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tour = table.Column<int>(nullable: false),
                    IdReleveur = table.Column<int>(nullable: true),
                    IdChef = table.Column<int>(nullable: true),
                    IdPeriode = table.Column<string>(nullable: true),
                    DatAffect = table.Column<DateTime>(nullable: true),
                    Etat = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournees", x => x.IdTour);
                    table.ForeignKey(
                        name: "FK_Tournees_ChefBureau_IdChef",
                        column: x => x.IdChef,
                        principalTable: "ChefBureau",
                        principalColumn: "IdChef",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tournees_ChoixPlans_IdPeriode",
                        column: x => x.IdPeriode,
                        principalTable: "ChoixPlans",
                        principalColumn: "IdPeriode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tournees_Releveurs_IdReleveur",
                        column: x => x.IdReleveur,
                        principalTable: "Releveurs",
                        principalColumn: "IdReleveur",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detailles",
                columns: table => new
                {
                    IdOrdr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTour = table.Column<int>(nullable: false),
                    Ordre = table.Column<int>(nullable: true),
                    Police = table.Column<string>(nullable: true),
                    NomAbn = table.Column<string>(nullable: true),
                    AdrAbn = table.Column<string>(nullable: true),
                    Marche = table.Column<byte>(nullable: true),
                    Resilie = table.Column<byte>(nullable: true),
                    CodeUsage = table.Column<int>(nullable: true),
                    AncienIndex = table.Column<decimal>(type: "decimal(6,0)", nullable: true),
                    Categ = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detailles", x => x.IdOrdr);
                    table.ForeignKey(
                        name: "FK_Detailles_Tournees_IdTour",
                        column: x => x.IdTour,
                        principalTable: "Tournees",
                        principalColumn: "IdTour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compteurs",
                columns: table => new
                {
                    IdCtr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdOrdr = table.Column<int>(nullable: false),
                    CodeCtr = table.Column<int>(nullable: true),
                    DiamCtr = table.Column<int>(nullable: true),
                    NumCtr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compteurs", x => x.IdCtr);
                    table.ForeignKey(
                        name: "FK_Compteurs_Detailles_IdOrdr",
                        column: x => x.IdOrdr,
                        principalTable: "Detailles",
                        principalColumn: "IdOrdr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historiques",
                columns: table => new
                {
                    IdHisto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdOrdr = table.Column<int>(nullable: false),
                    TrimHisto = table.Column<int>(nullable: true),
                    AnHisto = table.Column<int>(nullable: true),
                    ConsHisto = table.Column<decimal>(type: "decimal(6,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiques", x => x.IdHisto);
                    table.ForeignKey(
                        name: "FK_Historiques_Detailles_IdOrdr",
                        column: x => x.IdOrdr,
                        principalTable: "Detailles",
                        principalColumn: "IdOrdr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Indexs",
                columns: table => new
                {
                    IdIndex = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdOrdr = table.Column<int>(nullable: false),
                    NouvIndex = table.Column<decimal>(type: "decimal(6,0)", nullable: true),
                    DatIndex = table.Column<DateTime>(nullable: true),
                    Observ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indexs", x => x.IdIndex);
                    table.ForeignKey(
                        name: "FK_Indexs_Detailles_IdOrdr",
                        column: x => x.IdOrdr,
                        principalTable: "Detailles",
                        principalColumn: "IdOrdr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListAnomalies",
                columns: table => new
                {
                    ListAno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAno = table.Column<string>(nullable: true),
                    IdOrdr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListAnomalies", x => x.ListAno);
                    table.ForeignKey(
                        name: "FK_ListAnomalies_Anomalies_IdAno",
                        column: x => x.IdAno,
                        principalTable: "Anomalies",
                        principalColumn: "IdAno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListAnomalies_Detailles_IdOrdr",
                        column: x => x.IdOrdr,
                        principalTable: "Detailles",
                        principalColumn: "IdOrdr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChefBureau_CodDist",
                table: "ChefBureau",
                column: "CodDist");

            migrationBuilder.CreateIndex(
                name: "IX_ChoixPlans_IdChef",
                table: "ChoixPlans",
                column: "IdChef");

            migrationBuilder.CreateIndex(
                name: "IX_Compteurs_IdOrdr",
                table: "Compteurs",
                column: "IdOrdr");

            migrationBuilder.CreateIndex(
                name: "IX_Creations_IdAno",
                table: "Creations",
                column: "IdAno");

            migrationBuilder.CreateIndex(
                name: "IX_Detailles_IdTour",
                table: "Detailles",
                column: "IdTour");

            migrationBuilder.CreateIndex(
                name: "IX_Historiques_IdOrdr",
                table: "Historiques",
                column: "IdOrdr");

            migrationBuilder.CreateIndex(
                name: "IX_Indexs_IdOrdr",
                table: "Indexs",
                column: "IdOrdr");

            migrationBuilder.CreateIndex(
                name: "IX_ListAnomalies_IdAno",
                table: "ListAnomalies",
                column: "IdAno");

            migrationBuilder.CreateIndex(
                name: "IX_ListAnomalies_IdOrdr",
                table: "ListAnomalies",
                column: "IdOrdr");

            migrationBuilder.CreateIndex(
                name: "IX_Localites_CodDist",
                table: "Localites",
                column: "CodDist");

            migrationBuilder.CreateIndex(
                name: "IX_Portables_IdReleveur",
                table: "Portables",
                column: "IdReleveur",
                unique: true,
                filter: "[IdReleveur] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Releveurs_CodLocalite",
                table: "Releveurs",
                column: "CodLocalite");

            migrationBuilder.CreateIndex(
                name: "IX_Tournees_IdChef",
                table: "Tournees",
                column: "IdChef");

            migrationBuilder.CreateIndex(
                name: "IX_Tournees_IdPeriode",
                table: "Tournees",
                column: "IdPeriode");

            migrationBuilder.CreateIndex(
                name: "IX_Tournees_IdReleveur",
                table: "Tournees",
                column: "IdReleveur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BASE20231");

            migrationBuilder.DropTable(
                name: "BASECPTR");

            migrationBuilder.DropTable(
                name: "Compteurs");

            migrationBuilder.DropTable(
                name: "Creations");

            migrationBuilder.DropTable(
                name: "HISTO1");

            migrationBuilder.DropTable(
                name: "Historiques");

            migrationBuilder.DropTable(
                name: "Indexs");

            migrationBuilder.DropTable(
                name: "ListAnomalies");

            migrationBuilder.DropTable(
                name: "Portables");

            migrationBuilder.DropTable(
                name: "Anomalies");

            migrationBuilder.DropTable(
                name: "Detailles");

            migrationBuilder.DropTable(
                name: "Tournees");

            migrationBuilder.DropTable(
                name: "ChoixPlans");

            migrationBuilder.DropTable(
                name: "Releveurs");

            migrationBuilder.DropTable(
                name: "ChefBureau");

            migrationBuilder.DropTable(
                name: "Localites");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
