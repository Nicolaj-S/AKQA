using AKQA.Domain;

namespace AKQA.Repo.UserRepo
{
    public interface IUserRepo
    {
        Task<bool> Save();
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
        Task<ICollection<User>> GetAllUsers();
        Task<User> GetUserById(int id);
    }
}
