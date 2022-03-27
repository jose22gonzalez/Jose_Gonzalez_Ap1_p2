using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jose_Gonzalez_Ap1_p2.Entidades
{
    public class EntradasEmpacados
    {
        [Key]
        public int IdEmpacado { get; set; }
        public DateTime? Fecha { get; set; } = null;
        public string? Concepto { get; set; }
        public int CantidadUtilizado { get; set; }
        public int PesoEmpaquetado { get; set; }
        public string? ProductoEmpaquetado { get; set; }

        [ForeignKey("IdEmpacado")]
        public virtual List<EntradaEmpaqueDetalle> EntradaEmpaqueDetalle {get; set;} = new List<EntradaEmpaqueDetalle>();
    }
}