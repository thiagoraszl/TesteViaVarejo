using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteBackEndViaVarejo.Entidades;
using TesteBackEndViaVarejo.Negocio;

namespace TesteBackEndViaVarejo.Teste.Testes
{
    [TestClass]
    public class AmigoTest
    {
        [TestMethod]
        public void GivenIWantIdentifySomeAmigos_WhenIInstantiateAAmigoA_ThenIShouldBeAbleToInputHisNome()
        {
            var localicacao = new Localizacao(0, 0);
            var amigoA = new Amigo(localicacao);
            var amigoNomeA = "Amigo A";

            amigoA.Nome = amigoNomeA;

            Assert.AreEqual(amigoNomeA, amigoA.Nome);
        }

        [TestMethod]
        public void GivenIWantIdentifySomeAmigos_WhenIHaveAAmigosList_ThenIShouldBeAbleToIdentifyTheAmigoZ()
        {
            //arrange
            var amigoNomeZ = "AmigoZ";
            var amigoZ = new Amigo(10, amigoNomeZ, new Localizacao(0, 0));

            var amigosList = UtilitariosTestes.PreparandoAmigosLista();
            amigosList.Add(amigoZ);

            //act
            amigoZ.Nome = amigoNomeZ;

            //assert
            Assert.IsTrue(amigosList.Count > 1);
            Assert.IsTrue(amigosList.Exists(x => x.Nome == amigoNomeZ));
        }

        [TestMethod]
        public void TesteDeVisitaAmigo()
        {
            //arrange
            var nomeAmigoVisitado = "Amigo Beta";
            var amigosList = UtilitariosTestes.PreparandoAmigosLista();
            amigosList.Add(new Amigo(amigosList.Count + 1, nomeAmigoVisitado, new Localizacao(25, 18)));

            //act
            var visitingAmigo = new MeusAmigos(amigosList).VisitaAmigo(nomeAmigoVisitado);

            //assert
            var expected = amigosList.Find(_ => _.Nome == nomeAmigoVisitado);
            var expectedNome = expected.Nome;

            Assert.IsTrue(expectedNome == visitingAmigo.Nome);
        }


    }
}
