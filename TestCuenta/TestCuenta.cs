using Ingenieria;
using Moq;

namespace TestCuenta
{
    [TestClass]
    public class TestCuenta
    {
        private Cuenta cuenta;

        [TestInitialize]
        public void Setup()
        {
            cuenta = new Cuenta { Numero = "123456", Saldo = 100m };
        }

        [TestMethod]
        public void Depositar_IncrementaSaldo()
        {
            cuenta.Depositar(50);
            Assert.AreEqual(150m, cuenta.Saldo);
        }

        [TestMethod]
        public void Retirar_DisminuyeSaldo()
        {
            cuenta.Retirar(50);
            Assert.AreEqual(50m, cuenta.Saldo);
        }

        [TestMethod]
        public void ConsultarSaldo_RetornaSaldoActual()
        {
            var saldo = cuenta.ConsultarSaldo();
            Assert.AreEqual(100m, saldo);
        }

        [TestMethod]
        public void Transferir_TransfiereMontoACuentaDestino()
        {
            
            var mockCuentaDestino = new Mock<Cuenta>();
            mockCuentaDestino.Setup(c => c.Saldo).Returns(50m); 

           
            cuenta.Transferir(mockCuentaDestino.Object, 50);

          
            Assert.AreEqual(50m, cuenta.Saldo);
            mockCuentaDestino.Verify(c => c.Depositar(50), Times.Once);
        }

        [TestMethod]
        public void ReiniciarSaldo_EstableceSaldoACero()
        {
            cuenta.ReiniciarSaldo();
            Assert.AreEqual(0m, cuenta.Saldo);
        }

        [TestMethod]
        public void CambiarNumero_CambiaNumeroDeCuenta()
        {
            cuenta.CambiarNumero("654321");
            Assert.AreEqual("654321", cuenta.Numero);
        }

        [TestMethod]
        public void EsEstadoActivo_RetornaTrueSiSaldoEsMayorQueCero()
        {
            Assert.IsTrue(cuenta.EsEstadoActivo());
        }

        [TestMethod]
        public void EsEstadoActivo_RetornaFalseSiSaldoEsCero()
        {
            cuenta.ReiniciarSaldo();
            Assert.IsFalse(cuenta.EsEstadoActivo());
        }
        public void Transferir_LanzaExcepcionSiFondosInsuficientes()
        {
          
            var mockCuentaDestino = new Mock<Cuenta>();
            mockCuentaDestino.Setup(c => c.Saldo).Returns(50m);
            Assert.ThrowsException<InvalidOperationException>(() => cuenta.Transferir(mockCuentaDestino.Object, 150));
        }

    }
}