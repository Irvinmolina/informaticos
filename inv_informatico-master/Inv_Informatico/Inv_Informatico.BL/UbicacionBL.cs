using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Informatico.BL
{
    public class UbicacionesBL
    {
 
        Contexto _contexto;
    public List<Ubicacion> ListadeUbicacion { get; set; }

    public UbicacionesBL()
    {
        _contexto = new Contexto();
        ListadeUbicacion = new List<Ubicacion>();
    }

    public List<Ubicacion> ObtenerUbicacion()
    {
            ListadeUbicacion = _contexto.Ubicaciones
            .Include("Bodega")
            .ToList();

        return ListadeUbicacion;
    }

    public void GuardarUbicacion(Ubicacion ubicacion)
    {
        if (ubicacion.Id == 0)
        {
            _contexto.Ubicaciones.Add(ubicacion);
        }
        else
        {
            var ubicacionExistente = _contexto.Ubicaciones.Find(ubicacion.Id);

            ubicacionExistente.Descripcion = ubicacion.Descripcion;
        }

        _contexto.SaveChanges();
    }

    public Ubicacion ObtenerUbicacion(int id)
    {
        var ubicacion = _contexto.Ubicaciones
            .Include("Bodega").FirstOrDefault(p => p.Id == id);

        return ubicacion;
    }

    public Ubicacion ObtenerUbicacionPorDescripcion(string descripcion)
    {
        var ubicacion = _contexto.Ubicaciones
            .Include("Bodega").FirstOrDefault(p => p.Descripcion == descripcion);

        return ubicacion;
    }

        public void EliminarUbicacion(int id)
    {
        var ubicacion = _contexto.Ubicaciones.Find(id);

        _contexto.Ubicaciones.Remove(ubicacion);
        _contexto.SaveChanges();
    }
}
}
