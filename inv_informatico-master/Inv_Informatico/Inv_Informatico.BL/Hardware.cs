using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Informatico.BL
{
    
    public class Hardware
    {
        public Hardware()
        {
            Activo = true;
        }
        public int Id { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Ingrese la descripcion")]
        [MinLength (5, ErrorMessage = "Ingrese minimo 5 Caracteres")]
        [MaxLength (20, ErrorMessage = "Ingese un maxiomo de 20 letras")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese la marca del dispositivo")]
        public string Marca { get; set; }
        public Categoria Categoriaid { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
        public bool Activo { get; set; }
    }
}
