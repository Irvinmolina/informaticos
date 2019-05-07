using Inv_Informatico.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inv_Informatico.WebAdmin.Controllers
{
     public class UbicacionesController : Controller
    {
        UbicacionesBL _UbicacionesBL;
        BodegasBL _BodegasBL;

        public UbicacionesController()
        {
            _UbicacionesBL = new UbicacionesBL();
            _BodegasBL = new BodegasBL();
        }

        // GET: Ubicaciones
        public ActionResult Index()
        {
            var listadeUbicaciones = _UbicacionesBL.ObtenerUbicacion();

            return View(listadeUbicaciones);
        }

        public ActionResult Crear()
        {
            var nuevoUbicacion = new Ubicacion();
            var bodegas = _BodegasBL.ObtenerBodegas();
            ViewBag.ListaBodegas = new SelectList(bodegas, "Id", "Descripcion");

            return View(nuevoUbicacion);
        }

        [HttpPost]
        public ActionResult Crear(Ubicacion ubicacion)
        {

            var bodegas = _BodegasBL.ObtenerBodegas();
            ViewBag.ListaBodegas= new SelectList(bodegas, "Id", "Descripcion");

            _UbicacionesBL.GuardarUbicacion(ubicacion);

            return RedirectToAction("Index");

        }

        public ActionResult Editar(int Id)
        {
            var ubicacion = _UbicacionesBL.ObtenerUbicacion(Id);
            var bodegas = _BodegasBL.ObtenerBodegas();

            ViewBag.BodegaId = new SelectList(bodegas, "id", "Descripcion", ubicacion.BodegaId);

            return View(ubicacion);
        }

        [HttpPost]
        public ActionResult Editar(Ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                _UbicacionesBL.GuardarUbicacion(ubicacion);
                return RedirectToAction("Index");   
            }
            var bodegas = _BodegasBL.ObtenerBodegas();

           ViewBag.BodegaId =
           new SelectList(bodegas, "Id", "Descripcion");

           return View(ubicacion);
        }

        public ActionResult Detalle(int id)
        {
            var ubicacion = _UbicacionesBL.ObtenerUbicacion(id);

            return View(ubicacion);
        }

        public ActionResult Eliminar(int id)
        {
            var ubicacion = _UbicacionesBL.ObtenerUbicacion(id);

            return View(id);
        }

        [HttpPost]
        public ActionResult Eliminar(Ubicacion ubicacion)
        {
            _UbicacionesBL.EliminarUbicacion(ubicacion.Id);

            return RedirectToAction("Index");
        }

    }
}