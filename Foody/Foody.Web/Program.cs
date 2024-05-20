using Foody.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Foody.BLL.Services.Clients;
using Foody.BLL.Interfaces.External;

namespace Foody.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<FoodyDbContext>((sp, options) =>
            {
                var conn = builder.Configuration.GetConnectionString("Foody_Database");
                options.UseNpgsql(conn);
            });

            //builder.Services.AddSingleton<IRecognitionClient>(provider =>
            //{
            //    var apiKey = builder.Configuration.GetSection("Foodvisor")["Token"];

            //    var baseUrl = builder.Configuration.GetSection("Logmeal")["BaseUrl"];
            //    return new FoodvisorApiClient(apiKey, baseUrl);
            //});

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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}