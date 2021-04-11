using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public Course Course{ get; set; }

    }
}
