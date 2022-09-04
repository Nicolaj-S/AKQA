using AKQA.Domain;
using AKQA.Repo.UserRepo;

namespace AKQA.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepo repo;

        public UserService(IUserRepo repo)
        {
            this.repo = repo;
        }

        public async Task<bool> CreateUser(User user) => await repo.CreateUser(user);
        public async Task<bool> UpdateUser(User user) => await repo.UpdateUser(user);
        public async Task<bool> DeleteUser(User user) => await repo.DeleteUser(user);
        public async Task<ICollection<User>> GetAllUsers() => await repo.GetAllUsers();
        public async Task<User> GetUserById(int id) => await repo.GetUserById(id);
    }
}
