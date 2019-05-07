using Inv_Informatico.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inv_Informatico.Web.Controllers
{
    public class UbicacionController : Controller
    {
        UbicacionesBL _ubicacionBL;

        public UbicacionController()
        {
            _ubicacionBL = new UbicacionesBL();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Ubicacion ubicacion)
        {
            var ubicacionExistente = _ubicacionBL.ObtenerUbicacionPorDescripcion(ubicacion.Descripcion);

            if (ubicacionExistente != null)
            {
                return RedirectToAction("Inventario", "Home", new { id = ubicacionExistente.Id });
            }

            ModelState.AddModelError("Descripcion", "La ubicación no existe");

            return View(ubicacion);
        }
    }
}