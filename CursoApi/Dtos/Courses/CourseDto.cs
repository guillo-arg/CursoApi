using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Dtos.Courses
{
    public class CourseDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del curso es requerido")]
        [StringLength(255, ErrorMessage = "Debe tener como mínimo 6 caracteres y como máximo 255 caracteres")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "El precio del curso es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0")]
        public double Price { get; set; }
    }
}
