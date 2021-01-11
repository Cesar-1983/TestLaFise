using EML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriaDAL
    {
        private AppDbContext con = new AppDbContext();
        public CategoriaDAL()
        {

        }

        public int AgregarCategoria(Categoria item)
        {
            int Id = 0;
            Categoria model = new Categoria();
            try
            {
                model = con.SqlQuery<Categoria>("usp_add_categoria", new
                {
                    Nombre = item.Nombre,
                    DescripcionLarga = item.DescripcionLarga,
                    Abreviatura = item.Abreviatura
                }).FirstOrDefault();
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
            Categoria model = new Categoria();
            try
            {

                Id = con.Database.ExecuteSqlCommand("exec usp_upd_categoria @CategoriaId,@Nombre,@DescripcionLarga,@Abreviatura",
                    new SqlParameter("@CategoriaId", item.CategoriaId),
                    new SqlParameter("@Nombre", item.Nombre),
                    new SqlParameter("@DescripcionLarga", item.DescripcionLarga),
                    new SqlParameter("@Abreviatura", item.Abreviatura)
                );
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
                model = con.SqlQuery<Categoria>("usp_get_categoria", new
                {
                    CategoriaId = id
                }).FirstOrDefault();
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
                lista = con.SqlQuery<Categoria>("usp_get_all_categoria", new { }).ToList();
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

                Id = con.Database.ExecuteSqlCommand("exec usp_del_categoria @CategoriaId",
                    new SqlParameter("@CategoriaId", Id)
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
