using System.Collections.Generic;
using TesteBackEndViaVarejo.Entidades;

namespace TesteBackEndViaVarejo.Teste
{
    public static class UtilitariosTestes
    {
        public static List<Amigo> PreparandoAmigosLista()
        {
            var amigoA = new Amigo(1,"amigo A", new Localizacao(1, 3));
            var amigoZ = new Amigo(2,"amigo Z", new Localizacao(5, 6));
            var amigoY = new Amigo(3,"amigo Y", new Localizacao(10, 9));
            var amigoW = new Amigo(4,"amigo W", new Localizacao(15, 12));
            var amigoK = new Amigo(5,"amigo K", new Localizacao(20, 15));

            var amigosList = new List<Amigo> { amigoA, amigoZ, amigoY, amigoW, amigoK };
            return amigosList;
        }

        public static List<Amigo> PraparantoListaAmigos_B()
        {
            var amigoA = new Amigo(1,"amigo A", new Localizacao(10, 5));
            var amigoZ = new Amigo(2,"amigo Z", new Localizacao(35, 20));
            var amigoY = new Amigo(3,"amigo Y", new Localizacao(40, 30));
            var amigoW = new Amigo(4,"amigo W", new Localizacao(50, 18));
            var amigoK = new Amigo(5,"amigo K", new Localizacao(30, 36));

            var amigosList = new List<Amigo> { amigoA, amigoZ, amigoY, amigoW, amigoK };

            return amigosList;
        }

        public static List<Amigo> PreparandoAmigosLista_C()
        {
            var amigoY = new Amigo(1,"amigo Y", new Localizacao(10, 9));
            var amigoZ = new Amigo(2,"amigo Z", new Localizacao(5, 6));
            var amigoW = new Amigo(3,"amigo W", new Localizacao(15, 12));
            var amigoA = new Amigo(4,"amigo A", new Localizacao(1, 3));
            var amigoK = new Amigo(5,"amigo K", new Localizacao(20, 15));

            var amigosList = new List<Amigo> { amigoY, amigoZ, amigoW, amigoA, amigoK };

            return amigosList;
        }

        public static List<Amigo> PreparandoAmigosLista_LocalizacoesNegativas()
        {
            var amigoA = new Amigo(1,"amigo A", new Localizacao(-10, -15));
            var amigoZ = new Amigo(2,"amigo Z", new Localizacao(-30, -20));
            var amigoY = new Amigo(3,"amigo Y", new Localizacao(-20, -30));
            var amigoW = new Amigo(4,"amigo W", new Localizacao(-35, -42));
            var amigoK = new Amigo(5,"amigo K", new Localizacao(-25, -55));

            var amigosList = new List<Amigo> { amigoA, amigoZ, amigoY, amigoW, amigoK };

            return amigosList;
        }
    }
}
