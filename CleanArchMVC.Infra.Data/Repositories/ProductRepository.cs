using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMVC.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        //public async Task<Product> GetProductCategoryAsync(int? id)
        //{
        //    Product? entity = await _context.Products
        //        .Include(p => p.Category)
        //        .SingleOrDefaultAsync(p => p.Id == id);

        //    if (entity != null)
        //        return entity;

        //    throw new ApplicationException("Não foi encontrado o produto desejado, tente novamente!");
        //}

        public async Task<Product> GetProductByIdAsync(int? id)
        {
            Product? entity = await _context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (entity != null)
                return entity;

            throw new ApplicationException("Não foi encontrado o produto desejado, tente novamente!");
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}