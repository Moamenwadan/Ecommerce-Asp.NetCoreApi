
using Ecommerce.Repository.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EcommerceDbContext>
             (option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            var app = builder.Build();
            var scope = app.Services.CreateScope();
            var Context = scope.ServiceProvider.GetRequiredService<EcommerceDbContext>();
            var LoggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
            try
            {
            await Context.Database.MigrateAsync();
            }
            catch (Exception ex) {
                LoggerFactory.CreateLogger<Program>().LogError(ex, "There are Problem During Apply Migration");
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
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
