using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Entities
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Enabled = true;
        }
        public bool Enabled { get; set; }
    }
}
