using Inv_Informatico.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inv_Informatico.WebAdmin.Controllers
{
    public class BodegasController : Controller
    {
        BodegasBL _bodegasBL;

        public BodegasController()
        {
            _bodegasBL = new BodegasBL();
        }

        // GET: Bodegas
        public ActionResult Index()
        {
            var listadeBodegas = _bodegasBL.ObtenerBodegas();

            return View(listadeBodegas);
        }

        public ActionResult Crear()
        {
            var nuevaBodega = new Bodega();

            return View(nuevaBodega);
        }

        [HttpPost]
        public ActionResult Crear(Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                if (bodega.Descripcion != bodega.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripción no debe contener espacios al inicio o al final");
                    return View(bodega);
                }

                _bodegasBL.GuardarBodega(bodega);

                return RedirectToAction("Index");
            }

            return View(bodega);
        }

        public ActionResult Editar(int id)
        {
            var bodega = _bodegasBL.ObtenerBodega(id);

            return View(bodega);
        }

        [HttpPost]
        public ActionResult Editar(Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                if (bodega.Descripcion != bodega.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripción no debe contener espacios al inicio o al final");
                    return View(bodega);
                }

                _bodegasBL.GuardarBodega(bodega);

                return RedirectToAction("Index");
            }

            return View(bodega);
        }

        public ActionResult Detalle(int id)
        {
            var bodega = _bodegasBL.ObtenerBodega(id);

            return View(bodega);
        }

        public ActionResult Eliminar(int id)
        {
            var bodega = _bodegasBL.ObtenerBodega(id);

            return View(bodega);
        }

        [HttpPost]
        public ActionResult Eliminar(Bodega bodega)
        {
            _bodegasBL.EliminarBodega(bodega.Id);

            return RedirectToAction("Index");
        }
    }
}