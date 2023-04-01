using FoodFinderAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFinderAPI.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredient", "fd");
            builder.HasKey(x => x.Id);

            builder.HasMany(i => i.MealIngredients)
                .WithOne(mi => mi.Ingredient)
                .HasForeignKey(mi => mi.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}