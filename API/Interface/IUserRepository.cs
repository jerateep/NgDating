using API.DTOs;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interface
{
    public interface IUserRepository
    {
        void Update(AppUser _user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int _id);
        Task<AppUser> GetUserByUsernameAsync(string _username);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync(string _username);
    }
}
