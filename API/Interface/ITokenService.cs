﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser _user);
    }
}
