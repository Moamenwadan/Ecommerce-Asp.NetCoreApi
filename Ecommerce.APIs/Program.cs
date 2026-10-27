
using Ecommerce.APIs.Response;
using Ecommerce.Core;
using Ecommerce.Core.Mapping;
using Ecommerce.Core.Services.Contruct;
using Ecommerce.Repository;
using Ecommerce.Repository.Data;
using Ecommerce.Repository.Data.Contexts;
using Ecommerce.Service.Services.Brands;
using Ecommerce.Service.Services.Categories;
using Ecommerce.Service.Services.Products;
using Ecommerce.Service.Services.ProductTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;

namespace Ecommerce.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.FullName);
            });
            //   builder.Services.AddSwaggerGen();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EcommerceDbContext>
             (option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile(builder.Configuration)));

        //    private IActionResult HandleValidationError(ActionContext context)
        //{
        //    return new BadRequestObjectResult(
        //        new ApiValidationRequest(400, "badRequest")
        //    );
        //}
        builder.Services.Configure<ApiBehaviorOptions>(settings =>
            {
                //    options.InvalidModelStateResponseFactory = HandleValidationError;
                settings.InvalidModelStateResponseFactory = (context) =>
                {
                    var Errors = context.ModelState.Where(Resp => Resp.Value.Errors.Count() > 0)
                          .SelectMany(Rs => Rs.Value.Errors).Select(Error => Error.ErrorMessage).ToArray();
                    var Response = new ApiValidationRequest() { Errors = Errors };

                    return new BadRequestObjectResult(Response);

                };

            });

            var app = builder.Build();
            var scope = app.Services.CreateScope();
            var Context = scope.ServiceProvider.GetRequiredService<EcommerceDbContext>();
            var LoggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
            try
            {
            await Context.Database.MigrateAsync();
            await StoreDbContextSeed.SeedAsync(Context);
            }
            catch (Exception ex) {
                LoggerFactory.CreateLogger<Program>().LogError(ex, "There are Problem During Apply Migration");
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseStaticFiles();
            app.Run();
        }
    }
}
