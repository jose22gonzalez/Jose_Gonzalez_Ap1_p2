using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jose_Gonzalez_Ap1_p2.Entidades
{
    public class Productos
    {

        [Key] public int ProductoId { get; set; }

       [Required(ErrorMessage ="Es obligatorio introducir la descricion")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Es obligatorio Introducir la existencia")]
        [Range(1, int.MaxValue, ErrorMessage = "La existencia debe ser Mayor o igual 1")]
        public double Existencia { get; set; }
        public DateTime FechaCaducidad {get; set;} = DateTime.Now;

        [Range(1, int.MaxValue, ErrorMessage ="La existencia debe ser Mayor o igual 1")]
        public double Costo { get; set; }

        public double ValorInventario { get; set; }
        
        public int Ganancia { get; set; }
        
        public int Precio { get; set; }
        public int Peso { get; set; }
      
        [ForeignKey("ProductoId")]
        public virtual List<ProductosDetalles> ProductosDetalles {get; set;} = new List<ProductosDetalles>();
    }
}