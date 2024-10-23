using Ingenieria;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestUsuario
{
    [TestClass]
    public class TestUsuario
    {
        [TestMethod]
        public void ValidarEmail_EmailValido_RetornaTrue()
        {
     
            var usuarioMock = new Mock<IUsuario>();
            usuarioMock.Setup(u => u.Email).Returns("ejemplo@sacco.com");

            var resultado = usuarioMock.Object.ValidarEmail();

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ValidarEmail_EmailInvalido_RetornaFalse()
        {
        
            var usuarioMock = new Mock<IUsuario>();
            usuarioMock.Setup(u => u.Email).Returns("ejemplosacco.com");

            var resultado = usuarioMock.Object.ValidarEmail();

           
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarEmail_EmailVacio_RetornaFalse()
        {
  
            var usuarioMock = new Mock<IUsuario>();
            usuarioMock.Setup(u => u.Email).Returns(string.Empty);

     
            var resultado = usuarioMock.Object.ValidarEmail();

         
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarEmail_EmailNulo_RetornaFalse()
        {
 
            var usuarioMock = new Mock<IUsuario>();
            usuarioMock.Setup(u => u.Email).Returns((string)null);

     
            var resultado = usuarioMock.Object.ValidarEmail();


            Assert.IsFalse(resultado);
        }
    }
}