using AKQA.Domain;

namespace AKQA.Repo.RecipeRepo
{
    public interface IRecipeRepo
    {
        Task<bool> Save();
        Task<bool> CreateRecipe(Recipes recipes);
        Task<bool> UpdateRecipe(Recipes recipes);
        Task<bool> DeleteRecipe(Recipes recipes);
        Task<ICollection<Recipes>> GetAllRecipes();
        Task<Recipes> GetRecipeById(int id);
    }
}
