using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jose_Gonzalez_Ap1_p2.Entidades;

namespace Jose_Gonzalez_Ap1_p2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos {get; set;}
        public DbSet<EntradasEmpacados> EntradasEmpacados { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options){}
    }
}