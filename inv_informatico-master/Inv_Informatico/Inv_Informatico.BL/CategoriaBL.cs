using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Informatico.BL
{
    public class CategoriasBL
    {
        Contexto _contexto;
        public List<Categoria> ListadeCategorias { get; set; }

        public CategoriasBL()
        {
            _contexto = new Contexto();
            ListadeCategorias = new List<Categoria>();
        }

        public List<Categoria> ObtenerCategoria()
        {
            ListadeCategorias = _contexto.Categorias.ToList();
            return ListadeCategorias;

        }

        public void GuardarCategoria(Categoria categoria)
        {
            if (categoria.id == 0)
            {
                _contexto.Categorias.Add(categoria);
            }
            else
            {
                var categoriaExistente = _contexto.Hardware.Find(categoria.id);
                categoriaExistente.Descripcion = categoria.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public Categoria ObtenerCategoria(int id)
        {
            var categoria = _contexto.Categorias.Find(id);
            return categoria;
        }

        public void EliminarCategoria(int id)
        {
            var categoria = _contexto.Categorias.Find(id);
            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();
        }

    }
}


