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
    public class LinkInterestController : ControllerBase
    {
        private ILinkInterestRepository _linkInterestRepo;
        public LinkInterestController(ILinkInterestRepository linkInterestRepo)
        {
            _linkInterestRepo = linkInterestRepo;
        }

        [HttpPost("createnew/personid/{personid}")]
        public async Task<ActionResult> CreateLinkInterest(LinkInterest linkInterest, int personid)
        {
            try
            {
                await _linkInterestRepo.AddNewLink(linkInterest, personid);

                return Created(HttpContext.Request.Scheme + "://"
                    + HttpContext.Request.Host + HttpContext.Request.Path
                    + "/" + linkInterest.LinkInterestId, linkInterest);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Person of id {personid} could not be found");
            }
        }
    }
}
