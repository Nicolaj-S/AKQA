using AKQA.Domain;
using AKQA.Enviroment;
using Microsoft.EntityFrameworkCore;

namespace AKQA.Repo.UserRepo
{
    public class UserRepo : IUserRepo
    {

        private readonly DatabaseContext context;

        public UserRepo(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> CreateUser(User user)
        {
            await context.AddAsync(user);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return await Save();
        }

        public async Task<bool> DeleteUser(User user)
        {
            context.Remove(user);
            return await Save();
        }

        public async Task<bool> UpdateUser(User user)
        {
            context.Update(user);
            return await Save();
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await context.User.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await context.User.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public User Login(User authUser)
        {
            var user = context.User.SingleOrDefault(x => x.UserName == authUser.UserName);
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(authUser.Password, user.Password);

            if (isValidPassword)
            {
                return user;
            }

            return null;
        }
    }
}
