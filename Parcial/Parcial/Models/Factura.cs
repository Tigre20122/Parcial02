using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.Models
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
       
        public Cliente Cliente { get; set; }
        [Required(ErrorMessage ="Seleccionar el cliente porfavor")]
        [Display(Name ="Cliente")]
        public int IdCliente { get; set; }

        public Producto Producto { get; set; }

        [Required(ErrorMessage ="Seleccionar Producto")]
        [Display(Name ="Producto")]
        public int IdProducto { get; set; }
       
    }
}
