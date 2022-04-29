using Labb_3_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Services
{
    public class LinkInterestRepository : IBaseRepository<LinkInterest>, ILinkInterestRepository
    {
        private PersonDbContext _personContext;
        public LinkInterestRepository(PersonDbContext personDbContext)
        {
            _personContext = personDbContext;
        }

        //Class specific methods

        public async Task<LinkInterest> AddNewLink(LinkInterest linkInterest, int personid)
        {
            var person = await _personContext.Persons.FirstOrDefaultAsync(p => p.PersonId == personid);

            foreach (var item in _personContext.PersonInterests) { }
            foreach (var item in _personContext.Links) { }
            foreach (var item in _personContext.Persons) { }

            await _personContext.LinkInterests.AddAsync(linkInterest);

            await _personContext.PersonLinks.AddAsync(new PersonLinks { LinkId = linkInterest.LinkId, PersonId = person.PersonId });

            await _personContext.SaveChangesAsync();

            return linkInterest;
        }

        //Crud

        public Task<LinkInterest> Add(LinkInterest newEnitity)
        {
            throw new NotImplementedException();
        }

        public Task<LinkInterest> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinkInterest>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<LinkInterest> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LinkInterest> Update(LinkInterest entity)
        {
            throw new NotImplementedException();
        }
    }
}
