using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenieria
{
    public class Itinerario
    {
        public Usuario usuario { get; set; }

        public Cuenta cuenta { get; set; }
        public List<IViaje> viajes { get; set; } = new List<IViaje>();

        public void AgregarViaje(IViaje viaje)
        {
            viajes.Add(viaje);
        }

        public decimal CalcularCostoTotal()
        {
            return viajes.Sum(v => v.Precio);
        }

        public void CancelarViaje(IViaje viaje)
        {
            if (viajes.Contains(viaje))
            {
                viajes.Remove(viaje);
                viaje.CancelarViaje(usuario, cuenta);
            }
            else
            {
                throw new InvalidOperationException("El viaje no está en el itinerario.");
            }
        }

        public List<IViaje> ObtenerViajes()
        {
            return viajes;
        }
    }
}
