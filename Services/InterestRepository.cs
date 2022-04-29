using Labb_3_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Services
{
    public class InterestRepository : IBaseRepository<Interest>, IInterestRepository
    {
        private PersonDbContext _personContext;

        public InterestRepository(PersonDbContext personDbContext)
        {
            _personContext = personDbContext;
        }

        //Class specific methods

        public async Task<IEnumerable<Interest>> GetPersonInterests(int id)
        {
            List<Interest> InterestList = new List<Interest>();
            var person = await _personContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);

            foreach (var item in _personContext.PersonInterests) { }
            foreach (var item in _personContext.Interests) { }

            if (person != null)
            {
                if (person.PersonInterests.Any())
                {
                    foreach (var item in person.PersonInterests)
                    {
                        InterestList.Add(item.Interest);
                    }
                    return InterestList;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //Crud

        public Task<Interest> Add(Interest newEnitity)
        {
            throw new NotImplementedException();
        }

        public Task<Interest> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _personContext.Interests.ToListAsync();
        }

        public Task<Interest> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Interest> Update(Interest entity)
        {
            throw new NotImplementedException();
        }
    }
}
