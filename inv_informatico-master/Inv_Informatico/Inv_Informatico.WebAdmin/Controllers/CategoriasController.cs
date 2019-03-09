using Inv_Informatico.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inv_Informatico.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriasBL _CategoriasBL;

        public CategoriasController()
        {
            _CategoriasBL = new CategoriasBL();
        }
        // GET: Categorias
        public ActionResult Index()
        {
            var listadeCategorias = _CategoriasBL.ObtenerCategoria();
            return View(listadeCategorias);
        }

        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();

            return View(nuevaCategoria);
        }

        [HttpPost]
        public ActionResult Crear(Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No ingrese espacios en blanco");
                    return View(categoria);
                }
                    _CategoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Editar(int id)
        {
            var categoria = _CategoriasBL.ObtenerCategoria(id);

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No ingrese espacios en blanco");
                    return View(categoria);
                }
                _CategoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Detalle(int id)
        {
            var categoria = _CategoriasBL.ObtenerCategoria(id);

            return View(categoria);

        }
        public ActionResult Eliminar(int id)
        {
            var categoria = _CategoriasBL.ObtenerCategoria(id);

            return View(categoria);

        }
        [HttpPost]
        public ActionResult Eliminar(Categoria categoria)
        {
            _CategoriasBL.EliminarCategoria(categoria.id);
            return RedirectToAction("Index");
        }
    }
    }