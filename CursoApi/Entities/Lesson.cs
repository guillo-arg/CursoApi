using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public Module Module { get; set; }
    }
}
