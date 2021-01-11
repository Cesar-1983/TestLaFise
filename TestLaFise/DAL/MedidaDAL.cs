using EML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedidaDAL
    {
        private AppDbContext con = new AppDbContext();

        public int AgregarMedida(Medida item)
        {
            int Id = 0;
            Medida model = new Medida();
            try
            {
                model = con.SqlQuery<Medida>("usp_add_Medida", new
                {
                    Nombre = item.Nombre,
                    DescripcionLarga = item.DescripcionLarga,
                    Codigo = item.Codigo

                }).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }

            return Id;
        }

        public int ActualizarMedida(Medida item)
        {
            int Id = 0;
            Medida model = new Medida();
            try
            {

                Id = con.Database.ExecuteSqlCommand("exec usp_upd_Medida @MedidaId,@Nombre,@DescripcionLarga,@Codigo",
                    new SqlParameter("@MedidaId", item.MedidaId),
                    new SqlParameter("@Nombre", item.Nombre),
                    new SqlParameter("@DescripcionLarga", item.DescripcionLarga),
                    new SqlParameter("@Codigo",item.Codigo)

                );
            }
            catch (Exception ex)
            {

                throw;
            }

            return Id;
        }

        public Medida ObtenerMedida(int id)
        {

            Medida model = new Medida();
            try
            {
                model = con.SqlQuery<Medida>("usp_get_Medida", new
                {
                    MedidaId = id
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }

            return model;
        }

        public List<Medida> ObtenerListaMedidas()
        {
            List<Medida> lista = new List<Medida>();
            try
            {
                lista = con.SqlQuery<Medida>("usp_get_all_Medida", new { }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return lista;
        }

        public int Delete(int Id)
        {
            try
            {

                Id = con.Database.ExecuteSqlCommand("exec usp_del_medida @MedidaId",
                    new SqlParameter("@MedidaId", Id)
                );
            }
            catch (Exception ex)
            {

                throw;
            }

            return Id;
        }
    }
}
