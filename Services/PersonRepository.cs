using Labb_3_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Services
{
    public class PersonRepository : IBaseRepository<Person>
    {
        private PersonDbContext _personContext;

        public PersonRepository(PersonDbContext personDbContext)
        {
            _personContext = personDbContext;
        }

        public async Task<Person> GetSingle(int id)
        {
            //Loads table records
            foreach (var item in _personContext.PersonInterests) { }
            foreach (var item in _personContext.PersonLinks) { }
            foreach (var item in _personContext.Interests) { }
            foreach (var item in _personContext.Links) { }

            return await _personContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _personContext.Persons.ToListAsync();
        }

        public Task<Person> Add(Person newEnitity)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
