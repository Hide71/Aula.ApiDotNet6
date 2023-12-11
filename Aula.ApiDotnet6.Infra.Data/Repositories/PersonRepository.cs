using Aula.ApiDotnet6.Domain.Entities;
using Aula.ApiDotnet6.Domain.Repositories;
using Aula.ApiDotnet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Aula.ApiDotnet6.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;
        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public async Task<int> GetByIdDocument(string document)
        {
            return (await _db.People.FirstOrDefaultAsync(x => x.Document == document)) ?.Id ?? 0;
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _db.People.ToListAsync();
        }
    }
}
