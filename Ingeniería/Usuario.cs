using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenieria
{
    public class Usuario : IUsuario
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Cuenta Cuenta { get; set; }

        public bool ValidarEmail()
        {
            return Email.Contains("@");
        }
        public void CancelarViaje(Viaje viaje)
        {

            if (viaje.EstaCancelado)
            {
                throw new InvalidOperationException("El viaje ya ha sido cancelado.");
            }


            viaje.CancelarViaje(this, Cuenta);

        }
    }
}
