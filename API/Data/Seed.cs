using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Data
{
    public class Seed
    {
        public static  async Task SeedUser(DataContext context)
        {
            if (await context.AppUser.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach (var u in users)
            {
                using var hmac = new HMACSHA512();
                u.UserName = u.UserName.ToLower();
                u.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234"));
                u.PasswordSalt = hmac.Key;
                context.AppUser.Add(u);
            }
            await context.SaveChangesAsync();
        }
    }
}
