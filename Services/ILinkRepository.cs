using Labb_3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Services
{
    public interface ILinkRepository : IBaseRepository<Link>
    {
        Task<IEnumerable<Link>> GetPersonLinks(int id);
        Task<Link> AddNewLinkToPerson(Link newLink, int personId, int interestId);
    }
}
