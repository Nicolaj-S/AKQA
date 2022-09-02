using AKQA.Domain;

namespace AKQA.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
        Task<ICollection<User>> GetAllUsers();
        Task<User> GetUserById(int id);
    }
}
