using FoodFinderAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFinderAPI.Configurations
{
    public class UserAllergyConfiguration : IEntityTypeConfiguration<UserAllergy>
    {
        public void Configure(EntityTypeBuilder<UserAllergy> builder)
        {
            builder.ToTable("UserAllergy", "fd");
            builder.HasKey(ua => new { ua.UserId, ua.AllergyId });

            builder.HasOne(ua => ua.User)
                   .WithMany(u => u.UserAllergies)
                   .HasForeignKey(ua => ua.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ua => ua.Allergy)
                   .WithMany(a => a.UserAllergies)
                   .HasForeignKey(ua => ua.AllergyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
