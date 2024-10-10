using Foody.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Foody.BLL.Services.Clients;
using Foody.BLL.Interfaces.External;
using Foody.BLL.Interfaces.DAL;
using Foody.BLL.Interfaces.Internal;
using Foody.BLL.Services.Internal;
using Foody.DAL.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Foody.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Foody.IdentityAccessLayer;
using Foody.IdentityAccessLayer.Record;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Components.Sections;

namespace Foody.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add FoodyIdentityContext and configure connection string
            builder.Services.AddDbContext<FoodyIdentityContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Foody_Database"))); // Use your preferred database

            // Configure Identity services
            builder.Services.AddIdentityCore<ApplicationUserRecord>()
                .AddRoles<ApplicationUserRoleRecord>()
                .AddEntityFrameworkStores<FoodyIdentityContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddIdentityApiEndpoints<ApplicationUserRecord>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<FoodyIdentityContext>(); ;

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<FoodyDbContext>((sp, options) =>
            {
                var conn = builder.Configuration.GetConnectionString("Foody_Database");
                options.UseNpgsql(conn);
            });

            /*
            builder.Services.AddSingleton<IRecognitionClient>(provider =>
            {
                var apiKey = builder.Configuration.GetSection("Foodvisor")["Token"];

                var baseUrl = builder.Configuration.GetSection("Logmeal")["BaseUrl"];
                return new FoodvisorApiClient(apiKey, baseUrl);
            });
             */

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            
            builder.Services.AddSingleton<IRecognitionClient>(provider =>
            {
                var apiKey = builder.Configuration.GetSection("Logmeal")["Token"];
                var baseUrl = builder.Configuration.GetSection("Logmeal")["BaseUrl"];
                return new LogMealApiClient(apiKey, baseUrl);
            });
            builder.Services.AddSingleton<INutritionixClient>(provider =>
            {
                var apiId = builder.Configuration.GetSection("Nutritionix")["AppId"];
                var apiKey = builder.Configuration.GetSection("Nutritionix")["Token"];
                var baseUrl = builder.Configuration.GetSection("Nutritionix")["BaseUrl"];
                return new NutritionixClient(apiKey, baseUrl, apiId);
            });

            builder.Services.AddScoped<IUsersRepository, UsersRepository>();

            builder.Services.AddScoped<IWaterIntakesRepository, WaterIntakesRepository>();

            builder.Services.AddScoped<IFoodIntakesRepository, FoodIntakesRepository>();

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IWaterIntakeService, WaterIntakeService>();

            builder.Services.AddScoped<IFoodIntakeService, FoodIntakeService>();
            ///
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.MapIdentityApi<ApplicationUserRecord>();

            app.Run();
        }
    }
}