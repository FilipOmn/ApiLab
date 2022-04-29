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
    public class LinksController : ControllerBase
    {
        private ILinkRepository _linkRepo;
        public LinksController(ILinkRepository linkRepo)
        {
            _linkRepo = linkRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLinks()
        {
            return Ok(await _linkRepo.GetAll());
        }

        [HttpGet("personlinks/{id}")]
        public async Task<IActionResult> GetPersonInterests(int id)
        {
            try
            {
                var results = _linkRepo.GetPersonLinks(id);

                return Ok(await results);
            }
            catch
            {
                return NotFound($"Error, could not find any links for person with id {id}");
            }
        }

        [HttpPost("createnew/linktoperson/{personid}/{interestid}")]
        public async Task<ActionResult> CreateLinkInterest(Link newLink, int personid, int interestid)
        {
            try
            {
                await _linkRepo.AddNewLinkToPerson(newLink, personid, interestid);

                return Created(HttpContext.Request.Scheme + "://"
                    + HttpContext.Request.Host + HttpContext.Request.Path
                    + "/" + newLink.LinkId, newLink);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Person of id {personid} or Interest of {interestid} could not be found");
            }
        }
    }
}
