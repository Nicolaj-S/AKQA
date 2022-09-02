using AKQA.Domain;

namespace AKQA.Services.RecipeServices
{
    public interface IRecipeService
    {
        Task<bool> CreateRecipe(Recipes recipes);
        Task<bool> UpdateRecipe(Recipes recipes);
        Task<bool> DeleteRecipe(Recipes recipes);
        Task<ICollection<Recipes>> GetAllRecipes();
        Task<Recipes> GetRecipeById(int id);
    }
}
