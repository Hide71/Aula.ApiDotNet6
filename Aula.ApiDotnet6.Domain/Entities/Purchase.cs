using Aula.ApiDotnet6.Domain.Validations;

namespace Aula.ApiDotnet6.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public Purchase(int productId, int personId)
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        {
            Validation(productId, personId);
        }

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public Purchase(int id, int productId, int personId)
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        {
            DomainValidationException.When(id <= 0, "Id da compra deve ser informado");
            Id = id;
            Validation(productId, personId);
        }
        public void Edit(int id, int productId, int personId)
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        {
            DomainValidationException.When(id <= 0, "Id da compra deve ser informado");
            Id = id;
            Validation(productId, personId);
        }
        private void Validation(int productId, int personId)
        {
            DomainValidationException.When(productId <= 0, "Id do produto deve ser informado");
            DomainValidationException.When(personId <= 0, "Id da pessoa deve ser informado");
            PersonId = personId;
            ProductId = productId;
            Date = DateTime.Now;
        }
    }
}
