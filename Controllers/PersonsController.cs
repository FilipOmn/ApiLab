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
    public class PersonsController : ControllerBase
    {
        private IBaseRepository<Person> _personRepository;

        public PersonsController(IBaseRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            return Ok(await _personRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSinglePerson(int id)
        {
            var result = await _personRepository.GetSingle(id);

            if (result == null)
            {
                return NotFound($"The person with id: {id} could not be found");
            }

            return Ok(result);
        }
    }
}
