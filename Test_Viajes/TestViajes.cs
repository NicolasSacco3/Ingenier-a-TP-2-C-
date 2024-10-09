using Ingenieria;

namespace Test_Viajes
{
    [TestClass]
    public class TestViajes
    {
        private Viaje viaje;
  

        [TestInitialize]
        public void Setup()
        {
            viaje = new Viaje { Destino = "Paris", Precio = 200m }; // Cargo datos por default para p
        
        }


        [TestMethod]
        public void ActualizarPrecio_CambiaPrecioDelViaje()
        {
            viaje.ActualizarPrecio(250m);
            Assert.AreEqual(250m, viaje.Precio);
        }

        [TestMethod]
        public void ObtenerDetalles_RetornaDetallesDelViaje()
        {
            var detalles = viaje.ObtenerDetalles();
            Assert.AreEqual("Destino: Paris, Precio: 200", detalles);
        }

        [TestMethod]
        public void EsViajeCostoso_RetornaTrueSiPrecioEsMayorQueUmbral()
        {
            Assert.IsTrue(viaje.EsViajeCostoso(150m));
        }

        [TestMethod]
        public void EsViajeCostoso_RetornaFalseSiPrecioEsMenorOIgualQueUmbral()
        {
            Assert.IsFalse(viaje.EsViajeCostoso(200m));
        }

        [TestMethod]
        public void CompararPrecio_RetornaResultadoCorrecto()
        {
            var otroViaje = new Viaje { Destino = "Londres", Precio = 150m };
            var resultado = viaje.CompararPrecio(otroViaje);
            Assert.IsTrue(resultado > 0); // este assert devuelve el Viaje es más caro
        }
    }
}