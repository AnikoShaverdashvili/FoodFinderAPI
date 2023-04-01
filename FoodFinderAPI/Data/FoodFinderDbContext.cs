using FoodFinderAPI.Configurations;
using FoodFinderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodFinderAPI.Data
{
    public class FoodFinderDbContext : DbContext
    {
        public FoodFinderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MealIngredient> MealIngredients { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AllergyConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IngredientConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MealConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MealIngredientConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserAllergyConfiguration).Assembly);
        }
    }


}
