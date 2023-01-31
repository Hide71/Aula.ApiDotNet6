using Aula.ApiDotnet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ApiDotnet6.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }

        public Person(string name, string document, string phone )
        {
            Validation(name, document, phone);
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.When(id < 0, "ID inválido");
            Id = id;
            Validation(name, document, phone);
        }
        private void Validation(string name, string document, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Documento deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Telefone deve ser informado");
            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
