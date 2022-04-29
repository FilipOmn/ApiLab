using Labb_3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Services
{
    public interface ILinkInterestRepository : IBaseRepository<LinkInterest>
    {
        Task<LinkInterest> AddNewLink(LinkInterest linkInterest, int personId);
    }
}
