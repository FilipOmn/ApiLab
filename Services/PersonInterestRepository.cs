using Labb_3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_API.Services
{
    public class PersonInterestRepository : IBaseRepository<PersonInterests>, IPersonInterestRepository
    {
        private PersonDbContext _personContext;
        public PersonInterestRepository(PersonDbContext personDbContext)
        {
            _personContext = personDbContext;
        }

        //Class Specific methods

        public async Task<PersonInterests> AddNewPersonInterest(PersonInterests newPersonInterests)
        {
            await _personContext.PersonInterests.AddAsync(newPersonInterests);
            await _personContext.SaveChangesAsync();

            return newPersonInterests;
        }

        //Crud

        public Task<PersonInterests> Add(PersonInterests newEnitity)
        {
            throw new NotImplementedException();
        }

        public Task<PersonInterests> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonInterests>> GetAll()
        {
            return await _personContext.PersonInterests.ToListAsync();
        }

        public Task<PersonInterests> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonInterests> Update(PersonInterests entity)
        {
            throw new NotImplementedException();
        }
    }
}
