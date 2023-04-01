using FoodFinderAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFinderAPI.Configurations
{
    public class AllergyConfiguration : IEntityTypeConfiguration<Allergy>
    {
        public void Configure(EntityTypeBuilder<Allergy> builder)
        {
            builder.ToTable("Allergy", "fb");
            builder.HasKey(x => x.Id);
            builder.HasMany(a => a.UserAllergies)
                .WithOne(ua => ua.Allergy)
                .HasForeignKey(a => a.AllergyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
