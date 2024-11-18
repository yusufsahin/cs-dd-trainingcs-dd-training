using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Helpers;
using OnlineStore.BAL.Abstract;
using OnlineStore.BAL.Concrete;
using OnlineStore.DAL.Abstract;
using OnlineStore.DAL.Concrete;
using OnlineStore.DAL.Concrete.EntityFrameWork;

namespace OnlineStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add AutoMapper configuration
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Configure DbContext with SQL Server
            builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.MigrationsAssembly("OnlineStore.API"));
            });

            // Register dependencies
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<ICategoryDal, CategoryDal>();

            // Configure CORS to allow any origin
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAny", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Add controllers
            builder.Services.AddControllers();

            // Add Swagger/OpenAPI support
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Enable CORS globally
            app.UseCors("AllowAny");

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
