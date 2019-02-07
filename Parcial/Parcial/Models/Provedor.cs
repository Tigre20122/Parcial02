using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.Models
{
    public class Provedor
    {
        [Key]
        public int IdProvedor { get; set; }
        [Required(ErrorMessage ="Porfavor ingrese el Ruc")]
        [Display(Name ="Ruc")]
        [StringLength(13,ErrorMessage ="El ruc es unico y solo posee 13 caracteres")]
        public string Ruc { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar el Nombre De La Empresa")]
        [Display(Name = "Nombre De La Empresa")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar la Direcciòn")]
        [Display(Name = "Dirección")]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar el Telefono")]
        [Display(Name = "Telefono")]
        [StringLength(13)]
        public string Telefono { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar la Extención")]
        [Display(Name = "Extanciòn")]
        [StringLength(50)]
        public string Extencion{ get; set; }
        [Required(ErrorMessage ="Porfavor ingresar el Celular del Contacto")]
        [Display(Name = "Celular de contacto")]
        [StringLength(13)]
        public string CelularContacto { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar el Nombre del Contacto")]
        [Display(Name = "NombreContacto")]
        [StringLength(50)]
        public string NombreContacto { get; set; }

     
    }
}
