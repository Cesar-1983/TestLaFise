using EML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ImagenProductoDAL
    {
        private AppDbContext con = new AppDbContext();

        public ImagenProductoDAL() { }

        public List<ImagenProducto> ObtenerImagenesPorProducto(int id)
        {
            List<ImagenProducto> Lista = new List<ImagenProducto>();
            try
            {
                Lista = con.SqlQuery<ImagenProducto>("sp_get_all_ImagenesProductos_by_Producto", new {
                    ProductoId =  id
                }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return Lista;
        }

        public ImagenProducto ObtenerDetalleImagenPorProducto(int id)
        {
            ImagenProducto model = new ImagenProducto();
            try
            {
                model = con.SqlQuery<ImagenProducto>("sp_get_detalle_ImagenesProductos", new
                {
                    ImagenProductoId = id
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
            return model;
        }

        public int AgregarImagenPorProducto(ImagenProducto item)
        {
            int esta = 0;
            try
            {
                esta = con.Database.ExecuteSqlCommand("exec sp_add_ImagenesProductos @ProductoId,@file_name,@file_ext,@file_base64,@description,@IsPrincipal",
                    
                        new SqlParameter("@ProductoId",item.ProductoId),
                        new SqlParameter("@file_name", item.file_name),
                        new SqlParameter("@file_ext", item.file_ext),
                        new SqlParameter("@file_base64", item.file_base64),
                        new SqlParameter("@description", item.description),
                        new SqlParameter("@IsPrincipal", item.IsPrincipal)
                    );

            }
            catch (Exception ex)
            {

                throw;
            }
            return esta;
        }
    }
}
