# Food Finder API
This is an ASP.NET Core API for the Food Finder web application. The API allows users to search for meals and recipes that do not contain ingredients that they are allergic to.

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

# Dependencies
The Food Finder API uses the following dependencies:

Microsoft.AspNetCore.Mvc - A framework for building APIs with ASP.NET Core.
Microsoft.EntityFrameworkCore - An ORM for working with databases in ASP.NET Core.
Microsoft.EntityFrameworkCore.Sqlite - A SQLite provider for the Entity Framework Core.
Microsoft.EntityFrameworkCore.Design - Design-time support for Entity Framework Core.

# Contributing
If you would like to contribute to the Food Finder API, please create a pull request with your proposed changes. Before submitting your pull request, please make sure that your code meets the following criteria:

Your code follows the existing code style.
Your code does not introduce any new bugs or regressions.
Your code includes unit tests that cover any new functionality.


# License
The Food Finder API is released under the MIT License. See LICENSE.txt for more information.
