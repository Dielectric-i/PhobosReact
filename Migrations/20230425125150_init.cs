using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhobosReact.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Spaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaces", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    ParentBoxId = table.Column<Guid>(type: "char(36)", nullable: true),
                    SpaceDtoId = table.Column<Guid>(type: "char(36)", nullable: false),
                    BoxDtoId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boxes_Boxes_BoxDtoId",
                        column: x => x.BoxDtoId,
                        principalTable: "Boxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Boxes_Spaces_SpaceDtoId",
                        column: x => x.SpaceDtoId,
                        principalTable: "Spaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    BoxDtoId = table.Column<Guid>(type: "char(36)", nullable: true),
                    SpaceDtoId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Boxes_BoxDtoId",
                        column: x => x.BoxDtoId,
                        principalTable: "Boxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Spaces_SpaceDtoId",
                        column: x => x.SpaceDtoId,
                        principalTable: "Spaces",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_BoxDtoId",
                table: "Boxes",
                column: "BoxDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_SpaceDtoId",
                table: "Boxes",
                column: "SpaceDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BoxDtoId",
                table: "Items",
                column: "BoxDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SpaceDtoId",
                table: "Items",
                column: "SpaceDtoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "Spaces");
        }
    }
}
