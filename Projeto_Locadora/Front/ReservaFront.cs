using Projeto_Locadora.Entidade;
using Projeto_Locadora.Servicos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto_Locadora.Front
{

    public static class ReservaFront
    {
        static ReservaServico _reservaServico;
        enum OpcaoMenu
        {

            CadastrarReserva = 1,
            BuscarNome,            
            BuscarTodos,
            BuscarCpf,
            AtualizarReserva,
            RemoverReserva,
            Sair
        }
        public static void ExecutarMenuReserva()
        {
            _reservaServico = new ReservaServico(BuscarCaminhoBanco());



            bool executar = true;
            OpcaoMenu opcaoMenu = OpcaoMenu.CadastrarReserva;
            do
            {
                Console.Clear();
                Console.WriteLine("Qual ação você deseja realizar?");
                Console.WriteLine("1 para Cadastrar uma Reserva");
                Console.WriteLine("2 para Buscar uma reserva pelo nome");
                Console.WriteLine("3 Listar todas as reservas");
                Console.WriteLine("4 para Buscar uma reserva pelo Cpf");
                Console.WriteLine("5 para Atualizar uma reserva");
                Console.WriteLine("6 para remover um reserva da lista");
                Console.WriteLine("7 Voltar ao inicio");



                Console.WriteLine();
                opcaoMenu = (OpcaoMenu)Convert.ToInt32(Console.ReadLine());


                switch (opcaoMenu)
                {
                    case OpcaoMenu.CadastrarReserva:
                        {
                            CadastrarReserva();
                            break;
                        }
                    case OpcaoMenu.BuscarNome:
                        {
                            BuscarNome();

                            break;
                        }
                    case OpcaoMenu.BuscarTodos:
                        {
                            BuscarTodos();

                            break;
                        }
                    case OpcaoMenu.BuscarCpf:
                        {
                            BuscarCpf();

                            break;
                        }

                    case OpcaoMenu.AtualizarReserva:
                        {
                            Atualizar();
                            break;
                        }
                    case OpcaoMenu.RemoverReserva:
                        {
                            Remover();
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

        private static void BuscarTodos()
        {

            List<Reserva> reservas = _reservaServico.BuscarTodos();

            if (reservas != null && reservas.Count > 0)
            {
                Console.WriteLine("\nLista de Reservas Cadastradas:");
                foreach (var reserva in reservas)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine(reserva.InformacoesReserva());
                }
            }
            else
            {
                Console.WriteLine("Nenhuma reservas cadastrado.");
            }
            //Nao esta mostrando na tela as reserva ja cadastradas Nem nos Livros
        }

        private static void CadastrarReserva()
        {
            Reserva reserva = new Reserva();
            Console.WriteLine("Digite Sim ou Nao para realizar um aluguel");
            string resposta = Console.ReadLine().ToLower();
            if (resposta == "sim")
            {

                Console.WriteLine("Informe o Nome da Reserva");
                reserva.NomeCompleto = Console.ReadLine();




                Console.WriteLine("Informe o Cpf da  Reserva ");
                reserva.Cpf = Console.ReadLine();
                string cpf = Console.ReadLine();
                

                reserva.DataReserva = DateTime.Now;

                Console.WriteLine("Informe quantos dias vai ficar com a Reserva estimada ");
                int dias = int.Parse(Console.ReadLine());
                reserva.DataEstimada = DateTime.Now.AddDays(dias);

                reserva.ValorEstimado = CalcularValorTotal(reserva.DataEstimada);             
                reserva = _reservaServico.Cadastrar(reserva);

                Console.WriteLine("A reserva registrado é " + reserva.InformacoesReserva());

            }

            //falta mostar a reserva depois de concluida

            Console.ReadLine();

        }
        public static void BuscarNome()
        {
            Console.WriteLine("Informe o nome da Reserva:");
            string nome = Console.ReadLine();
            Reserva reserva = _reservaServico.BuscarNome(nome);

            if (reserva != null)
            {
                Console.WriteLine("\nReserva encontrado:");
                Console.WriteLine(reserva.InformacoesReserva());
            }
            else
            {
                Console.WriteLine("Reserva não encontrado.");
            }
        }

        public static void BuscarCpf()
        {
            Console.WriteLine("Informe o Cpf da Reserva:");
            string cpf = Console.ReadLine();
            
            if (!Regex.IsMatch(cpf, @"^\d{11}$")) // Exemplo de validação para CPF
            {
                Console.WriteLine("CPF inválido. Por favor, insira um CPF válido.");
                return;
            }
            Reserva reserva = _reservaServico.BuscarCpf(cpf);

            if (reserva != null)
            {
                Console.WriteLine("\nReserva encontrado:");
                Console.WriteLine(reserva.InformacoesReserva());
            }
            else
            {
                Console.WriteLine("Reserva não encontrado.");
            }
        }
        private static void Atualizar()
        {
            Console.WriteLine("Informe um Reserva para atualizar as informações");
            string nome = Console.ReadLine();
            Reserva reservaExistente = _reservaServico.BuscarNome(nome);

            if (reservaExistente == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }
            Console.WriteLine("Informe o novo nome do livro:");
            reservaExistente.NomeCompleto = Console.ReadLine();

            Console.WriteLine("Informe o novo Cpf:");
            reservaExistente.Cpf = Console.ReadLine();

            Console.WriteLine("Informe a nova sinopse:");
            reservaExistente.DataReserva = DateTime.Now;

            Console.WriteLine("Informe quantos dias vai ficar com a Reserva estimada ");
            int dias = int.Parse(Console.ReadLine());
            reservaExistente.DataEstimada = DateTime.Now.AddDays(dias);

            reservaExistente.ValorEstimado = CalcularValorTotal(reservaExistente.DataEstimada);

            Reserva atualizado = _reservaServico.Atualizar(reservaExistente);

            Console.WriteLine("Reserva atualizado com sucesso:");
            Console.WriteLine(atualizado.InformacoesReserva());

        }
        private static void Remover()
        {
            Console.WriteLine("Informe um Livro para atualizar as informações");
            string nome = Console.ReadLine();
            Reserva reserva = _reservaServico.BuscarNome(nome);
            if (reserva != null)
            {
                _reservaServico.Remover(reserva);
                Console.WriteLine("Reserva removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Reserva não encontrado.");
            }
        }


        public static decimal CalcularValorTotal(DateTime dataEstimada)
        {
            const decimal valorBase = 12.00m;
            const decimal multaPorDia = 2.00m;
            const int diasBase = 3;
            var DataReserva = DateTime.Now;
            // Calcula a diferença em dias entre a data atual e a data da reserva
            int diasDecorridos = (dataEstimada - DataReserva).Days;

            // Se a diferença for menor ou igual a 3, não há multa
            if (diasDecorridos <= diasBase)
                return valorBase;

            // Calcula os dias de atraso
            int diasAtraso = diasDecorridos - diasBase;

            // Calcula o valor total com a multa
            return valorBase + (diasAtraso * multaPorDia);
        }





        private static string BuscarCaminhoBanco()

        {
            string diretorioBancoDados = Path.Combine(Environment.CurrentDirectory, "BancoDeDados");

            Directory.CreateDirectory(diretorioBancoDados);

            string caminhoCompleto = Path.Combine(diretorioBancoDados, "bancoDadosReserva.json");

            if (!File.Exists(caminhoCompleto))
            {
                FileStream file = File.Create(caminhoCompleto);

                file.Dispose();
            }

            return caminhoCompleto;
        }
    }
}
