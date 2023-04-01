using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodFinderAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Ingredients_IngredientId",
                table: "MealIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Meals_MealId",
                table: "MealIngredients");

            migrationBuilder.DropTable(
                name: "AllergyMealIngredient");

            migrationBuilder.DropTable(
                name: "AllergyUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meals",
                table: "Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealIngredients",
                table: "MealIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies");

            migrationBuilder.EnsureSchema(
                name: "fb");

            migrationBuilder.EnsureSchema(
                name: "fd");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User",
                newSchema: "fd");

            migrationBuilder.RenameTable(
                name: "Meals",
                newName: "Meal",
                newSchema: "fd");

            migrationBuilder.RenameTable(
                name: "MealIngredients",
                newName: "MealIngredient",
                newSchema: "fd");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredient",
                newSchema: "fd");

            migrationBuilder.RenameTable(
                name: "Allergies",
                newName: "Allergy",
                newSchema: "fb");

            migrationBuilder.RenameIndex(
                name: "IX_MealIngredients_MealId",
                schema: "fd",
                table: "MealIngredient",
                newName: "IX_MealIngredient_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_MealIngredients_IngredientId",
                schema: "fd",
                table: "MealIngredient",
                newName: "IX_MealIngredient_IngredientId");

            migrationBuilder.AddColumn<int>(
                name: "AllergyId",
                schema: "fd",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "fd",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                schema: "fd",
                table: "Meal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealIngredient",
                schema: "fd",
                table: "MealIngredient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                schema: "fd",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergy",
                schema: "fb",
                table: "Allergy",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MealIngredientAllergy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergyId = table.Column<int>(type: "int", nullable: false),
                    MealIngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealIngredientAllergy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealIngredientAllergy_Allergy_AllergyId",
                        column: x => x.AllergyId,
                        principalSchema: "fb",
                        principalTable: "Allergy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealIngredientAllergy_MealIngredient_MealIngredientId",
                        column: x => x.MealIngredientId,
                        principalSchema: "fd",
                        principalTable: "MealIngredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAllergy",
                schema: "fd",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AllergyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAllergy", x => new { x.UserId, x.AllergyId });
                    table.ForeignKey(
                        name: "FK_UserAllergy_Allergy_AllergyId",
                        column: x => x.AllergyId,
                        principalSchema: "fb",
                        principalTable: "Allergy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAllergy_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "fd",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_AllergyId",
                schema: "fd",
                table: "User",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredientAllergy_AllergyId",
                table: "MealIngredientAllergy",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredientAllergy_MealIngredientId",
                table: "MealIngredientAllergy",
                column: "MealIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAllergy_AllergyId",
                schema: "fd",
                table: "UserAllergy",
                column: "AllergyId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredient_Ingredient_IngredientId",
                schema: "fd",
                table: "MealIngredient",
                column: "IngredientId",
                principalSchema: "fd",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredient_Meal_MealId",
                schema: "fd",
                table: "MealIngredient",
                column: "MealId",
                principalSchema: "fd",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Allergy_AllergyId",
                schema: "fd",
                table: "User",
                column: "AllergyId",
                principalSchema: "fb",
                principalTable: "Allergy",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredient_Ingredient_IngredientId",
                schema: "fd",
                table: "MealIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredient_Meal_MealId",
                schema: "fd",
                table: "MealIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Allergy_AllergyId",
                schema: "fd",
                table: "User");

            migrationBuilder.DropTable(
                name: "MealIngredientAllergy");

            migrationBuilder.DropTable(
                name: "UserAllergy",
                schema: "fd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "fd",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AllergyId",
                schema: "fd",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealIngredient",
                schema: "fd",
                table: "MealIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                schema: "fd",
                table: "Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                schema: "fd",
                table: "Ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergy",
                schema: "fb",
                table: "Allergy");

            migrationBuilder.DropColumn(
                name: "AllergyId",
                schema: "fd",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "fd",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "MealIngredient",
                schema: "fd",
                newName: "MealIngredients");

            migrationBuilder.RenameTable(
                name: "Meal",
                schema: "fd",
                newName: "Meals");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                schema: "fd",
                newName: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Allergy",
                schema: "fb",
                newName: "Allergies");

            migrationBuilder.RenameIndex(
                name: "IX_MealIngredient_MealId",
                table: "MealIngredients",
                newName: "IX_MealIngredients_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_MealIngredient_IngredientId",
                table: "MealIngredients",
                newName: "IX_MealIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealIngredients",
                table: "MealIngredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meals",
                table: "Meals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AllergyMealIngredient",
                columns: table => new
                {
                    AllergiesId = table.Column<int>(type: "int", nullable: false),
                    MealIngredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyMealIngredient", x => new { x.AllergiesId, x.MealIngredientsId });
                    table.ForeignKey(
                        name: "FK_AllergyMealIngredient_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergyMealIngredient_MealIngredients_MealIngredientsId",
                        column: x => x.MealIngredientsId,
                        principalTable: "MealIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergyUser",
                columns: table => new
                {
                    AllergiesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyUser", x => new { x.AllergiesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AllergyUser_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergyUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergyMealIngredient_MealIngredientsId",
                table: "AllergyMealIngredient",
                column: "MealIngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_AllergyUser_UsersId",
                table: "AllergyUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Ingredients_IngredientId",
                table: "MealIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Meals_MealId",
                table: "MealIngredients",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
