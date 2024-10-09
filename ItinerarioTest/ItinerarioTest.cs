using Ingenieria;
using Ingeniería;

namespace ItinerarioTest
{
    [TestClass]
    public class ItinerarioTest
    {
        private Itinerario itinerario;
        private Usuario usuario;
        private Cuenta cuenta;

        [TestInitialize]
        public void Setup()
        {
            usuario = new Usuario { Nombre = "Juan", Cuenta = new Cuenta { Saldo = 300m } };
            itinerario = new Itinerario { usuario = usuario };
        }

        [TestMethod]
        public void AgregarViaje_AumentaCantidadDeViajes()
        {
            var viaje = new Viaje { Destino = "Paris", Precio = 200m };
            itinerario.AgregarViaje(viaje);
            Assert.AreEqual(1, itinerario.viajes.Count);
        }

        [TestMethod]
        public void CalcularCostoTotal_RetornaCostoTotalDeViajes()
        {
            itinerario.AgregarViaje(new Viaje { Destino = "Paris", Precio = 200m });
            itinerario.AgregarViaje(new Viaje { Destino = "Londres", Precio = 150m });
            var total = itinerario.CalcularCostoTotal();
            Assert.AreEqual(350m, total);
        }

        [TestMethod]
        public void CancelarViaje_EliminaViajeDelItinerario()
        {
            var viaje = new Viaje { Destino = "Paris", Precio = 200m };
            itinerario.AgregarViaje(viaje);
            itinerario.CancelarViaje(viaje);
            Assert.AreEqual(0, itinerario.viajes.Count);
        }

        [TestMethod]
        public void CancelarViaje_LanzaExcepcionSiViajeNoEstaEnItinerario()
        {
            var viaje = new Viaje { Destino = "Paris", Precio = 200m };
            Assert.ThrowsException<InvalidOperationException>(() => itinerario.CancelarViaje(viaje));
        }

        [TestMethod]
        public void ObtenerViajes_RetornaListaDeViajes()
        {
            var viaje1 = new Viaje { Destino = "Paris", Precio = 200m };
            var viaje2 = new Viaje { Destino = "Londres", Precio = 150m };
            itinerario.AgregarViaje(viaje1);
            itinerario.AgregarViaje(viaje2);
            var viajes = itinerario.ObtenerViajes();
            Assert.AreEqual(2, viajes.Count);
        }
    }
}