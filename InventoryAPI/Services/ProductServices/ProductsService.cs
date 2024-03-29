﻿using InventoryAPI.Context;
using InventoryAPI.DTO.ProductTypeDto;
using InventoryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Services.ProductServices
{
    public class ProductsService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                return await _context.Products.Include(p => p.ProductType).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            try
            {
                IEnumerable<Product> products;
                if (!string.IsNullOrWhiteSpace(name))
                {
                    products = await _context.Products.Where(n => n.Name.Contains(name)).Include(p => p.ProductType).ToListAsync();

                }
                else
                {
                    products = await GetProducts();
                }
                return products;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Product> GetProduct(int id)
        {
            try
            {
                var product = await _context.Products.Include(p => p.ProductType).FirstOrDefaultAsync(i => i.Id == id);
                return product;
            }
            catch
            {

                throw;
            }
        }
        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

    }
}
