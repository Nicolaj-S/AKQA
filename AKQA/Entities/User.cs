using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AKQA.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public bool Admin { get; set; }

        public List<Recipes>? Recipes { get; set; }
    }
}
