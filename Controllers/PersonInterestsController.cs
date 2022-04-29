using Labb_3_API.Models;
using Labb_3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInterestsController : ControllerBase
    {
        private IPersonInterestRepository _PersonInterestRepo;
        public PersonInterestsController(IPersonInterestRepository personInterestRepo)
        {
            _PersonInterestRepo = personInterestRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonInterests()
        {
            return Ok(await _PersonInterestRepo.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewPersonInterest(PersonInterests newPersonInterest)
        {
            await _PersonInterestRepo.AddNewPersonInterest(newPersonInterest);

            return Created(HttpContext.Request.Scheme + "://"
                + HttpContext.Request.Host + HttpContext.Request.Path
                + "/" + newPersonInterest.PersonInterestId, newPersonInterest);
        }
    }
}
