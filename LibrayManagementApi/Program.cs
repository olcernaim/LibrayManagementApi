
using LibrayManagementApi.Data;
using LibrayManagementApi.DataAccess.Concrete;
using LibrayManagementApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrayManagementApi
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

            builder.Services.AddDbContext<LibManagementContext>(p => p.UseSqlServer(builder.Configuration.GetSection("Settings:ConnectionString")?.Value));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //builder.Services.AddDbContext<LibManagementContext>(options => options.UseSqlServer(builder.Configuration.GetSection("Settings:ConnectionString")?.Value));
            //builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


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
