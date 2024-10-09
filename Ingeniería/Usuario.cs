using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenieria
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Cuenta Cuenta { get; set; } // Agregamos la propiedad Cuenta

        public bool ValidarEmail()
        {
            return Email.Contains("@");
        }
        public void CancelarViaje(Viaje viaje)
        {
            // Verificar que el viaje no esté cancelado
            if (viaje.EstaCancelado)
            {
                throw new InvalidOperationException("El viaje ya ha sido cancelado.");
            }

            // Cancelar el viaje
            viaje.CancelarViaje(this, Cuenta);
            // Aquí podrías agregar más lógica, como notificar al usuario sobre la cancelación
        }
    }
}
