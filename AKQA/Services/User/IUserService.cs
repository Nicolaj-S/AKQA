using AKQA.Entities;
using AKQA.Models.User;

namespace AKQA.Services.UserServices
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        void Register(RegisterRequest model);

        void UpdateUser(int id, UpdateRequest model);
        void DeleteUser(int id);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}
