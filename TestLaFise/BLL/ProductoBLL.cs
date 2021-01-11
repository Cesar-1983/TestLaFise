using DAL;
using EML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductoBLL
    {
        private ProductoDAL dal = new ProductoDAL();

        public int AgregarProducto(Producto item)
        {
            int Id = 0;

            try
            {
                Id = dal.AgregarProducto(item);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Id;
        }

        public int ActualizarProducto(Producto item)
        {
            int Id = 0;
            Producto model = new Producto();
            try
            {

                Id = dal.ActualizarProducto(item);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Id;
        }

        public Producto ObtenerProducto(int id)
        {

            Producto model = new Producto();
            try
            {
                model = dal.ObtenerProducto(id);
            }
            catch (Exception ex)
            {

                throw;
            }

            return model;
        }

        public List<Producto> ObtenerListaProductos()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                lista = dal.ObtenerListaProductos();
            }
            catch (Exception ex)
            {

                throw;
            }
            return lista;
        }

    }
}
