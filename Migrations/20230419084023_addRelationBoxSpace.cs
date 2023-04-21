using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhobosReact.Migrations
{
    /// <inheritdoc />
    public partial class addRelationBoxSpace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentBoxId",
                table: "Boxes",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpaceId",
                table: "Boxes",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentBoxId",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "SpaceId",
                table: "Boxes");
        }
    }
}
