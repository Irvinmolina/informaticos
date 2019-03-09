using Inv_Informatico.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inv_Informatico.WebAdmin.Controllers
{
    public class HardwareController : Controller
    {
        HardwareBL _HardwareBL;
        CategoriasBL _CategoriasBL;
        public HardwareController()
        {
            _HardwareBL = new HardwareBL();
            _CategoriasBL = new CategoriasBL();
        }
        // GET: Productos
        public ActionResult Index()
        {
            var listaHardware = _HardwareBL.ObtenerHardware(); 
            return View(listaHardware );
        }

     
        public ActionResult Crear()
        {
            var nuevoHardware = new Hardware();
            var categorias = _CategoriasBL.ObtenerCategoria();
            ViewBag.ListaCategorias = new SelectList(categorias, "id", "Descripcion");

            return View(nuevoHardware);
        }

       [HttpPost]
        public ActionResult Crear(Hardware hardware, HttpPostedFileBase imagen)
        {
            if(ModelState.IsValid)
            {
                if(imagen != null)
                {
                    hardware.UrlImagen = GuardarImagen(imagen);
                }

                _HardwareBL.GuardarHardware(hardware);

                return RedirectToAction("Index");
            }
            var categorias = _CategoriasBL.ObtenerCategoria();
            ViewBag.ListaCategorias = new SelectList(categorias, "id", "Descripcion");

            return View(hardware);
        }

        public ActionResult Editar(int id)
        {
            var hardware = _HardwareBL.ObtenerHardware(id);
            var categorias = _CategoriasBL.ObtenerCategoria();
            ViewBag.Categoriaid = new SelectList(categorias, "id", "Descripcion",hardware.Categoriaid);
            return View(hardware);
        }

        [HttpPost]
        public ActionResult Editar(Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                _HardwareBL.GuardarHardware(hardware);

                return RedirectToAction("Index");
            }
            var categorias = _CategoriasBL.ObtenerCategoria();
            ViewBag.ListaCategorias = new SelectList(categorias, "id", "Descripcion");

            return View(hardware);
        }

        public ActionResult Detalle(int id)
        {
            var hardware = _HardwareBL.ObtenerHardware(1);
            return View(1);
        }


        public ActionResult Eliminar(int id)
        {
            var producto = _HardwareBL.ObtenerHardware(id);
            return View(id);
        }

        [HttpPost]
        public ActionResult Eliminar(Hardware hardware)
        {
            _HardwareBL.EliminarHardware(hardware.Id);
            return RedirectToAction ("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string paht = Server.MapPath("~/Imagenes/" + imagen.FileName);
                imagen.SaveAs(paht);

            return "/Imagenes/" + imagen.FileName;
        }

    }
}