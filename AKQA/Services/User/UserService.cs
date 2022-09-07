using AKQA.Authorization;
using AKQA.Entities;
using AKQA.Helpers;
using AKQA.Models.User;
using AutoMapper;


namespace AKQA.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext context;
        private IJwtUtils jwtUtils;
        private readonly IMapper mapper;

        public UserService(DatabaseContext context, IJwtUtils jwtUtils, IMapper mapper)
        {
            this.context = context;
            this.jwtUtils = jwtUtils;
            this.mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = context.User.SingleOrDefault(x => x.UserName == model.UserName);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful
            var response = mapper.Map<AuthenticateResponse>(user);
            response.Token = jwtUtils.GenerateToken(user);
            return response;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return context.User;
        }
        public User GetUserById(int id)
        {
            return getUser(id);
        }
        public void Register(RegisterRequest model)
        {
            if (context.User.Any(x => x.UserName == model.UserName))
            {
                throw new AppException("Username: '" + model.UserName + "' is already taken");
            }

            var user = mapper.Map<User>(model);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            user.Admin = false;
            context.User.Add(user);
            context.SaveChanges();
        }
        public void UpdateUser(int id, UpdateRequest model)
        {
            var user = getUser(id);
            if (model.UserName != user.UserName && context.User.Any(x => x.UserName == model.UserName))
            {
                throw new AppException("Username: '" + model.UserName + "' is already taken");
            }
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            if (!string.IsNullOrEmpty(model.FirstName))
                user.FirstName = model.FirstName;
            if (!string.IsNullOrEmpty(model.LastName))
                user.LastName = model.LastName;

            mapper.Map(model, user);
            context.User.Update(user);
            context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var user = getUser(id);
            context.User.Remove(user);
            context.SaveChanges();
        }
        private User getUser(int id)
        {
            var user = context.User.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
