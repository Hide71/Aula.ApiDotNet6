using Aula.ApiDotnet6.Domain.Entities;
using Aula.ApiDotnet6.Domain.Repositories;
using Aula.ApiDotNet6.Application.DTOs;
using Aula.ApiDotNet6.Application.DTOs.Validations;
using Aula.ApiDotNet6.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ApiDotNet6.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository)
        {
            _productRepository = productRepository;
            _personRepository = personRepository;
            _purchaseRepository = purchaseRepository;
        }

        public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado!");

            var validate = new PurchaseDTOValidator().Validate(purchaseDTO);

            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problemas de validação!", validate);
            var productId = await _productRepository.GetByCodErpAsync(purchaseDTO.CodErp);
            var personId = await _personRepository.GetByIdDocument(purchaseDTO.Document);
            var purchase = new Purchase(productId, personId);
            var data = await _purchaseRepository.CreateAsync(purchase);
            purchaseDTO.Id = data.Id;
            return ResultService.Ok<PurchaseDTO>(purchaseDTO);
        }
    }
}
