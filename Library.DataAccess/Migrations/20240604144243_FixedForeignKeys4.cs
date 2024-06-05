using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixedForeignKeys4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategories_Books_BookId",
                table: "BookCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BookImage_Books_BookId",
                table: "BookImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookImage",
                table: "BookImage");

            migrationBuilder.RenameTable(
                name: "BookImage",
                newName: "BookImages");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategories_BookId",
                table: "BookCategories",
                newName: "IX_BookCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BookImage_BookId",
                table: "BookImages",
                newName: "IX_BookImages_BookId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookImages",
                table: "BookImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategories_Books_CategoryId",
                table: "BookCategories",
                column: "CategoryId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookImages_Books_BookId",
                table: "BookImages",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategories_Books_CategoryId",
                table: "BookCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BookImages_Books_BookId",
                table: "BookImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookImages",
                table: "BookImages");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "BookImages",
                newName: "BookImage");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BookCategories",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategories_CategoryId",
                table: "BookCategories",
                newName: "IX_BookCategories_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookImages_BookId",
                table: "BookImage",
                newName: "IX_BookImage_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookImage",
                table: "BookImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategories_Books_BookId",
                table: "BookCategories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookImage_Books_BookId",
                table: "BookImage",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
