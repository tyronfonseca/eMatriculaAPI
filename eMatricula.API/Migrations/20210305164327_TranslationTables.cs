using Microsoft.EntityFrameworkCore.Migrations;

namespace eMatricula.API.Migrations
{
    public partial class TranslationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisitos_Courses_CourseId",
                table: "Requisitos");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisitos_Courses_CourseReqId",
                table: "Requisitos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requisitos",
                table: "Requisitos");

            migrationBuilder.RenameTable(
                name: "Requisitos",
                newName: "Requirements");

            migrationBuilder.RenameIndex(
                name: "IX_Requisitos_CourseReqId",
                table: "Requirements",
                newName: "IX_Requirements_CourseReqId");

            migrationBuilder.RenameIndex(
                name: "IX_Requisitos_CourseId",
                table: "Requirements",
                newName: "IX_Requirements_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requirements",
                table: "Requirements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Courses_CourseId",
                table: "Requirements",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Courses_CourseReqId",
                table: "Requirements",
                column: "CourseReqId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Courses_CourseId",
                table: "Requirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Courses_CourseReqId",
                table: "Requirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requirements",
                table: "Requirements");

            migrationBuilder.RenameTable(
                name: "Requirements",
                newName: "Requisitos");

            migrationBuilder.RenameIndex(
                name: "IX_Requirements_CourseReqId",
                table: "Requisitos",
                newName: "IX_Requisitos_CourseReqId");

            migrationBuilder.RenameIndex(
                name: "IX_Requirements_CourseId",
                table: "Requisitos",
                newName: "IX_Requisitos_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requisitos",
                table: "Requisitos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisitos_Courses_CourseId",
                table: "Requisitos",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisitos_Courses_CourseReqId",
                table: "Requisitos",
                column: "CourseReqId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
