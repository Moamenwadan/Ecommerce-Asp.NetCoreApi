using Ecommerce.Core.Entities;
using Ecommerce.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Ecommerce.Repository.Data
{
    public class StoreDbContextSeed
    {
    public async static Task SeedAsync(EcommerceDbContext _context) {
            if(_context.Categories.Count() == 0)
            {
                var ReadAllCategory = File.ReadAllText(@"..\Ecommerce.Repository\Data\DataSeed\Categories.json");

                var CategoryData = JsonSerializer.Deserialize<List<Category>>(ReadAllCategory);
                if (CategoryData is not null && CategoryData.Count > 0)
                {
                    await _context.Categories.AddRangeAsync(CategoryData);
                    await _context.SaveChangesAsync();

                }
            }

            if (_context.ProductsType.Count() == 0)
            {
                var ReadAllProductType = File.ReadAllText(@"..\Ecommerce.Repository\Data\DataSeed\types.json");

                var ProductsTypeData = JsonSerializer.Deserialize<List<ProductType>>(ReadAllProductType);
                if (ProductsTypeData is not null && ProductsTypeData.Count > 0)
                {
                    await _context.ProductsType.AddRangeAsync(ProductsTypeData);
                    await _context.SaveChangesAsync();

                }
            }

            if (_context.Brands.Count() == 0)
            {
                var ReadAllBrands = File.ReadAllText(@"..\Ecommerce.Repository\Data\DataSeed\brands.json");

                var BrandData = JsonSerializer.Deserialize<List<Brand>>(ReadAllBrands);
                if (BrandData is not null && BrandData.Count > 0)
                {
                    await _context.Brands.AddRangeAsync(BrandData);
                    await _context.SaveChangesAsync();

                }
            }

            if (_context.Products.Count() == 0)
            {
                var ReadAllProducts = File.ReadAllText(@"..\Ecommerce.Repository\Data\DataSeed\products.json");

                var ProductsData = JsonSerializer.Deserialize<List<Product>>(ReadAllProducts);
                if (ProductsData is not null && ProductsData.Count > 0)
                {
                    await _context.Products.AddRangeAsync(ProductsData);
                    await _context.SaveChangesAsync();

                }
            }

        }

    }
}
