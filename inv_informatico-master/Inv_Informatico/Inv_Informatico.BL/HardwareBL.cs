using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Informatico.BL
{
    public class HardwareBL
    {
        Contexto _contexto;
        public List<Hardware> ListadeHardware { get; set; }

        public HardwareBL()
        {
            _contexto = new Contexto();
            ListadeHardware = new List<Hardware>();
        }

        public List<Hardware> ObtenerHardware()
        {
            ListadeHardware = _contexto.Hardware
                .Include("Categoria")
                .ToList();
            return ListadeHardware;

        }

        public void GuardarHardware(Hardware hardware)
        {
            if (hardware.Id == 0)
            {
                _contexto.Hardware.Add(hardware);
            }else
            {
                var hardwareExistente = _contexto.Hardware.Find(hardware.Id);
                hardwareExistente.Descripcion = hardware.Descripcion;
                hardwareExistente.Marca = hardware.Marca;
                hardwareExistente.UrlImagen = hardware.UrlImagen;
            }

            _contexto.SaveChanges();
        }

        public Hardware ObtenerHardware(int id)
        {
            var hardware = _contexto.Hardware
                .Include("Categoria").FirstOrDefault(p => p.Id == id);
            return hardware;
        }

        public void EliminarHardware(int id)
        {
            var hardware = _contexto.Hardware.Find(id);
            _contexto.Hardware.Remove(hardware);
            _contexto.SaveChanges();
        }
    }
}
