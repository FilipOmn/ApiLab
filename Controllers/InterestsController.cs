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
    public class InterestsController : ControllerBase
    {
        private IInterestRepository _interestRepo;
        public InterestsController(IInterestRepository interestrepo)
        {
            _interestRepo = interestrepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            return Ok(await _interestRepo.GetAll());
        }

        [HttpGet("personinterests/{id}")]
        public async Task<IActionResult> GetPersonInterests(int id)
        {
            try
            {
                var results = _interestRepo.GetPersonInterests(id);

                return Ok(await results);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, could not find any interests for person with id {id}");
            }      
        }
    }
}
