using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class CategoriaController : Controller
    {
        //private CategoriaBLL bll = new CategoriaBLL();
        // GET: Categoria
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64189/api/");
                //HTTP GET
                var responseTask = client.GetAsync("student");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<StudentViewModel>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    students = Enumerable.Empty<StudentViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            ViewBag.TituloViewPanel = "Catalogo de Categorías";
            var ListaCategoria = bll.ObtenerListaCategorias();
            return View(ListaCategoria);
        }

        public ActionResult Editar(int Id)
        {
            ViewBag.TituloViewPanel = "Edición de Categoría";
            var categoria = bll.ObtenerCategoria(Id);
            return View(categoria);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Categoria model)
        {
            ViewBag.TituloViewPanel = "Edición de Categoría";
            if (ModelState.IsValid)
            {
                bll.ActualizarCategoria(model);
            }

            return RedirectToAction("Index");

        }

        public ActionResult Crear()
        {
            ViewBag.TituloViewPanel = "Agregar Categoría";
            Categoria model = new Categoria();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Categoria model)
        {
            ViewBag.TituloViewPanel = "Agregar Categoría";
            if (ModelState.IsValid)
            {
                bll.AgregarCategoria(model);
            }

            return RedirectToAction("Index");
        }
    }
}