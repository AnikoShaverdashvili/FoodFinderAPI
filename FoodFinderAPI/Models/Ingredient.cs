using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFinderAPI.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public ICollection<MealIngredient> MealIngredients { get; set; }


    }
}
