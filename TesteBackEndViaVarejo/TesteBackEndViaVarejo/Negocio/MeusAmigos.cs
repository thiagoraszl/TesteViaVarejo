using System;
using System.Collections.Generic;
using System.Linq;
using TesteBackEndViaVarejo.Entidades;

namespace TesteBackEndViaVarejo.Negocio
{
    public class MeusAmigos
    {
        private List<Amigo> _listaAmigos;
        private Amigo _amigoVisitado;

        public MeusAmigos(List<Amigo> listaAmigos)
        {
            _listaAmigos = listaAmigos;
        }

        public Amigo VisitaAmigo(string nomeAmigo)
        {
            _amigoVisitado = _listaAmigos.FirstOrDefault(x => x.Nome == nomeAmigo);

            if (_amigoVisitado == null)
                throw new Exception(string.Format("Amigo {0} não encontrado na sua lista de amigos.", nomeAmigo));

            return _amigoVisitado;
        }


        public List<Amigo> InserirAmigo(Amigo amigoInserir)
        {
            if (_listaAmigos.Any(x => x.localizacao.Latitude == amigoInserir.localizacao.Latitude && x.localizacao.Longitude == amigoInserir.localizacao.Longitude))
                throw new Exception("Erro: Latidute e Longitude já cadastrada para outro amigo.");

            //Adiconando novo amigo na lista
            _listaAmigos.Add(amigoInserir);

            return _listaAmigos;
        }

        public List<Amigo> ListarAmigosMaisProximos()
        {
            if (_amigoVisitado == null)
                throw new Exception("Informe o amigo que esta visitando.");

            Localizacao minhaLocalizacaoAtual = _amigoVisitado.localizacao;
            var distanciaEntreVistaEamigos = CalculaDistanciaEntreAmigos(minhaLocalizacaoAtual)
                                                .OrderBy(_ => _.Value)
                                                .Take(3);

            return distanciaEntreVistaEamigos.Select(item => _listaAmigos.ElementAt(item.Key)).ToList();
        }


        #region Private Methods

        private Dictionary<int, double> CalculaDistanciaEntreAmigos(Localizacao minhaLocalizacaoAtual)
        {
            var distanceBetweenMyAmigoAndMe = new Dictionary<int, double>();

            foreach (var amigo in _listaAmigos)
            {
                if (amigo == _amigoVisitado)
                    continue;

                var amigoLocalizacao = amigo.localizacao;

                var valorX = Math.Pow((minhaLocalizacaoAtual.Latitude - minhaLocalizacaoAtual.Latitude), 2);
                var valorY = Math.Pow((minhaLocalizacaoAtual.Longitude - minhaLocalizacaoAtual.Longitude), 2);
                var valorFinal = Math.Sqrt(valorX + valorY);

                distanceBetweenMyAmigoAndMe.Add(amigo.Id, valorFinal);
            }
            return distanceBetweenMyAmigoAndMe;
        }

        #endregion
    }
}
