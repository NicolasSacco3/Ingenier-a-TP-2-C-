using Ingenieria;
namespace Test2

{
    [TestClass]
    public class TestUsuario
    {
      
       
        Usuario usuario = new Usuario();
        [TestMethod]

        public void ValidarEmail_EmailValido_RetornaTrue()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nombre = "Ejemplo",
                Email = "ejemplo@dominio.com"
            };

            // Act
            var resultado = usuario.ValidarEmail();

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ValidarEmail_EmailInvalido_RetornaFalse()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nombre = "Ejemplo",
                Email = "ejemplodominio.com"
            };

            // Act
            var resultado = usuario.ValidarEmail();

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarEmail_EmailVacio_RetornaFalse()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nombre = "Ejemplo",
                Email = ""
            };

            // Act
            var resultado = usuario.ValidarEmail();

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarEmail_EmailNulo_RetornaFalse()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nombre = "Ejemplo",
                Email = ""
            };

            // Act
            var resultado = usuario.ValidarEmail();

            // Assert
            Assert.IsFalse(resultado);
        }
    }
}
