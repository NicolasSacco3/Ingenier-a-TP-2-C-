using Ingenieria;
using Moq;

namespace TestDescuento
{
    [TestClass]
    public class TestDescuento
    {
        private Descuento descuento;
        private Mock<IViaje> mockViaje;

        [TestInitialize]
        public void Setup()
        {
            descuento = new Descuento { Porcentaje = 20 };
            mockViaje = new Mock<IViaje>();
        }

        [TestMethod]
        public void AplicarDescuento_ReducirPrecioCorrectamente()
        {
            var precioOriginal = 100m;
            var precioConDescuento = descuento.AplicarDescuento(precioOriginal);
            Assert.AreEqual(80m, precioConDescuento);
        }
        [TestMethod]
        public void AplicarDescuento_UsandoViajeComoReferencia()
        {

            mockViaje.Setup(v => v.Precio).Returns(200m); 
            var precioOriginal = mockViaje.Object.Precio;

         
            var precioConDescuento = descuento.AplicarDescuento(precioOriginal);

           
            Assert.AreEqual(160m, precioConDescuento);
        }
        [TestMethod]
        public void ActualizarPorcentaje_CambiarPorcentajeDescuento()
        {
            descuento.ActualizarPorcentaje(30);
            Assert.AreEqual(30m, descuento.Porcentaje);
        }

        [TestMethod]
        public void ActualizarPorcentaje_LanzarExcepcionSiPorcentajeInvalido()
        {
            Assert.ThrowsException<ArgumentException>(() => descuento.ActualizarPorcentaje(-10));
            Assert.ThrowsException<ArgumentException>(() => descuento.ActualizarPorcentaje(110));
        }

        [TestMethod]
        public void EsDescuentoAplicable_RetornaTrueSiDescuentoMayorQueCero()
        {
            Assert.IsTrue(descuento.EsDescuentoAplicable());
        }

        [TestMethod]
        public void EsDescuentoAplicable_RetornaFalseSiDescuentoEsCero()
        {
            descuento.ActualizarPorcentaje(0);
            Assert.IsFalse(descuento.EsDescuentoAplicable());
        }

        [TestMethod]
        public void ObtenerValorDescuento_RetornaValorCorrectoDelDescuento()
        {
            var valorDescuento = descuento.ObtenerValorDescuento(100m);
            Assert.AreEqual(20m, valorDescuento);
        }

        [TestMethod]
        public void AplicarDescuentoConLimite_NoExcedeLimite()
        {
            var limite = 10m;
            var precioOriginal = 100m;
            var precioConDescuento = descuento.AplicarDescuentoConLimite(precioOriginal, limite);
            Assert.AreEqual(90m, precioConDescuento);
        }

        [TestMethod]
        public void AplicarDescuentoConLimite_ExcedeLimite()
        {
            var limite = 25m; 
            var precioOriginal = 100m;
            var precioConDescuento = descuento.AplicarDescuentoConLimite(precioOriginal, limite);
            Assert.AreEqual(75m, precioConDescuento);
        }
    }
}