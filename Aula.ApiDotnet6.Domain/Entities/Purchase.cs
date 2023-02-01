using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula.ApiDotnet6.Domain.Validations;

namespace Aula.ApiDotnet6.Domain.Entities
{
    public sealed class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; private set; }
        public Product Product { get; private set; }

       public Purchase(int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date);
        }

        public Purchase(int id, int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(id < 0, "Id da compra deve ser informado");
            Id = id;
            Validation(productId, personId, date);
        }
        public void Validation(int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(productId < 0, "Id do produto deve ser informado");
            DomainValidationException.When(personId < 0, "Id da pessoa deve ser informado");
            DomainValidationException.When(!date.HasValue, "Data deve ser informada");
            PersonId = personId;
            ProductId = productId;
            Date = date.Value;
        }
    }
}
