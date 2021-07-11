using API.Data;
using API.DTOs;
using API.Interface;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _ent;
        private readonly IMapper _mapper;
        public UserRepository(DataContext ent, IMapper mapper)
        {
            _ent = ent;
            _mapper = mapper;
        }

        public async Task<MemberDto> GetMemberAsync(string _username)
        {
            return await _ent.AppUser
                        .Where(o => o.UserName.ToLower() == _username.ToLower())
                        .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                        .SingleOrDefaultAsync();            
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _ent.AppUser
                        .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int _id)
        {
            return await _ent.AppUser.FindAsync(_id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string _username)
        {
            return await _ent.AppUser
                        .Include(o => o.Photos)
                        .SingleOrDefaultAsync(o => o.UserName == _username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _ent.AppUser
                        .Include(o => o.Photos)
                        .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _ent.SaveChangesAsync() > 0;
        }

        public void Update(AppUser _user)
        {
            _ent.Entry(_user).State = EntityState.Modified;
        }
    }
}
