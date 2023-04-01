using FoodFinderAPI.Models;
using FoodFinderAPI.Reposotories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace FoodFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IGenericRepository<Meal> _mealRepository;

        public MealController(IGenericRepository<Meal> mealRepository)
        {
            _mealRepository = mealRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<Meal>> GetMealsAsync()
        {
            return await _mealRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetMealById(int id)
        {
            var meal = await _mealRepository.GetByIdAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            return meal;
        }

        [HttpPost]
        public async Task<ActionResult<Meal>> PostMeal(Meal meal)
        {
            var createMeal = await _mealRepository.CreateAsync(meal);
            return CreatedAtAction(nameof(GetMealById), new { createMeal.Id }, createMeal);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Meal>> UpdateMeal(int id, Meal meal)
        {
            if (id != meal.Id)
            {
                return BadRequest();
            }
            await _mealRepository.UpdateAsync(meal);
            return NoContent();

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Meal>> DeleteMeal(int id)
        {
            var meal = await _mealRepository.DeleteAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            return meal;
        }

        [HttpGet("filter")]
        public async Task<IEnumerable<Meal>> FindMeal(Expression<Func<Meal, bool>> predicate,[FromQuery] User user)
        {
            var meals = await _mealRepository.GetAllAsync();
            if (user != null && user.UserAllergies != null && user.UserAllergies.Any())
            {
                meals = meals.Where(m => !m.MealIngredients.Any(i => user.UserAllergies.Any(a => a.Id == i.Id)));
            }
            return meals;
        }

    }
}
