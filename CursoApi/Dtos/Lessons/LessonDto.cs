using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Dtos.Lessons
{
    public class LessonDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la clase es requerida")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La posición de la clase es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor mínimo para la posición debe ser 1")]
        public int Position { get; set; }

        [Required(ErrorMessage = "El módulo es requerido")]
        public int ModuleId { get; set; }

        [Required(ErrorMessage = "El curso es requerido")]
        public int CourseId { get; set; }
    }
}
