using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EML;
using BLL;

namespace Api.Controllers
{
    public class MedidaController : ApiController
    {
        private MedidaBLL bll = new MedidaBLL();

        public IHttpActionResult GetAllCategoria()
        {
            List<Medida> Lista = new List<Medida>();

            try
            {
                Lista = bll.ObtenerListaMedidas();
                if (Lista.Count == 0)
                    return NotFound();
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }
            return Ok(Lista);
        }

        public IHttpActionResult PostNewCategoria(Medida model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos Invalidos");

            try
            {
                var item = bll.ObtenerMedida(model.MedidaId);

                if (item == null)
                    bll.AgregarMedida(model);
                else
                    bll.ActualizarMedida(model);
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
    }
}
