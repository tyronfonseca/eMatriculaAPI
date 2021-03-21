using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eMatricula.API.Migrations
{
    public partial class RowVersions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Professors",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ProfessorCounselors",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Enrollment",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Courses",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Careers",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ProfessorCounselors");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Careers");
        }
    }
}
