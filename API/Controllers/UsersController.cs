using API.Data;
using API.DTOs;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BasicApiController
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepo,IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<MemberDto>> GetUsers()
        {
            var users = await _userRepo.GetMembersAsync();
            return _mapper.Map<IEnumerable<MemberDto>>(users);
        }
        [HttpGet("{_username}")]
        public async Task<MemberDto> GetUsers(string _username) 
        {
            return await _userRepo.GetMemberAsync(_username);
        } 
        //[HttpGet("{_id}")]
        //public async Task<MemberDto> GetUsers(int _id) 
        //{ 
        //    var users = await _userRepo.GetUserByIdAsync(_id);
        //    return _mapper.Map<MemberDto>(users);
        //}

    }
}
