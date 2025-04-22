using Projeto_Locadora.Entidade;
using Projeto_Locadora.Interface;
using Projeto_Locadora.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Locadora.Servicos
{
    public class ReservaServico : ICRUD<Reserva>
    {
        ReservaRepositorio _reservaRepositorio;

        public ReservaServico(string caminhoBanco)
        {
            _reservaRepositorio = new ReservaRepositorio(caminhoBanco);
        }
        public Reserva Atualizar(Reserva reserva)
        {
            return _reservaRepositorio.Atualizar(reserva);
        }

        public Reserva BuscarNome(string nome)
        {
            return _reservaRepositorio.BuscarNome(nome);
        }



        public Reserva Cadastrar(Reserva reserva)
        {
            return _reservaRepositorio.Cadastrar(reserva);
        }


        public Reserva Remover(Reserva reserva)
        {
            return _reservaRepositorio.Remover(reserva);
        }

        public List<Reserva> BuscarTodos()
        {
            return _reservaRepositorio.BuscarTodos();
        }

        public Reserva BuscarCpf(string cpf)
        {
            return _reservaRepositorio.BuscarCpf(cpf);
        }
    }
}
