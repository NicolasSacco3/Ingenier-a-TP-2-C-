using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenieria
{
    public interface IViaje
    {
        decimal Precio { get; set; }
        bool EstaCancelado { get; set; }
        void RealizarViaje(Usuario usuario, Cuenta cuenta);
        void CancelarViaje(Usuario usuario, Cuenta cuenta);
    }
    public class Viaje : IViaje
    {
        public string Destino { get; set; }
        public virtual decimal Precio { get; set; } // Hacer la propiedad virtual
        public bool EstaCancelado { get; set; } = false;

        public void RealizarViaje(Usuario usuario, Cuenta cuenta)
        {
            cuenta.Retirar(Precio);
        }
        public void CancelarViaje(Usuario usuario, Cuenta cuenta)
        {
            if (EstaCancelado)
            {
                throw new InvalidOperationException("El viaje ya ha sido cancelado.");
            }

            // Lógica para manejar la cancelación
            EstaCancelado = true;
            // Por ejemplo, podrías reembolsar el precio al saldo de la cuenta del usuario
            cuenta.Saldo += Precio; // Asumiendo que Cuenta tiene una propiedad Saldo
        
        }
        public void ActualizarPrecio(decimal nuevoPrecio)
        {
            if (nuevoPrecio <= 0) throw new ArgumentException("El precio debe ser positivo.");
            Precio = nuevoPrecio;
        }
        public string ObtenerDetalles()
        {
            return $"Destino: {Destino}, Precio: {Precio}";
        }
        public bool EsViajeCostoso(decimal umbral)
        {
            return Precio > umbral;
        }
        public int CompararPrecio(Viaje otroViaje)
        {
            return Precio.CompareTo(otroViaje.Precio);
        }

    
    }
}
