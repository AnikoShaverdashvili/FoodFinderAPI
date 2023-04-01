using FoodFinderAPI.Models;
using FoodFinderAPI.Reposotories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAllergyController : ControllerBase
    {
        private readonly IGenericRepository<UserAllergy> _userAlelrgyRepo;

        public UserAllergyController(IGenericRepository<UserAllergy> userAlelrgyRepo)
        {
            _userAlelrgyRepo = userAlelrgyRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<UserAllergy>> GetUserAllergies()
        {
            return await _userAlelrgyRepo.GetAllAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<UserAllergy>>GetUserAllergyId(int id)
        {
            var userAllergy = await _userAlelrgyRepo.GetByIdAsync(id);
            if (id == null)
            {
                return NotFound();
            }
            return userAllergy;
        }


        [HttpPost]
        public async Task<ActionResult<UserAllergy>>CreateUserAllergy(UserAllergy userallergy)
        {
            var createUserAllergy=await _userAlelrgyRepo.CreateAsync(userallergy);  
            return CreatedAtAction(nameof(GetUserAllergies), new {userallergy.Id}, createUserAllergy);  
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<UserAllergy>>UpdateUserAllergy(int id, UserAllergy userallergy)
        {
            if(id != userallergy.Id)
            {
                return NotFound();
            }
            return await _userAlelrgyRepo.UpdateAsync(userallergy); 
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<UserAllergy>>DeteleUserAllergy(int id)
        {
            var userAllergy = await _userAlelrgyRepo.DeleteAsync(id);
            if (userAllergy.Id == null)
            {
                return NotFound();
            }
            return userAllergy;
        }
    }
}
