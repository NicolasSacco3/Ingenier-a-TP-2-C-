using Ingenieria;
using Ingeniería;

namespace PruebasDeIntegración
{
    [TestClass]
    public class PruebasDeIntegración
    {
        private Usuario usuario;
        private Cuenta cuenta;
        private Itinerario itinerario;
        private Viaje viaje;

        [TestInitialize]
        public void Setup()
        {
            cuenta = new Cuenta { Numero = "123456", Saldo = 500m };
            usuario = new Usuario { Nombre = "Nicolás", Email = "nicolas@example.com", Cuenta = cuenta };
            viaje = new Viaje { Destino = "París", Precio = 200m };
            itinerario = new Itinerario { usuario = usuario };
        }

        [TestMethod]
        public void UsuarioPuedeAgregarViajeYVerCostoTotal()
        {
            itinerario.AgregarViaje(viaje);
            Assert.AreEqual(200m, itinerario.CalcularCostoTotal());
        }

        [TestMethod]
        public void UsuarioPuedeRealizarViajeYSeDescuentaElSaldo()
        {
            itinerario.AgregarViaje(viaje);
            viaje.RealizarViaje(usuario, cuenta);
            Assert.AreEqual(300m, cuenta.Saldo);
        }

        [TestMethod]
        public void UsuarioNoPuedeRealizarViajeSiFondosInsuficientes()
        {
            viaje.Precio = 600m; 
            itinerario.AgregarViaje(viaje);
            Assert.ThrowsException<InvalidOperationException>(() => viaje.RealizarViaje(usuario, cuenta));
        }

        [TestMethod]
        public void UsuarioPuedeCancelarViajeYRecuperarSaldo()
        {
            itinerario.AgregarViaje(viaje);
            viaje.RealizarViaje(usuario, cuenta);
            viaje.CancelarViaje(usuario, cuenta);
            Assert.AreEqual(500m, cuenta.Saldo);
        }

        [TestMethod]
        public void ItinerarioPuedeContenerVariosViajes()
        {
            var viaje2 = new Viaje { Destino = "Londres", Precio = 150m };
            itinerario.AgregarViaje(viaje);
            itinerario.AgregarViaje(viaje2);
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
            var precioConDescuento = descuento.AplicarDescuento(viaje.Precio);
            Assert.AreEqual(160m, precioConDescuento);
        }

        [TestMethod]
        public void UsuarioNoPuedeCancelarViajeNoExistenteEnItinerario()
        {
            var viajeInexistente = new Viaje { Destino = "Madrid", Precio = 100m };
            Assert.ThrowsException<InvalidOperationException>(() => itinerario.CancelarViaje(viajeInexistente));
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
        [TestMethod]
        public void UsuarioPuedeRealizarVariosViajesYSaldoSeActualizaCorrectamente()
        {

            var viaje1 = new Viaje { Destino = "Madrid", Precio = 200m };
            var viaje2 = new Viaje { Destino = "Londres", Precio = 150m };
            itinerario.AgregarViaje(viaje1);
            itinerario.AgregarViaje(viaje2);


            viaje1.RealizarViaje(usuario, cuenta);
            viaje2.RealizarViaje(usuario, cuenta);


            Assert.AreEqual(150m, cuenta.Saldo);
        }
        [TestMethod]
        public void UsuarioPuedeRealizarViajeYDescuentoSeAplicaCorrectamente()
        {
            // Arrange
            var viaje = new Viaje { Destino = "Cancún", Precio = 400m };
            var descuento = new Descuento { Porcentaje = 20 }; // 
            itinerario.AgregarViaje(viaje);
            var precioConDescuento = descuento.AplicarDescuento(viaje.Precio);


            viaje.RealizarViaje(usuario, cuenta);


            Assert.AreEqual(180m, cuenta.Saldo);
        }
        [TestMethod]
        public void UsuarioPuedeCancelarViajeYRecuperarSaldoConDescuento()
        {

            var viaje = new Viaje { Destino = "Colómbia", Precio = 500m };
            var descuento = new Descuento { Porcentaje = 10 };
            itinerario.AgregarViaje(viaje);
            var precioConDescuento = descuento.AplicarDescuento(viaje.Precio);
            viaje.RealizarViaje(usuario, cuenta);


            viaje.CancelarViaje(usuario, cuenta);

 
            Assert.AreEqual(500m, cuenta.Saldo);

        }
    }
}