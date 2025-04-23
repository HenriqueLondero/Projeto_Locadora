using Projeto_Locadora.Entidade;
using Projeto_Locadora.Front;
using Projeto_Locadora.Servicos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Locadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool executar = true;
            do
            {



                Console.WriteLine("BEm vindo a locadora de livros");
                Console.WriteLine("Informe a opção desejada!");
                Console.WriteLine("1 Menu de livros");
                Console.WriteLine("2 Menu de reservas");
                Console.WriteLine("3 para sair");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        {
                            LivroFront.ExecutarMenu();
                            break;
                        }
                    case 2:
                        {
                            ReservaFront.ExecutarMenuReserva();
                            break;
                        }
                    case 3:
                        {
                            executar = false;
                            break;
                        }
                    default:
                        break;
                }
            } while (executar);

        }
    }
}
