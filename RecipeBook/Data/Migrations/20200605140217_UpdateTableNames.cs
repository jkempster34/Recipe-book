using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBook.Data.Migrations
{
    public partial class UpdateTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipes_RecipeId",
                table: "Instruction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instruction",
                table: "Instruction");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Instruction");

            migrationBuilder.RenameTable(
                name: "Instruction",
                newName: "Instructions");

            migrationBuilder.RenameIndex(
                name: "IX_Instruction_RecipeId",
                table: "Instructions",
                newName: "IX_Instructions_RecipeId");

            migrationBuilder.AddColumn<int>(
                name: "InstructionNumber",
                table: "Instructions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InstructionText",
                table: "Instructions",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructions",
                table: "Instructions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Recipes_RecipeId",
                table: "Instructions",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Recipes_RecipeId",
                table: "Instructions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructions",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "InstructionNumber",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "InstructionText",
                table: "Instructions");

            migrationBuilder.RenameTable(
                name: "Instructions",
                newName: "Instruction");

            migrationBuilder.RenameIndex(
                name: "IX_Instructions_RecipeId",
                table: "Instruction",
                newName: "IX_Instruction_RecipeId");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Instruction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instruction",
                table: "Instruction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipes_RecipeId",
                table: "Instruction",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
