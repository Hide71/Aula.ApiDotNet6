using Aula.ApiDotnet6.Domain.Entities;

namespace Aula.ApiDotnet6.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<ICollection<Product>> GetProductAsync();
        Task<Product> CreateProduct(Product product);
        Task EditAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
