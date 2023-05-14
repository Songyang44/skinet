using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity.Identity;

namespace Core.Interfaces
{
    public interface ITokenServices
    {
        string CreateToken(AppUser user);
    }
}