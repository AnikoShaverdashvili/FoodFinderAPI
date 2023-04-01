using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFinderAPI.Models
{
    public class Allergy
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<MealIngredient> MealIngredients { get; set; }
        public ICollection<UserAllergy> UserAllergies { get; set; }


    }
}
