using AKQA.Domain;
using AKQA.Repo.RecipeRepo;

namespace AKQA.Services.RecipeServices
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepo repo;

        public RecipeService(IRecipeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<bool> CreateRecipe(Recipes recipe) => await repo.CreateRecipe(recipe);
        public async Task<bool> UpdateRecipe(Recipes recipe) => await repo.UpdateRecipe(recipe);
        public async Task<bool> DeleteRecipe(Recipes recipe) => await repo.DeleteRecipe(recipe);
        public async Task<ICollection<Recipes>> GetAllRecipes() => await repo.GetAllRecipes();
        public async Task<Recipes> GetRecipeById(int id) => await repo.GetRecipeById(id);
    }
}
