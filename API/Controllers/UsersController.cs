using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _ent;
        public UsersController(DataContext ent)
        {
            _ent = ent;
        }
        [HttpGet]
        public IEnumerable<AppUser> GetUsers() => _ent.AppUser.ToList();
        [HttpGet("{_id}")]
        public AppUser GetUsers(int _id) => _ent.AppUser.Find(_id);
    }
}
