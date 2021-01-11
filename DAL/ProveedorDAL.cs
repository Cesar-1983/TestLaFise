using EML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProveedorDAL
    {
        private AppDbContext con = new AppDbContext();

        public int AgregarProveedor(Proveedor item)
        {
            int Id = 0;
            Proveedor model = new Proveedor();
            try
            {
                model = con.SqlQuery<Proveedor>("usp_add_Proveedor", new
                {
                    Nombre = item.Nombre,
                    Representante = item.Representante
                    
                }).FirstOrDefault();
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

                Id = con.Database.ExecuteSqlCommand("exec usp_upd_Proveedor @ProveedorId,@Nombre,@Representante",
                    new SqlParameter("@ProveedorId", item.ProveedorId),
                    new SqlParameter("@Nombre", item.Nombre),
                    new SqlParameter("@Representante", item.Representante)
                    
                );
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
                model = con.SqlQuery<Proveedor>("usp_get_Proveedor", new
                {
                    ProveedorId = id
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }

            return model;
        }

        public List<Proveedor> ObtenerListaProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            try
            {
                lista = con.SqlQuery<Proveedor>("usp_get_all_Proveedor", new { }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return lista;
        }
    }
}
