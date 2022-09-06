namespace AKQA.Models.User
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public List<int> RecipeId { get; set; }
        public string Token { get; set; }
    }
}
