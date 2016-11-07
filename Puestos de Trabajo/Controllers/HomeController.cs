using Puestos_de_Trabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Negocio;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Puestos_de_Trabajo.Controllers
{
    public class HomeController : Controller
    {
        Gestor Gestor = new Gestor();
        private PuestosEntities db = new PuestosEntities();
        SqlConnection conn = new SqlConnection("data source=DESKTOP-GE0M946\\SQLEXPRESS;initial catalog=Puestos;integrated security=True;");

        public ActionResult Index(String cargo)
        {
            var puestoTrabajo = from s in db.PuestoTrabajo select s;

            if (!String.IsNullOrEmpty(cargo))
            {
                puestoTrabajo = puestoTrabajo.Where(j => j.cargo.Contains(cargo));
            }
            return View(puestoTrabajo);
        }
        /*
        public ActionResult GetCategoria(Int32 IdCategoria)
        {
            Gestor Gestor = new Gestor();
            ViewBag.ListadoCategoria = Gestor.ListadoCategoria();
            ViewBag.Categoria = Gestor.ObtenerPuestoTrabajo(IdCategoria);
            ViewBag.ListadoCategoriaPaginacion = Gestor.ListadoPuestoTrabajoPaginacion(1, 5);
            ViewBag.ListadoCategoriaPaginacionCount = Gestor.ListadoPuestoTrabajoPaginacionCount(5);
            ViewBag.CantidadRegistros = Gestor.CantidadRegistros();
            ViewBag.nroPagina = 1;
            return View();
        }
    */
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

            /*
        public ActionResult Paginar(Int32 nroPagina)
        {
            ViewBag.ListadoCategoriaPaginacion = Gestor.ListadoPuestoTrabajoPaginacion(nroPagina, 5);
            ViewBag.ListadoCategoriaPaginacionCount = Gestor.ListadoPuestoTrabajoPaginacionCount(5);
            ViewBag.CantidadRegistros = Gestor.CantidadRegistros();
            ViewBag.nroPagina = nroPagina;

            return View("Home");
        }
        */
    }

}
 