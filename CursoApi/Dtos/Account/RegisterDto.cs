using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Dtos.Account
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [StringLength(255,ErrorMessage = "El usuario debe tener como mínimo 6 caracteres", MinimumLength = 6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(255, ErrorMessage = "La contraseña debe tener como mínimo 6 caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmación de la contraseña es requerida")]
        [StringLength(255, ErrorMessage = "La confirmación de la contraseña debe tener como mínimo 6 caracteres", MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "Debe escribir un correo electrónico válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La confirmación del correo electrónico es requerida")]
        [EmailAddress(ErrorMessage = "Debe escribir un correo electrónico válido")]
        [Compare("Email", ErrorMessage = "Los correos electrónicos no coinciden ")]
        public string ConfirmEmail { get; set; }

    }
}
