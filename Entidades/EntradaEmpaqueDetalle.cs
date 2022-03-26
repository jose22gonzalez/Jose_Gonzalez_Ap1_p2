using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jose_Gonzalez_Ap1_p2.Entidades
{
    public class EntradaEmpaqueDetalle
    {
        [Key]
        public int EmpaqueDetalleId { get; set; }
        public int IdEmpacado { get; set; }
        public int CantidadProducido { get; set; }
        public string? Producto { get; set; }

    }
}