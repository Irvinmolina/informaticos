using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Informatico.BL
{
    public class Categoria
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Ingrese la Categoria")]
        public String Descripcion { get; set; }
    }
}