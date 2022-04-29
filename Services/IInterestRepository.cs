using Labb_3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Services
{
    public interface IInterestRepository : IBaseRepository<Interest>
    {
        Task<IEnumerable<Interest>> GetPersonInterests(int id);
    }
}
