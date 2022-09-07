using System.ComponentModel.DataAnnotations;

namespace AKQA.Entities
{
    public class Recipes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RecipeName { get; set; }
        [Required]
        public string RecipeImage { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
