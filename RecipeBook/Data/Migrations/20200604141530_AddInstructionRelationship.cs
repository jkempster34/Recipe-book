using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBook.Data.Migrations
{
    public partial class AddInstructionRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipes_RecipeId",
                table: "Instruction");

            migrationBuilder.DropColumn(
                name: "IdentityGuid",
                table: "Authors");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Instruction",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUsername",
                table: "Authors",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipes_RecipeId",
                table: "Instruction",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipes_RecipeId",
                table: "Instruction");

            migrationBuilder.DropColumn(
                name: "IdentityUsername",
                table: "Authors");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Instruction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "IdentityGuid",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipes_RecipeId",
                table: "Instruction",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
