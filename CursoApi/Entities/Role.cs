using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Entities
{
    public class Role :IdentityRole<string>
    {
        public bool Enabled { get; set; }
    }
}
