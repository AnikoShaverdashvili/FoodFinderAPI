using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFinderAPI.Models
{
    public class Meal
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<MealIngredient> MealIngredients { get; set; }

    }
}
