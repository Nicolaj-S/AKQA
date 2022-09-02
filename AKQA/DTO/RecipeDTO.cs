using AKQA.Domain;
using System.Linq.Expressions;

namespace AKQA.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string RecipeImage { get; set; }
        public string Description { get; set; }
        public List<int> UserId { get; set; }

        public static Expression<Func<Recipes, RecipeDTO>> RecipeDetails => Recipes => new()
        {
            RecipeName = Recipes.RecipeName,
            RecipeImage = Recipes.RecipeImage,
            Description = Recipes.Description,
            UserId = Recipes.Users.Select(x => x.Id).ToList(),
        };
    }
}
