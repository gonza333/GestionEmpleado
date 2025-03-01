using System;
using System.ComponentModel.DataAnnotations;

namespace GestionEmpleados.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string Departamento { get; set; }
    }
}
