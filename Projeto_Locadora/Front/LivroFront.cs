using Projeto_Locadora.Entidade;
using Projeto_Locadora.Servicos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Locadora.Front
{
    public static class LivroFront
    {
        static LivroServico _livroServico;
        enum OpcaoMenu
        {

            CadastrarLivro = 1,
            BuscarLivroNome,
            BuscarTodos,
            AtualizarLivro,
            RemoverLivro,
            Sair
        }
        public static void ExecutarMenu()
        {
            _livroServico = new LivroServico(BuscarCaminhoBanco());



            bool executar = true;
            OpcaoMenu opcaoMenu = OpcaoMenu.CadastrarLivro;
            do
            {
                Console.Clear();
                Console.WriteLine("Qual ação você deseja realizar?");
                Console.WriteLine("1 para Cadastrar um Livro");
                Console.WriteLine("2 para Buscar um livro pelo nome");
                Console.WriteLine("3 Listar todos os livros");
                Console.WriteLine("4 para Atualizar um livro");
                Console.WriteLine("5 para remover um livro da lista");
                Console.WriteLine("6 Voltar ao inicio");



                Console.WriteLine();
                opcaoMenu = (OpcaoMenu)Convert.ToInt32(Console.ReadLine());


                switch (opcaoMenu)
                {
                    case OpcaoMenu.CadastrarLivro:
                        {
                            CadastrarLivro();
                            break;
                        }
                    case OpcaoMenu.BuscarLivroNome:
                        {
                            BuscarLivroNome();

                            break;
                        }
                    case OpcaoMenu.BuscarTodos:
                        {
                            BuscarTodosLivros();

                            break;
                        }

                    case OpcaoMenu.AtualizarLivro:
                        {
                            AtualizarLivro();
                            break;
                        }
                    case OpcaoMenu.RemoverLivro:
                        {
                            RemoverLivro();
                            break;
                        }
                    case OpcaoMenu.Sair:
                        {
                            executar = false;
                            break;
                        }
                    default:
                        Console.WriteLine("Opção inválida mané");
                        break;
                }

                //Console.WriteLine("Deseja executar outra operação?" +
                //    " sim para executar e enter para encerrar!");

                //executar = Console.ReadLine().ToLower() == "sim" ? true : false;
                Console.ReadLine();
                Console.Clear();

            } while (executar);


        }

        private static void BuscarTodosLivros()
        {

            List<Livro> livros = _livroServico.BuscarTodosLivros();

            if (livros != null && livros.Count > 0)
            {
                Console.WriteLine("\nLista de Livros Cadastrados:");
                foreach (var livro in livros)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine(livro.InformacoesLivro());
                }
            }
            else
            {
                Console.WriteLine("Nenhum livro cadastrado.");
            }
            
        }

        private static void CadastrarLivro()
        {
            Livro livro = new Livro();


            Console.WriteLine("Informe a Nome do Livro");
            livro.Nome = Console.ReadLine();

            Console.WriteLine("Informe a Nome do  Autor ");
            livro.Autor = Console.ReadLine();

            Console.WriteLine("Informe a Sinopse ");
            livro.Sinapse = Console.ReadLine();




            livro = _livroServico.Cadastrar(livro);

            Console.WriteLine("O Livro registrado é " + livro.InformacoesLivro());

        }
        public static void BuscarLivroNome()
        {
            Console.WriteLine("Informe o nome do livro:");
            string nome = Console.ReadLine();
            Livro livro = _livroServico.BuscarNome(nome);

            if (livro != null)
            {
                Console.WriteLine("\nLivro encontrado:");
                Console.WriteLine(livro.InformacoesLivro());
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
        private static void AtualizarLivro()
        {
            Console.WriteLine("Informe um Livro para atualizar as informações");
            string nome = Console.ReadLine();
            Livro livroExistente = _livroServico.BuscarNome(nome);

            if (livroExistente == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }
            Console.WriteLine("Informe o novo nome do livro:");
            livroExistente.Nome = Console.ReadLine();

            Console.WriteLine("Informe o novo nome do autor:");
            livroExistente.Autor = Console.ReadLine();

            Console.WriteLine("Informe a nova sinopse:");
            livroExistente.Sinapse = Console.ReadLine();

            Livro atualizado = _livroServico.Atualizar(livroExistente);

            Console.WriteLine("Livro atualizado com sucesso:");
            Console.WriteLine(atualizado);

        }
        private static void RemoverLivro()
        {
            Console.WriteLine("Informe um Livro para atualizar as informações");
            string nome = Console.ReadLine();
            Livro livro = _livroServico.BuscarNome(nome);
            if (livro != null)
            {
                _livroServico.Remover(livro);
                Console.WriteLine("Livro removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
        private static string BuscarCaminhoBanco()
        {
            string diretorioBancoDados = Path.Combine(Environment.CurrentDirectory, "BancoDeDados");

            Directory.CreateDirectory(diretorioBancoDados);

            string caminhoCompleto = Path.Combine(diretorioBancoDados, "bancoDadosLivro.json");

            if (!File.Exists(caminhoCompleto))
            {
                FileStream file = File.Create(caminhoCompleto);

                file.Dispose();
            }

            return caminhoCompleto;
        }
    }
}
