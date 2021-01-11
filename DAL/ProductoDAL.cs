using EML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoDAL
    {
        private AppDbContext con = new AppDbContext();

        public int AgregarProducto(Producto item)
        {
            int Id = 0;
            Producto model = new Producto();
            try
            {
                model = con.SqlQuery<Producto>("usp_add_Producto", new
                {
                    CategoriaId = item.CategoriaId,
                    ProveedorId =  item.ProveedorId,
                    MedidaId =  item.MedidaId,
                    Nombre = item.Nombre,
                    DescripcionLarga = item.DescripcionLarga,
                    Codigo = item.Codigo,
                    Precio = item.Precio,
                    Existencia = item.Existencia

                }).FirstOrDefault();
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

                Id = con.Database.ExecuteSqlCommand("exec usp_upd_Producto @ProductoId,@CategoriaId,@ProveedorId,@MedidaId,@Nombre,@DescripcionLarga,@Codigo,@Precio,@Existencia",
                    new SqlParameter("@ProductoId", item.ProductoId),
                    new SqlParameter("@CategoriaId", item.CategoriaId),
                    new SqlParameter("@ProveedorId", item.ProveedorId),
                    new SqlParameter("@MedidaId", item.MedidaId),
                    new SqlParameter("@Nombre", item.Nombre),
                    new SqlParameter("@DescripcionLarga", item.DescripcionLarga),
                    new SqlParameter("@Codigo", item.Codigo),
                    new SqlParameter("@Precio", item.Precio),
                    new SqlParameter("@Existencia", item.Existencia)
                );
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
                model = con.SqlQuery<Producto>("usp_get_Producto", new
                {
                    ProductoId = id
                }).FirstOrDefault();
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
                lista = con.SqlQuery<Producto>("usp_get_all_Producto", new { }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return lista;
        }

    }
}
