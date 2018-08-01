using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using TesteBackEndViaVarejo.Entidades;
using TesteBackEndViaVarejo.Negocio;

namespace TesteBackEndViaVarejo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Amigo> amigoLista = new List<Amigo>();
            amigoLista = InicializarListaAmigos();

            //Carregando menu principal
            CarregarMenuOpcoes();

            //Guarda o valor digitado pelo usuario
            Menu menu = ((Menu)Enum.Parse(typeof(Menu), Console.ReadLine().ToString(), true));

            //Realiza ação de acorodo com a opção escolhida pelo usuario
            VerificarMenuEscolhido(amigoLista, menu);
        }

        #region Metodos privados

        private static List<Amigo> InicializarListaAmigos()
        {
            var amigosLista = new List<Amigo>{
                new Amigo(1,"Thiago Raszl Hidalgo", new Localizacao(-110, -80)),
                new Amigo(2,"Priscila Goes Ariodante", new Localizacao(6, 10)),
                new Amigo(3,"Antonio Marques", new Localizacao(-43, -51)),
                new Amigo(4,"Tatila Marques", new Localizacao(15, 50)),
                new Amigo(5,"Ricardo Silva", new Localizacao(35, 40)),
            };
            return amigosLista;
        }

        private static void MostrarListaDeAmigos(List<Amigo> amigoLista, string titulo)
        {
            Console.WriteLine("Lista de amigos " + titulo + ":");

            foreach (var amigo in amigoLista)
            {
                Console.WriteLine(string.Format("Nome: {0} - Localização: Latitude = {1} - Longitude = {2}",
                    amigo.Nome,
                    amigo.localizacao.Latitude,
                    amigo.localizacao.Longitude
                ));
            }
            Console.WriteLine(" ");
        }
        //Método para retornar descrição do enum
        public static string GetEnumDescription(Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());

                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

                if (attributes != null &&
                    attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        //Método que monta menu para o usuario
        private static void VerificarMenuEscolhido(List<Amigo> amigoLista, Menu menuOpcoes)
        {
            bool continua = true;
            switch (menuOpcoes)
            {
                case Menu.VizualizarAmigosProximos:
                    Console.Clear();
                    while (continua)
                    {
                        try
                        {
                            MostrarListaDeAmigos(amigoLista, "Cadastrados");

                            string nomeAmigoVisitado;
                            string confirmacao;
                            RecuperaValorDigitadoPeloUsuario(out nomeAmigoVisitado, out confirmacao);

                            while (confirmacao.Trim().ToUpper() != "S")
                            {
                                RecuperaValorDigitadoPeloUsuario(out nomeAmigoVisitado, out confirmacao);
                            }

                            var amigoNegocio = new MeusAmigos(amigoLista);
                            amigoNegocio.VisitaAmigo(nomeAmigoVisitado);

                            var listaAmigosProximos = amigoNegocio.ListarAmigosMaisProximos();
                            MostrarListaDeAmigos(listaAmigosProximos, "Amigos Proximos");

                            continua = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    MostrarMenu(amigoLista);
                    break;
                case Menu.InserirAmigo:
                    Console.Clear();
                    while (continua)
                    {
                        try
                        {
                            Console.WriteLine("Digite o nome do amigo");
                            string _nome = Console.ReadLine();
                            Console.WriteLine("----------------");
                            Console.WriteLine("Digite Latitude");
                            int _latitude = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("----------------");
                            Console.WriteLine("Digite Longitude");
                            int _longitude = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("----------------");

                            var amigoNegocio = new MeusAmigos(amigoLista);
                            var amigoInserir = new Amigo(amigoLista.Count() + 1, _nome, new Localizacao(_latitude, _longitude));
                            amigoLista = amigoNegocio.InserirAmigo(amigoInserir);
                            continua = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    MostrarMenu(amigoLista);
                    break;
                case Menu.Fechar:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opção inválida no Menu");
                    Console.WriteLine("----------------");
                   
                    break;
            }
        }
        //Carregar MenuPrincipal
        private static void MostrarMenu(List<Amigo> amigoLista)
        {
            //Carregando menu principal
            CarregarMenuOpcoes();

            //Guarda o valor digitado pelo usuario
            Menu menu = ((Menu)Enum.Parse(typeof(Menu), Console.ReadLine().ToString(), true));

            //Realiza ação de acorodo com a opção escolhida pelo usuario
            VerificarMenuEscolhido(amigoLista, menu);
        }

        private static void CarregarMenuOpcoes()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Escolha a operação a ser realizada\n");

            foreach (Menu item in Enum.GetValues(typeof(Menu)))
            {
                Console.WriteLine(GetEnumDescription(item));
            }
        }

        private static void RecuperaValorDigitadoPeloUsuario(out string nomeAmigoVisitado, out string confirmacao)
        {
            Console.WriteLine("Entre com o nome do amigo que você deseja visitar.");
            nomeAmigoVisitado = Console.ReadLine();
            Console.WriteLine(" ");

            Console.WriteLine(string.Format("Você digitou o nome: {0}. Está correto? \n Digite 's' para sim ou 'n' para não",
                nomeAmigoVisitado));
            confirmacao = Console.ReadLine();
            Console.WriteLine(" ");
        }
        #endregion

        #region Enums

        public enum Menu
        {
            [Description("1 - Vizualizar amigos Proximos")]
            VizualizarAmigosProximos = 1,
            [Description("2 - Inserir Amigo")]
            InserirAmigo = 2,
            [Description("3 - Fechar aplicação")]
            Fechar = 3,
        }
        #endregion
    }
}
