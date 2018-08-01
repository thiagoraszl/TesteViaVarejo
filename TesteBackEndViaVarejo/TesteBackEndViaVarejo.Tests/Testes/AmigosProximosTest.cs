using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteBackEndViaVarejo.Entidades;
using TesteBackEndViaVarejo.Teste;
using TesteBackEndViaVarejo.Negocio;

namespace NearbyAmigos.Test.Tests
{
    [TestClass]
    public class AmigosProximosTest
    {
        [TestMethod]
        public void TesteAmigosProximos()
        {
            //arrange
            const string nomeAmigoVisitado = "Amigo Beta";
            var amigosList = UtilitariosTestes.PraparantoListaAmigos_B();
            amigosList.Add(new Amigo(amigosList.Count + 1, nomeAmigoVisitado, new Localizacao(-1, -20)));
            var amigoNegocio = new MeusAmigos(amigosList);

            //act            
            amigoNegocio.VisitaAmigo(nomeAmigoVisitado);

            var AmigosNear = amigoNegocio.ListarAmigosMaisProximos();

            //assert
            Assert.AreEqual("Amigo A", AmigosNear[0].Nome);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TesteAmigosProximos_2()
        {
            //arrange
            string nomeAmigoVisitado = "Amigo Sigma";
            var amigosList = UtilitariosTestes.PraparantoListaAmigos_B();
            var amigoNegocio = new MeusAmigos(amigosList);

            //act            
            amigoNegocio.VisitaAmigo(nomeAmigoVisitado);

        }

        [TestMethod]
        public void TesteAmigosProximos_3()
        {
            //arrange
            string nomeAmigoVisitado = "Amigo Beta";
            var amigosList = UtilitariosTestes.PraparantoListaAmigos_B();
            amigosList.Add(new Amigo(amigosList.Count + 1,nomeAmigoVisitado, new Localizacao(25, 18)));

            //act
            var amigoNegocio = new MeusAmigos(amigosList);
            amigoNegocio.VisitaAmigo(nomeAmigoVisitado);

            var AmigoNear = amigoNegocio.ListarAmigosMaisProximos()[0];

            //assert
            Assert.AreEqual("Amigo Z", AmigoNear.Nome);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TesteAmigosProximos_4()
        {
            //arrange
            var amigosList = UtilitariosTestes.PreparandoAmigosLista_C();
            var amigoNegocio = new MeusAmigos(amigosList);

            //act
            var amigoProximo = amigoNegocio.ListarAmigosMaisProximos()[0];

            //assert
            Assert.AreEqual("Amigo K", amigoProximo.Nome);
        }
    }
}
