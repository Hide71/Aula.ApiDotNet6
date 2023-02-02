using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula.ApiDotnet6.Domain.Validations;

namespace Aula.ApiDotnet6.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchase { get; set; }

        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp, price);

        }

        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(Id < 0, "ID deve ser informado");
            Id = id;
            Validation(name, codErp, price);
        }

        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome do produto deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Código deve ser informado");
            DomainValidationException.When(price < 0, "Valor deve ser informado");
            Name = name;
            CodErp = codErp;
            Price = price;
   
        }
    }
}
