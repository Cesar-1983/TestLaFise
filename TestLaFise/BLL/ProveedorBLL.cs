using DAL;
using EML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProveedorBLL
    {
        private ProveedorDAL dal = new ProveedorDAL();

        public int AgregarProveedor(Proveedor item)
        {
            int Id = 0;
            
            try
            {
                Id = dal.AgregarProveedor(item);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Id;
        }

        public int ActualizarProveedor(Proveedor item)
        {
            int Id = 0;
            Proveedor model = new Proveedor();
            try
            {

                Id = dal.ActualizarProveedor(item);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Id;
        }

        public Proveedor ObtenerProveedor(int id)
        {

            Proveedor model = new Proveedor();
            try
            {
                model = dal.ObtenerProveedor(id);
            }
            catch (Exception ex)
            {

                throw;
            }

            return model;
        }

        public List<Proveedor> ObtenerListaProveedors()
        {
            List<Proveedor> lista = new List<Proveedor>();
            try
            {
                lista = dal.ObtenerListaProveedores();
            }
            catch (Exception ex)
            {

                throw;
            }
            return lista;
        }
    }
}
