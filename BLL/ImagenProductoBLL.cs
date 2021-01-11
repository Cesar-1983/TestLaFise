using DAL;
using EML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ImagenProductoBLL
    {
        private ImagenProductoDAL dal = new ImagenProductoDAL();

        public List<ImagenProducto> ObtenerImagenesPorProducto(int id)
        {
            List<ImagenProducto> Lista = new List<ImagenProducto>();
            try
            {
                Lista =  dal.ObtenerImagenesPorProducto(id);
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
                model = dal.ObtenerDetalleImagenPorProducto(id);
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
                esta = dal.AgregarImagenPorProducto(item);

            }
            catch (Exception ex)
            {

                throw;
            }
            return esta;
        }

    }
}
