using Inv_Informatico.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inv_Informatico.Web.Controllers
{
    public class HomeController : Controller
    {
        InventarioBL _inventarioBL;
        UbicacionesBL _ubicacionBL;

        public HomeController()
        {
            _inventarioBL = new InventarioBL();
            _ubicacionBL = new UbicacionesBL();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Ubicacion");
        }

        public ActionResult Inventario(int id)
        {
            var inventario = _inventarioBL.ObtenerInventarioPorUbicacion(id);
            var ubicacion = _ubicacionBL.ObtenerUbicacion(id);

            ViewBag.Ubicacion = ubicacion;

            return View(inventario);
        }
    }
}