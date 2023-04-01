using FoodFinderAPI.Models;
using FoodFinderAPI.Reposotories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealIngredientsController : ControllerBase
    {
        private readonly IGenericRepository<MealIngredient> _mealIngredientRepo;

        public MealIngredientsController(IGenericRepository<MealIngredient> mealIngredientRepo)
        {
            _mealIngredientRepo = mealIngredientRepo;
        }


        [HttpGet]

        public async Task<IEnumerable<MealIngredient>> GetIngredients()
        {
            return await _mealIngredientRepo.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MealIngredient>>GetIngredientById(int id)
        {
            var mealIngredient = await _mealIngredientRepo.GetByIdAsync(id);
            if(mealIngredient == null)
            {
                return NotFound();
            }
            return mealIngredient;
        }

        [HttpPost]
        public async Task<ActionResult<MealIngredient>>CreateMealIngredient(MealIngredient mealIngredient)
        {
            var createdIngredient = await _mealIngredientRepo.CreateAsync(mealIngredient);
            return CreatedAtAction(nameof(GetIngredientById), new {mealIngredient.Id},createdIngredient);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<MealIngredient>>UpdateMealIngredient(int id,MealIngredient mealIngredient)
        {
            if(id != mealIngredient.Id)
            {
                return NotFound();
            }
            await _mealIngredientRepo.UpdateAsync(mealIngredient);
            return mealIngredient;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MealIngredient>>DeleteMealIngredient(int id)
        {
            var mealIngredient = await _mealIngredientRepo.DeleteAsync(id);
            if (mealIngredient == null)
            {
                return NotFound();
            }
            return mealIngredient;
        }

    }
}
