using Aula.ApiDotnet6.Domain.Entities;
using Aula.ApiDotnet6.Domain.Repositories;
using Aula.ApiDotnet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Aula.ApiDotnet6.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            _db.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task<int> GetByCodErpAsync(string codErp)
        {
            return (await _db.Products.FirstOrDefaultAsync(x => x.CodErp == codErp))?.Id ?? 0;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public async Task<ICollection<Product>> GetProductAsync()
        {
            return await _db.Products.ToListAsync();
        }
    }
}
