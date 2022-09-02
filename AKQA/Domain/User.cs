using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AKQA.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public string FullName { get { return FirstName + " " + LastName; } }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public bool Admin { get; set; }

        public List<Recipes>? Recipes { get; set; }
    }
}
