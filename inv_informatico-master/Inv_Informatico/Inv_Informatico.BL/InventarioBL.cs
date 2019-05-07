using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Informatico.BL
{
    public class InventarioBL
    {
        Contexto _contexto;
        public List<Inventario> ListadeInventario { get; set; }

        public InventarioBL()
        {
            _contexto = new Contexto();
            ListadeInventario = new List<Inventario>();
        }

        public List<Inventario> ObtenerInventarioPorUbicacion(int ubicacionId)
        {
            ListadeInventario = _contexto.Inventario
            .Include("Ubicacion")
            .Include("Hardware")
            .Include("Movimiento")
            .Where(r => r.UbicacionId == ubicacionId)
            .ToList();

            return ListadeInventario;
        }
    }
}
