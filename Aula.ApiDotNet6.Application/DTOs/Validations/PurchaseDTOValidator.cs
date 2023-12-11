using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ApiDotNet6.Application.DTOs.Validations
{
    public  class PurchaseDTOValidator: AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator()
        {
            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("Coderp deve ser informado!");

            RuleFor(x => x.Document)
                .NotNull()
                .NotEmpty()
                .WithMessage("Documento deve ser informado!");
        }
    }
}
