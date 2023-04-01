using FoodFinderAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFinderAPI.Configurations
{
    public class MealIngredientConfiguration : IEntityTypeConfiguration<MealIngredient>
    {
        public void Configure(EntityTypeBuilder<MealIngredient> builder)
        {
            builder.ToTable("MealIngredient", "fd"); // specify table name
            builder.HasKey(mi => mi.Id); // specify primary key

            // configure relationship with Meal
            builder.HasOne(mi => mi.Meal)
                   .WithMany(m => m.MealIngredients)
                   .HasForeignKey(mi => mi.MealId);

            // configure relationship with Ingredient
            builder.HasOne(mi => mi.Ingredient)
                   .WithMany(i => i.MealIngredients)
                   .HasForeignKey(mi => mi.IngredientId);

            // configure relationship with Allergy
            builder.HasMany(mi => mi.Allergies)
                   .WithMany(a => a.MealIngredients)
                   .UsingEntity<Dictionary<string, object>>(
                       "MealIngredientAllergy",
                       j => j.HasOne<Allergy>().WithMany().HasForeignKey("AllergyId"),
                       j => j.HasOne<MealIngredient>().WithMany().HasForeignKey("MealIngredientId"),
                       j =>
                       {
                           j.Property<int>("Id").UseIdentityColumn();
                           j.HasKey("Id");
                       }
                   );
        }
    }
}
