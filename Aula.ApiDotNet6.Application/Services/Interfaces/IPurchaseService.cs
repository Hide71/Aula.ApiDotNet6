using Aula.ApiDotNet6.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ApiDotNet6.Application.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);
        Task<ResultService<PurchaseDetailDTO>> GetByIdAsync(int id);
        Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAsync();
    }
}
