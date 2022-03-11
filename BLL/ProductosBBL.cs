using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jose_Gonzalez_Ap1_p2.DAL;
using Jose_Gonzalez_Ap1_p2.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Jose_Gonzalez_Ap1_p2.BLL
{
    public class ProductosBBL
    {
        private Contexto _contexto;
        public ProductosBBL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int productoid)
        {
            bool paso = false;

            try
            {
                paso = _contexto.Productos.Any(p => p.ProductoId == productoid);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public bool Existe(string? descripcion)
        {
            bool paso = false;
            try
            {
                paso = _contexto.Productos.Any(p => p.Descripcion == descripcion);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        private bool Insertar(Productos productos)
        {
            bool paso = false;
            try
            {
                _contexto.Productos.Add(productos);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        private bool Modificar(Productos productos)
        {
            bool paso = false;

            try
            {
                _contexto.Database.ExecuteSqlRaw($"Delete FROM ProductosDetalles where ProductoId={productos.ProductoId}");

                foreach (var anterior in productos.ProductosDetalles)
                {
                    _contexto.Entry(anterior).State = EntityState.Added;
                }

                _contexto.Entry(productos).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }

            return paso;
        }

        public bool Guardar(Productos productos)
        {
            if(Existe(productos.ProductoId))
                return Modificar(productos);
            else
                return Insertar(productos);
        }

        public Productos Buscar(int productoid)
        {
            Productos productos = new Productos();

            try
            {
                productos = _contexto.Productos.Include(z => z.ProductosDetalles)
                                                .Where(x => x.ProductoId == productoid)
                                                .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return productos;
        }

        public bool Eliminar(int productoid)
        {
            bool paso = false;

            try
            {
                var producto = _contexto.Productos.Find(productoid);
                if(producto != null)
                {
                    _contexto.Productos.Remove(producto);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

      public List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();
            try
            {
                lista = _contexto.Productos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            
            return lista;
        }

        public List<ProductosDetalles> GetListD(Expression<Func<ProductosDetalles, bool>> criterio)
        {
            List<ProductosDetalles> lista = new List<ProductosDetalles>();
            try
            {
                lista = _contexto.ProductosDetalles.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            
            return lista;
        }

       
    }
}