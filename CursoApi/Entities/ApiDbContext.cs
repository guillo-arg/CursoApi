using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Entities
{
    public class ApiDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
    }
}
