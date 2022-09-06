using Microsoft.EntityFrameworkCore;
using AKQA.Authorization;
using AKQA.Helpers;
using AKQA.Services.UserServices;
using AKQA.Services.RecipeServices;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var env = builder.Environment;

services.AddDbContext<DatabaseContext>();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddCors();
services.AddControllers();

// configure automapper with all automapper profiles from this assembly
services.AddAutoMapper(typeof(Program));

// configure strongly typed settings object
services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
services.AddScoped<IJwtUtils, JwtUtils>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IRecipeService, RecipeService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.UseCors(x => x
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();