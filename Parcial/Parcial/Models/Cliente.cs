using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar Cedula")]
        [Display(Name ="Cédula")]
        [StringLength(13)]
        public string Cedula { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar Cedula")]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar Nombre")]
        [Display(Name = "Apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar Dirección")]
        [Display(Name = "Dirección")]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar Email")]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar Celular")]
        [Display(Name = "Celular")]
        [StringLength(50)]
        public string Celular { get; set; }

    }
}
