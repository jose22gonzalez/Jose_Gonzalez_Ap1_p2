using System.Reflection.Metadata;
using System.Diagnostics.Tracing;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jose_Gonzalez_Ap1_p2.DAL;
using Jose_Gonzalez_Ap1_p2.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Jose_Gonzalez_Ap1_p2.BLL
{
    public class EntradaEmpacadosBBL
    {
        private Contexto _contexto;
        private Productos producto = new Productos();
        public EntradaEmpacadosBBL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int id)
        {
            bool paso = false;

            try
            {
                paso = _contexto.EntradasEmpacados.Any(e => e.IdEmpacado == id);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
        public EntradasEmpacados Buscar(int id)
        {
            EntradasEmpacados entradas = new EntradasEmpacados();

            try
            {
                 entradas = _contexto.EntradasEmpacados.Include(z => z.EntradaEmpaqueDetalle)
                                                .Where(x => x.IdEmpacado == id)
                                                .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return entradas;
        }
        public bool Guardar(EntradasEmpacados entrada)
        {
            if (Existe(entrada.IdEmpacado))
                return Modificar(entrada);
            else
                return Insertar(entrada);
        }

        private bool Insertar(EntradasEmpacados entrada)
        {
            bool paso = false;
            try
            {
                _contexto.EntradasEmpacados.Add(entrada);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public bool Modificar(EntradasEmpacados entrada)
        {
            bool paso = false;

            try
            {
                _contexto.Database.ExecuteSqlRaw($"Delete FROM EntradasEmpacados where IdEmpacado={entrada.IdEmpacado}");
                foreach (var anterior in entrada.EntradaEmpaqueDetalle)
                {
                    _contexto.Entry(anterior).State = EntityState.Added;
                }

                _contexto.Entry(entrada).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

         public bool Modificarpararestar(Productos producto, EntradasEmpacados entrada)
        {
            bool paso = false;
            try
            {
                paso = _contexto.SaveChanges() > 0;

                foreach (var item in entrada.EntradaEmpaqueDetalle)
                {
                    Productos encontrado = _contexto.Productos.Find(item.EmpaqueDetalleId);
                    _contexto.Entry(encontrado).State = EntityState.Modified;
                    paso = _contexto.SaveChanges() > 0;

                }


                _contexto.Database.ExecuteSqlRaw($"DELETE FROM Productosdetalle WHERE ProductoId={producto.ProductoId}");

                foreach (var Anterior in producto.ProductosDetalles)
                {
                    _contexto.Entry(Anterior).State = EntityState.Added;
                }

                _contexto.Entry(producto).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }





        public bool Eliminar(int id)
        {
            bool paso = false;

            try
            {


                var entrada = _contexto.EntradasEmpacados.Find(id);
                if (entrada != null)
                {
                    _contexto.EntradasEmpacados.Remove(entrada);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public List<EntradasEmpacados> GetListEntradaE(Expression<Func<EntradasEmpacados, bool>> criterio)
        {
            List<EntradasEmpacados> lista = new List<EntradasEmpacados>();
            try
            {
                lista = _contexto.EntradasEmpacados.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }
    }
}