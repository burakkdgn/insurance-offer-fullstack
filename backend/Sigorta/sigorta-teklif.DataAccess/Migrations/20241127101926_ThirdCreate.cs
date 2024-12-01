using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sigorta_teklif.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ThirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelPolicies");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SigortaPolicies");

            migrationBuilder.DropColumn(
                name: "InsuredName",
                table: "SigortaPolicies");

            migrationBuilder.DropColumn(
                name: "PolicyHolderName",
                table: "SigortaPolicies");

            migrationBuilder.DropColumn(
                name: "PolicyNumber",
                table: "SigortaPolicies");

            migrationBuilder.DropColumn(
                name: "PolicyType",
                table: "SigortaPolicies");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SigortaPolicies");

            migrationBuilder.RenameColumn(
                name: "PremiumAmount",
                table: "SigortaPolicies",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SigortaPolicies",
                newName: "PolicyID");

            migrationBuilder.AddColumn<bool>(
                name: "Offer",
                table: "SigortaPolicies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SigortaEttirenID",
                table: "SigortaPolicies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SigortaliID",
                table: "SigortaPolicies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicantID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SigortaPolicies_SigortaEttirenID",
                table: "SigortaPolicies",
                column: "SigortaEttirenID");

            migrationBuilder.CreateIndex(
                name: "IX_SigortaPolicies_SigortaliID",
                table: "SigortaPolicies",
                column: "SigortaliID");

            migrationBuilder.AddForeignKey(
                name: "FK_SigortaPolicies_Applicants_SigortaEttirenID",
                table: "SigortaPolicies",
                column: "SigortaEttirenID",
                principalTable: "Applicants",
                principalColumn: "ApplicantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SigortaPolicies_Applicants_SigortaliID",
                table: "SigortaPolicies",
                column: "SigortaliID",
                principalTable: "Applicants",
                principalColumn: "ApplicantID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SigortaPolicies_Applicants_SigortaEttirenID",
                table: "SigortaPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_SigortaPolicies_Applicants_SigortaliID",
                table: "SigortaPolicies");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_SigortaPolicies_SigortaEttirenID",
                table: "SigortaPolicies");

            migrationBuilder.DropIndex(
                name: "IX_SigortaPolicies_SigortaliID",
                table: "SigortaPolicies");

            migrationBuilder.DropColumn(
                name: "Offer",
                table: "SigortaPolicies");

            migrationBuilder.DropColumn(
                name: "SigortaEttirenID",
                table: "SigortaPolicies");

            migrationBuilder.DropColumn(
                name: "SigortaliID",
                table: "SigortaPolicies");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "SigortaPolicies",
                newName: "PremiumAmount");

            migrationBuilder.RenameColumn(
                name: "PolicyID",
                table: "SigortaPolicies",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SigortaPolicies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsuredName",
                table: "SigortaPolicies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PolicyHolderName",
                table: "SigortaPolicies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PolicyNumber",
                table: "SigortaPolicies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PolicyType",
                table: "SigortaPolicies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SigortaPolicies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TravelPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PremiumAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPolicies", x => x.Id);
                });
        }
    }
}
