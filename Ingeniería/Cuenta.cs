using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenieria
{
    public class Cuenta
    {
        public string Numero { get; set; }
        public decimal Saldo { get; set; }

        public void Depositar(decimal monto)
        {
            if (monto <= 0) throw new ArgumentException("El monto debe ser positivo.");
            Saldo += monto;
        }
        public decimal ConsultarSaldo()
        {
            return Saldo;
        }
        public void Retirar(decimal monto)
        {
            if (monto <= 0) throw new ArgumentException("El monto debe ser positivo.");
            if (monto > Saldo) throw new InvalidOperationException("Fondos insuficientes.");
            Saldo -= monto;
        }
        public void Transferir(Cuenta cuentaDestino, decimal monto)
        {
            Retirar(monto);
            cuentaDestino.Depositar(monto);
        }
        public void ReiniciarSaldo()
        {
            Saldo = 0;
        }
        public void CambiarNumero(string nuevoNumero)
        {
            if (string.IsNullOrWhiteSpace(nuevoNumero)) throw new ArgumentException("El número no puede ser vacío.");
            Numero = nuevoNumero;
        }
        public bool EsEstadoActivo()
        {
            return Saldo > 0;
        }

    }
}
