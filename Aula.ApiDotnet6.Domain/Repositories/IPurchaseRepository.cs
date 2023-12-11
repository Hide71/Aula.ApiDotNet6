using Aula.ApiDotnet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ApiDotnet6.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        Task<Purchase> GetByIdAsync(int id);
        Task<Purchase> CreateAsync(Purchase purchase);
        Task DeleteAsync(Purchase purchase);
        Task EditAsync(Purchase purchase);
        Task<ICollection<Purchase>> GetByPersonIdAsync(int personId);
        Task<ICollection<Purchase>> GetByProductIdAsync(int productId);
        Task<ICollection<Purchase>> GetAllAsync();
    }
}
