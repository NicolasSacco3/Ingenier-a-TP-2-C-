using Ingenieria;
using Moq;

namespace Test_Viajes
{
    [TestClass]
    public class TestViajes
    {
        private Viaje viaje;
  

        [TestInitialize]
        public void Setup()
        {
            viaje = new Viaje { Destino = "Paris", Precio = 200m }; 
        
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
         
            var mockOtroViaje = new Mock<Viaje>();
            mockOtroViaje.Setup(v => v.Precio).Returns(150m); 

    
            var resultado = viaje.CompararPrecio(mockOtroViaje.Object);

    
            Assert.IsTrue(resultado > 0); 
        }
    }
}