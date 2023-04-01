using FoodFinderAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFinderAPI.Configurations
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.ToTable("Meal", "fd");
            builder.HasKey(x => x.Id);

            builder.HasMany(m => m.MealIngredients)
                .WithOne(mi => mi.Meal)
                .HasForeignKey(mi => mi.MealId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
