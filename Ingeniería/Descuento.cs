using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenieria
{
    public class Descuento
    {
        public decimal Porcentaje { get; set; }

        public decimal AplicarDescuento(decimal precio)
        {
            return precio - (precio * (Porcentaje / 100));
        }
        public bool EsDescuentoAplicable()
        {
            return Porcentaje > 0;
        }
        public decimal ObtenerValorDescuento(decimal precio)
        {
            return precio * (Porcentaje / 100);
        }
        public void ActualizarPorcentaje(decimal nuevoPorcentaje)
        {
            if (nuevoPorcentaje < 0 || nuevoPorcentaje > 100)
                throw new ArgumentException("El porcentaje debe estar entre 0 y 100.");
            Porcentaje = nuevoPorcentaje;
        }
        public static decimal DescuentoMaximo => 50; 

        public decimal AplicarDescuentoConLimite(decimal precio, decimal limite)
        {
            var descuento = ObtenerValorDescuento(precio);
            return precio - Math.Min(descuento, limite);
        }
    }
}
