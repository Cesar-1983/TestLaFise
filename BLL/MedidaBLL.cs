using DAL;
using EML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedidaBLL
    {
        private MedidaDAL dal = new MedidaDAL();

        public int AgregarMedida(Medida item)
        {
            int Id = 0;

            try
            {
                Id = dal.AgregarMedida(item);
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

                Id = dal.ActualizarMedida(item);
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
                model = dal.ObtenerMedida(id);
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
                lista = dal.ObtenerListaMedidas();
            }
            catch (Exception ex)
            {

                throw;
            }
            return lista;
        }
        public int Delete(int Id)
        {


            return dal.Delete(Id);
        }
    }
}
