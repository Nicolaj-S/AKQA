using AKQA.Services.UserServices;

namespace AKQA.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;

        public JwtMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetUserById(userId.Value);
            }

            await next(context);
        }
    }
}
