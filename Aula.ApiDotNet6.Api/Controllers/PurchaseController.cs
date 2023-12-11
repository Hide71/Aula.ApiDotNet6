using Aula.ApiDotnet6.Domain.Validations;
using Aula.ApiDotNet6.Application.DTOs;
using Aula.ApiDotNet6.Application.Services;
using Aula.ApiDotNet6.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula.ApiDotNet6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.CreateAsync(purchaseDTO);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch(DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);

            }
        }
    }
}
