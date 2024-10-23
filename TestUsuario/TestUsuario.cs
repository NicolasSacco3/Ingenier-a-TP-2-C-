using Ingenieria;



namespace TestUsuario
{
    [TestClass]
    public class TestUsuario
    {


        Usuario usuario = new Usuario();
        [TestMethod]

        public void ValidarEmail_EmailValido_RetornaTrue()
        {

            var usuario = new Usuario
            {
                Nombre = "Ejemplo",
                Email = "ejemplo@dominio.com"
            };


            var resultado = usuario.ValidarEmail();


            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ValidarEmail_EmailInvalido_RetornaFalse()
        {

            var usuario = new Usuario
            {
                Nombre = "Ejemplo",
                Email = "ejemplodominio.com"
            };


            var resultado = usuario.ValidarEmail();


            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarEmail_EmailVacio_RetornaFalse()
        {

            var usuario = new Usuario
            {
                Nombre = "Ejemplo",
                Email = ""
            };


            var resultado = usuario.ValidarEmail();


            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarEmail_EmailNulo_RetornaFalse()
        {

            var usuario = new Usuario
            {
                Nombre = "Ejemplo",
                Email = ""
            };


            var resultado = usuario.ValidarEmail();


            Assert.IsFalse(resultado);

        }
    }
}