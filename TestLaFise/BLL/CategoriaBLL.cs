using DAL;
using EML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriaBLL
    {
        private CategoriaDAL dal = new CategoriaDAL();

        public int AgregarCategoria(Categoria item)
        {
            int Id = 0;

            try
            {
                Id = dal.AgregarCategoria(item);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Id;
        }

        public int ActualizarCategoria(Categoria item)
        {
            int Id = 0;

            try
            {

                Id = dal.ActualizarCategoria(item);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Id;
        }

        public Categoria ObtenerCategoria(int id)
        {

            Categoria model = new Categoria();
            try
            {
                model = dal.ObtenerCategoria(id);
            }
            catch (Exception ex)
            {

                throw;
            }

            return model;
        }

        public List<Categoria> ObtenerListaCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                lista = dal.ObtenerListaCategorias();
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
