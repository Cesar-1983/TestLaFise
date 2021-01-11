using BLL;
using EML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class CategoriaController : ApiController
    {
        private CategoriaBLL bll = new CategoriaBLL();

        public IHttpActionResult GetAllCategoria()
        {
            List<Categoria> ListaCategoria = new List<Categoria>();
             
            try
            {
                ListaCategoria = bll.ObtenerListaCategorias();
                if (ListaCategoria.Count == 0)
                    return NotFound();
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }
            return Ok(ListaCategoria);
        }

        public IHttpActionResult PostNewCategoria(Categoria model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos Invalidos");

            try
            {
                var item = bll.ObtenerCategoria(model.CategoriaId);

                if (item == null)
                    bll.AgregarCategoria(model);
                else
                    bll.ActualizarCategoria(model);
            }
            catch (Exception)
            {

                return InternalServerError();
            }

            return Ok();


        }
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Categoria Invalida");
            try
            {
                bll.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

                return InternalServerError();
            }

        }

        public IHttpActionResult GetCategoria(int id)
        {
            if (id <= 0)
                return BadRequest("Categoria Invalida");
            try
            {
                var item = bll.ObtenerCategoria(id);

                if (item == null)
                    return NotFound();
                else
                    return Ok(item);
            }
            catch (Exception)
            {

                return InternalServerError();
            }

            
        }

    }
}
