using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoghanAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "M_Application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Application", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_KategoriLaporan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_KategoriLaporan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_Kelompoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Kelompoks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_StatusLaporan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_StatusLaporan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_StatusPegawai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_StatusPegawai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KelompokId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_M_Units_M_Kelompoks_KelompokId",
                        column: x => x.KelompokId,
                        principalTable: "M_Kelompoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NPP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    StatusPegawaiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_M_Users_M_StatusPegawai_StatusPegawaiId",
                        column: x => x.StatusPegawaiId,
                        principalTable: "M_StatusPegawai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_M_Users_M_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "M_Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TRX_LaporanHarian",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    KategoriLaporanId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreaterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRX_LaporanHarian", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRX_LaporanHarian_M_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "M_Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRX_LaporanHarian_M_KategoriLaporan_KategoriLaporanId",
                        column: x => x.KategoriLaporanId,
                        principalTable: "M_KategoriLaporan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRX_LaporanHarian_M_StatusLaporan_StatusId",
                        column: x => x.StatusId,
                        principalTable: "M_StatusLaporan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRX_LaporanHarian_M_Users_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LOG_ApprovalLaporan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaporanHarianId = table.Column<int>(type: "int", nullable: false),
                    ApproverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusLaporanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG_ApprovalLaporan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LOG_ApprovalLaporan_M_StatusLaporan_StatusLaporanId",
                        column: x => x.StatusLaporanId,
                        principalTable: "M_StatusLaporan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LOG_ApprovalLaporan_M_Users_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LOG_ApprovalLaporan_TRX_LaporanHarian_LaporanHarianId",
                        column: x => x.LaporanHarianId,
                        principalTable: "TRX_LaporanHarian",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TRX_AttachmentLaporan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaporanHarianId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRX_AttachmentLaporan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRX_AttachmentLaporan_TRX_LaporanHarian_LaporanHarianId",
                        column: x => x.LaporanHarianId,
                        principalTable: "TRX_LaporanHarian",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LOG_ApprovalLaporan_ApproverId",
                table: "LOG_ApprovalLaporan",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_LOG_ApprovalLaporan_LaporanHarianId",
                table: "LOG_ApprovalLaporan",
                column: "LaporanHarianId");

            migrationBuilder.CreateIndex(
                name: "IX_LOG_ApprovalLaporan_StatusLaporanId",
                table: "LOG_ApprovalLaporan",
                column: "StatusLaporanId");

            migrationBuilder.CreateIndex(
                name: "IX_M_Units_KelompokId",
                table: "M_Units",
                column: "KelompokId");

            migrationBuilder.CreateIndex(
                name: "IX_M_Users_StatusPegawaiId",
                table: "M_Users",
                column: "StatusPegawaiId");

            migrationBuilder.CreateIndex(
                name: "IX_M_Users_UnitId",
                table: "M_Users",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TRX_AttachmentLaporan_LaporanHarianId",
                table: "TRX_AttachmentLaporan",
                column: "LaporanHarianId");

            migrationBuilder.CreateIndex(
                name: "IX_TRX_LaporanHarian_ApplicationId",
                table: "TRX_LaporanHarian",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_TRX_LaporanHarian_CreaterId",
                table: "TRX_LaporanHarian",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_TRX_LaporanHarian_KategoriLaporanId",
                table: "TRX_LaporanHarian",
                column: "KategoriLaporanId");

            migrationBuilder.CreateIndex(
                name: "IX_TRX_LaporanHarian_StatusId",
                table: "TRX_LaporanHarian",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOG_ApprovalLaporan");

            migrationBuilder.DropTable(
                name: "TRX_AttachmentLaporan");

            migrationBuilder.DropTable(
                name: "TRX_LaporanHarian");

            migrationBuilder.DropTable(
                name: "M_Application");

            migrationBuilder.DropTable(
                name: "M_KategoriLaporan");

            migrationBuilder.DropTable(
                name: "M_StatusLaporan");

            migrationBuilder.DropTable(
                name: "M_Users");

            migrationBuilder.DropTable(
                name: "M_StatusPegawai");

            migrationBuilder.DropTable(
                name: "M_Units");

            migrationBuilder.DropTable(
                name: "M_Kelompoks");
        }
    }
}
