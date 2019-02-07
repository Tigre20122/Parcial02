using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Required(ErrorMessage ="Porfavor ingresar Nombre del producto")]
        [Display(Name ="Nombre del Producto")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Porfavor ingresar el precio unitario")]
        [Display(Name = "Precio Unitario")]
        public double PrecioUnitario { get; set; }
        [Required(ErrorMessage = "Porfavor ingresar el Precio al Publico")]
        [Display(Name = "Precio al Publico")]
        public double PrecioPublico { get; set; }
        [Required(ErrorMessage = "Porfavor ingresar Fecha de Fabricación")]
        [Display(Name = "Fecha de Fabricación")]
        public DateTime FechaFabricacion { get; set; }
        [Required(ErrorMessage = "Porfavor ingresar Fecha de Caducación")]
        [Display(Name = "Fecha de Caducaión")]
        public DateTime FechaCaducaion { get; set; }
        [Required(ErrorMessage = "Porfavor ingresar Iva si es 12% o 0%")]
        [Display(Name = "Iva")]
        public double Iva { get; set; }
        ///
        public Provedor Provedor { get; set; }
        [Required(ErrorMessage = "Porfavor Seleccionar Provedor")]
        [Display(Name ="Seleccion Provedor")]
        public int IdProvedor { get; set; }
    }
}
