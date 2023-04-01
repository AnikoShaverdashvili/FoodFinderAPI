namespace FoodFinderAPI.Models
{
    public class UserAllergy
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AllergyId { get; set; }
        public Allergy Allergy { get; set; }
    }

}
