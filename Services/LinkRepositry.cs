using Labb_3_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Services
{
    public class LinkRepositry : IBaseRepository<Link>, ILinkRepository
    {
        private PersonDbContext _personContext;
        public LinkRepositry(PersonDbContext personDbContext)
        {
            _personContext = personDbContext;
        }

        //Class specifc methods

        public async Task<IEnumerable<Link>> GetPersonLinks(int id)
        {
            List<Link> LinkList = new List<Link>();
            var person = await _personContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);

            foreach (var item in _personContext.Links) { }
            foreach (var item in _personContext.PersonLinks) { }

            if (person != null)
            {
                if (person.PersonLinks.Any())
                {
                    foreach (var item in person.PersonLinks)
                    {
                        LinkList.Add(item.Link);
                    }

                    return LinkList;
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

        public async Task<Link> AddNewLinkToPerson(Link newLink, int personId, int interestId)
        {
            var person = await _personContext.Persons.FirstOrDefaultAsync(p => p.PersonId == personId);
            var interest = await _personContext.Interests.FirstOrDefaultAsync(i => i.InterestId == interestId);

            //Loads tables
            foreach (var item in _personContext.PersonInterests) { }
            foreach (var item in _personContext.LinkInterests) { }
            foreach (var item in _personContext.Interests) { }
            foreach (var item in _personContext.Links) { }
            foreach (var item in _personContext.Persons) { }

            await _personContext.Links.AddAsync(newLink);

            await _personContext.SaveChangesAsync();

            await _personContext.PersonLinks.AddAsync(new PersonLinks { LinkId = newLink.LinkId, PersonId = person.PersonId });

            await _personContext.LinkInterests.AddAsync(new LinkInterest { LinkId = newLink.LinkId, InterestId = interest.InterestId });

            await _personContext.SaveChangesAsync();

            return newLink;
        }

        //Crud

        public Task<Link> Add(Link newEnitity)
        {
            throw new NotImplementedException();
        }

        public Task<Link> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _personContext.Links.ToListAsync();
        }

        public Task<Link> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Link> Update(Link entity)
        {
            throw new NotImplementedException();
        }
    }
}
