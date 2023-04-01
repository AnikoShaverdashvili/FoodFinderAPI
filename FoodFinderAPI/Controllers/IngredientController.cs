using FoodFinderAPI.Models;
using FoodFinderAPI.Reposotories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly GenericRepository<Ingredient> _ingredientRepository;

        public IngredientController(GenericRepository<Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
           return await _ingredientRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredientById(int id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return ingredient;
        }

        [HttpPost]

        public async Task<ActionResult<Ingredient>>CreateIngredient(Ingredient ingredient)
        {
            var createIngredient = await _ingredientRepository.CreateAsync(ingredient);
            return CreatedAtAction(nameof(GetIngredientById), new { createIngredient.Id }, createIngredient);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Ingredient>>UpdateIngredient(int id,Ingredient ingredient)
        {
            if(id != ingredient.Id){
                return NotFound();
            }
            await _ingredientRepository.UpdateAsync(ingredient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Ingredient>>DeleteIngredient(int id)
        {
            var ingredient = await _ingredientRepository.DeleteAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return ingredient;

        }

    }
}
