using FoodFinderAPI.Models;
using FoodFinderAPI.Reposotories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly GenericRepository<Allergy> _allergyRepository;

        public AllergyController(GenericRepository<Allergy> allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }

        [HttpGet]

        public Task<IEnumerable<Allergy>> GetAllergy()
        {
            return _allergyRepository.GetAllAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Allergy>> GetAllergyById(int id)
        {
            var allergy = await _allergyRepository.GetByIdAsync(id);
            if (allergy == null)
            {
                return NotFound();
            }
            return allergy;
        }

        [HttpPost]

        public async Task<ActionResult<Allergy>> CreateAllergy(Allergy allergy)
        {
            var createdAllergy = _allergyRepository.CreateAsync(allergy);
            return CreatedAtAction(nameof(GetAllergyById), new { id = createdAllergy.Id }, createdAllergy);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Allergy>> UpdateAllergy(int id, Allergy allergy)
        {
            if (id != allergy.Id)
            {
                return BadRequest();
            }
            await _allergyRepository.UpdateAsync(allergy);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Allergy>> DeleteMeal(int id)
        {
            var allergy = await _allergyRepository.DeleteAsync(id);
            if (allergy == null)
            {
                return NotFound();
            }
            return allergy;
        }


    }
}
