using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Informatico.BL
{
    public class Inventario
    {
        public int Id { get; set; }

        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; }

        public int HardwareId { get; set; }
        public Hardware Hardware { get; set; }

        public int MovimientoId { get; set; }
        public Movimiento Movimiento { get; set; }

        public int Cantidad { get; set; }

        public string Observaciones { get; set; }
    }
}
