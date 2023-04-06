# Food Finder API
This is an ASP.NET Core API for the Food Finder web application. The API allows users to search for meals that do not contain ingredients that they are allergic to.

# Getting Started
To get started with the Food Finder API, follow these steps:

Clone the repository to your local machine.
Open the solution in Visual Studio.
Build the solution.
Run the application.

# Usage
The Food Finder API supports the following endpoints:

/api/meal - GET, POST, PUT, DELETE
/api/ingredient - GET, POST, PUT, DELETE
/api/user - GET, POST, PUT, DELETE
/api/userallergy - GET, POST, PUT, DELETE

# Models
The following models are used in the Food Finder API:

Meal - Represents a meal, including its name and list of ingredients.
Ingredient - Represents an ingredient, including its name and whether it is an allergen.
MealIngredient - Represents a relationship between a meal and an ingredient, including the quantity of the ingredient required.
User - Represents a user, including their name.
Allergy - Represents an allergy, including the name of the allergy.
UserAllergy - Represents a relationship between a user and an allergy.

# Controllers
The following controllers are used in the Food Finder API:

MealController - Provides endpoints for working with meals in the database.
IngredientController - Provides endpoints for working with ingredients in the database.
UserController - Provides endpoints for working with users in the database.
UserAllergyController - Provides endpoints for working with user allergies in the database.

