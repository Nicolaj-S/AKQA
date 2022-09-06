using AKQA.Entities;
using AKQA.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AKQA.Services.RecipeServices
{
    public class RecipeService : IRecipeService
    {
        private readonly DatabaseContext context;

        public RecipeService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> CreateRecipe(Recipes recipes)
        {
            await context.AddAsync(recipes);
            return await Save();
        }

        public async Task<bool> DeleteRecipe(Recipes recipes)
        {
            context.Remove(recipes);
            return await Save();
        }

        public async Task<bool> UpdateRecipe(Recipes recipes)
        {
            context.Update(recipes);
            return await Save();
        }

        public async Task<ICollection<Recipes>> GetAllRecipes()
        {
            return await context.Recipes.ToListAsync();
        }

        public async Task<Recipes> GetRecipeById(int id)
        {
            return await context.Recipes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
