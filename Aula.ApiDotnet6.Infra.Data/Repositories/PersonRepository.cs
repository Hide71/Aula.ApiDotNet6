using Aula.ApiDotnet6.Domain.Entities;
using Aula.ApiDotnet6.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ApiDotnet6.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public Task<Person> CreateAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Person>> GetPeopleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
