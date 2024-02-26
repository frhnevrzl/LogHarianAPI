using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoghanAPI.Migrations
{
    public partial class AddJabatanAndRoletoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LOG_ApprovalLaporan_M_Users_ApproverId",
                table: "LOG_ApprovalLaporan");

            migrationBuilder.DropForeignKey(
                name: "FK_M_Users_M_StatusPegawai_StatusPegawaiId",
                table: "M_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_M_Users_M_Units_UnitId",
                table: "M_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_TRX_LaporanHarian_M_Users_CreaterId",
                table: "TRX_LaporanHarian");

            migrationBuilder.DropPrimaryKey(
                name: "PK_M_Users",
                table: "M_Users");

            migrationBuilder.DropIndex(
                name: "IX_LOG_ApprovalLaporan_ApproverId",
                table: "LOG_ApprovalLaporan");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "M_Users");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "LOG_ApprovalLaporan");

            migrationBuilder.AlterColumn<string>(
                name: "CreaterId",
                table: "TRX_LaporanHarian",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "M_Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusPegawaiId",
                table: "M_Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "M_Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JabatanId",
                table: "M_Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApproverNPP",
                table: "LOG_ApprovalLaporan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_M_Users",
                table: "M_Users",
                column: "Username");

            migrationBuilder.CreateTable(
                name: "M_Jabatan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Jabatan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_UserRole",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_UserRole", x => new { x.Username, x.RoleId });
                    table.ForeignKey(
                        name: "FK_M_UserRole_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_M_UserRole_M_Users_Username",
                        column: x => x.Username,
                        principalTable: "M_Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_M_Users_JabatanId",
                table: "M_Users",
                column: "JabatanId");

            migrationBuilder.CreateIndex(
                name: "IX_M_Users_Username",
                table: "M_Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_M_UserRole_RoleId",
                table: "M_UserRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_M_Users_M_Jabatan_JabatanId",
                table: "M_Users",
                column: "JabatanId",
                principalTable: "M_Jabatan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_M_Users_M_StatusPegawai_StatusPegawaiId",
                table: "M_Users",
                column: "StatusPegawaiId",
                principalTable: "M_StatusPegawai",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_M_Users_M_Units_UnitId",
                table: "M_Users",
                column: "UnitId",
                principalTable: "M_Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TRX_LaporanHarian_M_Users_CreaterId",
                table: "TRX_LaporanHarian",
                column: "CreaterId",
                principalTable: "M_Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_M_Users_M_Jabatan_JabatanId",
                table: "M_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_M_Users_M_StatusPegawai_StatusPegawaiId",
                table: "M_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_M_Users_M_Units_UnitId",
                table: "M_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_TRX_LaporanHarian_M_Users_CreaterId",
                table: "TRX_LaporanHarian");

            migrationBuilder.DropTable(
                name: "M_Jabatan");

            migrationBuilder.DropTable(
                name: "M_UserRole");

            migrationBuilder.DropTable(
                name: "M_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_M_Users",
                table: "M_Users");

            migrationBuilder.DropIndex(
                name: "IX_M_Users_JabatanId",
                table: "M_Users");

            migrationBuilder.DropIndex(
                name: "IX_M_Users_Username",
                table: "M_Users");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "M_Users");

            migrationBuilder.DropColumn(
                name: "JabatanId",
                table: "M_Users");

            migrationBuilder.DropColumn(
                name: "ApproverNPP",
                table: "LOG_ApprovalLaporan");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreaterId",
                table: "TRX_LaporanHarian",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "M_Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusPegawaiId",
                table: "M_Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "M_Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApproverId",
                table: "LOG_ApprovalLaporan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_M_Users",
                table: "M_Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LOG_ApprovalLaporan_ApproverId",
                table: "LOG_ApprovalLaporan",
                column: "ApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_LOG_ApprovalLaporan_M_Users_ApproverId",
                table: "LOG_ApprovalLaporan",
                column: "ApproverId",
                principalTable: "M_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_M_Users_M_StatusPegawai_StatusPegawaiId",
                table: "M_Users",
                column: "StatusPegawaiId",
                principalTable: "M_StatusPegawai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_M_Users_M_Units_UnitId",
                table: "M_Users",
                column: "UnitId",
                principalTable: "M_Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TRX_LaporanHarian_M_Users_CreaterId",
                table: "TRX_LaporanHarian",
                column: "CreaterId",
                principalTable: "M_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
