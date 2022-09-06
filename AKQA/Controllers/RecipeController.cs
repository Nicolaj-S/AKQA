using AKQA.Entities;
using AKQA.Services.RecipeServices;
using Microsoft.AspNetCore.Mvc;

namespace AKQA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private readonly IRecipeService service;

        public RecipeController(IRecipeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await service.GetAllRecipes();
            if (!ModelState.IsValid)
                return NotFound(ModelState);

            return Ok(recipes);
        }

        [HttpGet("Id/{Id}")]
        public async Task<IActionResult> GetRecipeById(int Id)
        {
            var Recipe = await service.GetRecipeById(Id);
            if (!ModelState.IsValid)
                return NotFound(ModelState);

            return Ok(Recipe);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateRecipe(Recipes recipe)
        {
            var result = await service.CreateRecipe(recipe);
            return result ? Ok(CreateRecipe) : BadRequest();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteRecipe(int Id)
        {
            var RecipeToDelete = await service.GetRecipeById(Id);
            var result = await service.DeleteRecipe(RecipeToDelete);
            return result ? Ok(DeleteRecipe) : BadRequest();

        }

        [HttpPatch("Update/{Id}")]
        public async Task<IActionResult> UpdateRecipe(int Id, [FromBody] Recipes recipes)
        {
            if(recipes == null)
                return NotFound(ModelState);
            if(!ModelState.IsValid)
                return NotFound(ModelState);
            if (Id != recipes.Id)
                return NotFound(ModelState);

            var result = await service.UpdateRecipe(recipes);
            return result ? Ok(UpdateRecipe) : BadRequest();
        }
    }
}
