using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTLogin.Entity.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public int ConfirmCode { get; set; }
    }
}
