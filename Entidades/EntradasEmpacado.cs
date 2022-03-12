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
        public int Id { get; set; }
        public DateTime? Fecha { get; set; } = null;
        public string? Concepto { get; set; }
        public string? Producto { get; set; }
        public int Cantidad { get; set; }
    }
}