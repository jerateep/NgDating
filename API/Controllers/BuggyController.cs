using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BuggyController : BasicApiController
    {
        private readonly DataContext _ent;
        public BuggyController(DataContext ent)
        {
            _ent = ent;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _ent.AppUser.Find(-1);
            if (thing == null)
            {
                return NotFound();
            }
            return Ok(thing);
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            //try
            //{
                var thing = _ent.AppUser.Find(-1);
                var thingToReturn = thing.ToString();
                return thingToReturn;
            //}
            //catch
            //{
            //    return StatusCode(500, "Computer says no!");
            //}
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return "This was not a good request";
        }
    }
}
