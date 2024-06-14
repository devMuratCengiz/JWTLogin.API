using JWTLogin.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTLogin.DataAccess.Context
{
    public class SqlDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public SqlDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
