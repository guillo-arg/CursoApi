using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Dtos.Modules
{
    public class ModuleDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La posición es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor mínimo de la posición debe ser 1")]
        public int Position { get; set; }
        [Required(ErrorMessage = "El nombre del módulo es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El curso al cual pertenece el módulo es requerido")]
        public int CourseId { get; set; }
    }
}
