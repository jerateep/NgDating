using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BasicApiController
    {
        private readonly DataContext _ent;
        public UsersController(DataContext ent)
        {
            _ent = ent;
        }
        //[Authorize]
        [HttpGet]
        public async Task<IEnumerable<AppUser>> GetUsers() => await _ent.AppUser.ToListAsync();
        [HttpGet("{_id}")]
        public async Task<AppUser> GetUsers(int _id) => await _ent.AppUser.FindAsync(_id);
    }
}
