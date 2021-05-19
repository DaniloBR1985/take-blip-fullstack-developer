using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dio.Series
{
    class Program
    {

        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            bool opcaoValida = false;

            while ((opcaoUsuario.ToUpper() != "X" && opcaoUsuario.ToUpper() != "X") && !opcaoValida )
            {
                int opcaoUsuarioInt;
                if (!int.TryParse(opcaoUsuario, out opcaoUsuarioInt) || opcaoUsuarioInt < 1 || opcaoUsuarioInt > 10)
                {
                    Console.WriteLine("Digite uma opção válida.");
                    opcaoUsuario = ObterOpcaoUsuario();
                }                    
                else
                    opcaoValida = true;
            }

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        ListarFilmes();
                        break;
                    case "7":
                        InserirFilme();
                        break;
                    case "8":
                        AtualizarFilme();
                        break;
                    case "9":
                        ExcluirFilme();
                        break;
                    case "10":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

                opcaoValida = false;

                while ((opcaoUsuario.ToUpper() != "X" && opcaoUsuario.ToUpper() != "X") && !opcaoValida)
                {
                    int opcaoUsuarioInt;
                    if (!int.TryParse(opcaoUsuario, out opcaoUsuarioInt) || opcaoUsuarioInt < 1 || opcaoUsuarioInt > 10)
                    {
                        Console.WriteLine("Digite uma opção válida.");
                        opcaoUsuario = ObterOpcaoUsuario();
                    }
                    else
                        opcaoValida = true;
                }

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorioSerie.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            Serie novaSerie = PreencherSerie(repositorioSerie.ProximoId());

            repositorioSerie.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Serie atualizaSerie = PreencherSerie(indiceSerie);

            repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
        }

        private static Serie PreencherSerie(int id)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero;
            while (!int.TryParse(Console.ReadLine(), out entradaGenero) || entradaGenero < 1 || entradaGenero > 13)
            {
                Console.Write("Digite o genêro entre as opções acima: ");
            }
            
            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno;
            while (!int.TryParse(Console.ReadLine(), out entradaAno))
            {
                Console.Write("Digite o Ano de Início da Série: ");
            }

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(id: id,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            return serie;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorioSerie.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void ExcluirFilme()
        {
            Console.Write("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorioFilme.Exclui(indiceFilme);
        }

        private static void VisualizarFilme()
        {
            Console.Write("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            Filme novoFilme = PreencherFilme(repositorioFilme.ProximoId());

            repositorioFilme.Insere(novoFilme);
        }

        private static void AtualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            Filme atualizaFilme = PreencherFilme(indiceFilme);

            repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
        }

        private static Filme PreencherFilme(int id)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero;
            while (!int.TryParse(Console.ReadLine(), out entradaGenero) || entradaGenero < 1 || entradaGenero > 13)
            {
                Console.Write("Digite o genêro entre as opções acima: ");
            }

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do Filme: ");
            int entradaAno;
            while (!int.TryParse(Console.ReadLine(), out entradaAno))
            {
                Console.Write("Digite o Ano do Filme: ");
            }

            Console.Write("Digite a Descrição do FIlme: ");
            string entradaDescricao = Console.ReadLine();

            Filme filme = new Filme(id: id,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            return filme;
        }

        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes");

            var lista = repositorioFilme.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Listar filmes");
            Console.WriteLine("7 - Inserir novo filme");
            Console.WriteLine("8 - Atualizar filme");
            Console.WriteLine("9 - Excluir filme");
            Console.WriteLine("10 - Visualizar filme");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
