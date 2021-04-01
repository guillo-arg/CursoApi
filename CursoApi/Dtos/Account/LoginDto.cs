using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Dtos.Account
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [StringLength(255, ErrorMessage = "El usuario debe tener como mínimo 6 caracteres", MinimumLength = 6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(255, ErrorMessage = "La contraseña debe tener como mínimo 6 caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
