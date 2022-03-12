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
                paso = _contexto.EntradasEmpacados.Any(e => e.Id == id);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public bool Guardar(EntradasEmpacados entrada)
        {
            
            /*if(Existe(entrada.Id))
                return Modificar(entrada);
            else
                return Insertar(entrada);*/
                return true;
        }

         private bool Insertar(EntradasEmpacados entrada)
        {
            bool paso = false;
            try
            {
                _contexto.EntradasEmpacados.Add(entrada);
                foreach (var detalle in producto.ProductosDetalles)
                {
                    _contexto.Entry(detalle).State = EntityState.Added;
                    _contexto.Entry(detalle.Cantidad).State = EntityState.Modified;
                   //producto.Existencia -= detalle.Cantidad;
                }

                var producido = _contexto.Productos.Find(entrada.Id).Existencia += entrada.Cantidad;
                paso = _contexto.SaveChanges() > 0;
            }catch(Exception)
            {
                throw;
            }

            return paso;
        }

        private bool Modificar(EntradasEmpacados entrada)
        {
            bool paso = false;
            try
            {
                var entradaAnterior = _contexto.EntradasEmpacados
                    .Where(e => e.Id == entrada.Id)
                    .Include(e => e.ProductosDetalles)
                    .ThenInclude(e => e.Productos)
                    .AsNoTracking()
                    .SingleOrDefault();
                
                foreach (var detalle in entradaAnterior.ProductosDetalles)
                {
                    detalle.Productos.Existencia += detalle.Cantidad;
                }

                  _contexto.Database.ExecuteSqlRaw($"Delete FROM ProductosDetalles where ProductoId={productos.ProductoId}");

            }
            catch(Exception)
            {
                throw;
            }
        }


    }
}