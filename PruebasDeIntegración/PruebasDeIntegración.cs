using Ingenieria;
using Ingeniería;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
namespace PruebasDeIntegración
{
    [TestClass]
    public class PruebasDeIntegración
    {
        private Usuario usuario;
        private Cuenta cuenta;
        private Mock<IViaje> viajeMock;
        private Itinerario itinerario;

        [TestInitialize]
        public void Setup()
        {
            cuenta = new Cuenta { Numero = "123456", Saldo = 500m };
            usuario = new Usuario { Nombre = "Nicolás", Email = "nicolas@example.com", Cuenta = cuenta }; // ejemplo 
            viajeMock = new Mock<IViaje>(); // instacia de herramiento moq 
            viajeMock.Setup(v => v.Precio).Returns(200m);
            viajeMock.SetupProperty(v => v.EstaCancelado, false);
            itinerario = new Itinerario { usuario = usuario };
        }

        [TestMethod]
        public void UsuarioPuedeAgregarViajeYVerCostoTotal()
        {
            itinerario.AgregarViaje(viajeMock.Object);
            Assert.AreEqual(200m, itinerario.CalcularCostoTotal());
        }

        [TestMethod]
        public void UsuarioPuedeRealizarViajeYSeDescuentaElSaldo()
        {
            itinerario.AgregarViaje(viajeMock.Object);
            viajeMock.Object.RealizarViaje(usuario, cuenta);
            Assert.AreEqual(500m, cuenta.Saldo); // se le pone 'm' es porque es decimal, profe
        }

        [TestMethod]
        public void UsuarioNoPuedeRealizarViajeSiFondosInsuficientes()
        {
            viajeMock.Setup(v => v.Precio).Returns(600m); 
            itinerario.AgregarViaje(viajeMock.Object);
            Assert.ThrowsException<InvalidOperationException>(() => viajeMock.Object.RealizarViaje(usuario, cuenta)); // uso expresión lambda
        }

        [TestMethod]
        public void UsuarioPuedeCancelarViajeYRecuperarSaldo()
        {
            itinerario.AgregarViaje(viajeMock.Object);
            viajeMock.Object.CancelarViaje(usuario, cuenta);
            Assert.AreEqual(500m, cuenta.Saldo); 
        }

        [TestMethod]
        public void ItinerarioPuedeContenerVariosViajes()
        {
            var viaje2Mock = new Mock<IViaje>();
            viaje2Mock.Setup(v => v.Precio).Returns(150m);
            itinerario.AgregarViaje(viajeMock.Object);
            itinerario.AgregarViaje(viaje2Mock.Object);
            Assert.AreEqual(2, itinerario.ObtenerViajes().Count);
        }

        [TestMethod]
        public void UsuarioPuedeVerificarSiElEmailEsValido()
        {
            Assert.IsTrue(usuario.ValidarEmail());
            usuario.Email = "nicolas@example.com";
            Assert.IsFalse(usuario.ValidarEmail());
        }

        [TestMethod]
        public void DescuentoSeAplicaCorrectamenteAlViaje()
        {
            var descuento = new Descuento { Porcentaje = 20 };
            var precioConDescuento = descuento.AplicarDescuento(viajeMock.Object.Precio);
            Assert.AreEqual(160m, precioConDescuento); 
        }

        [TestMethod]
        public void UsuarioNoPuedeCancelarViajeNoExistenteEnItinerario()
        {
            Assert.ThrowsException<InvalidOperationException>(() => itinerario.CancelarViaje(viajeMock.Object));
        }

        [TestMethod]
        public void CuentaNoPermiteRetirarFondosSiElMontoEsNegativo()
        {
            Assert.ThrowsException<ArgumentException>(() => cuenta.Retirar(-50m));
        }

        [TestMethod]
        public void CuentaSeDescuentaCorrectamenteAlDepositar()
        {
            cuenta.Depositar(100m);
            Assert.AreEqual(600m, cuenta.Saldo);
        }
    }
}