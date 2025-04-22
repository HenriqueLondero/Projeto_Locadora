using Newtonsoft.Json;
using Projeto_Locadora.Entidade;
using Projeto_Locadora.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Locadora.Repositorio
{
    public class ReservaRepositorio: ICRUD<Reserva>
    {
        public List<Reserva> _reserva = new List<Reserva>();

        private readonly string _caminhoBanco;



        public ReservaRepositorio(string caminhoBanco)
        {
            _caminhoBanco = caminhoBanco;
            CarregarLista();
        }

        public void CarregarLista()
        {
            string dados = File.ReadAllText(_caminhoBanco);

            _reserva = JsonConvert.DeserializeObject<List<Reserva>>(dados) ?? new List<Reserva>();
        }

        private void Salvar()
        {
            string dados = JsonConvert.SerializeObject(_reserva);

            File.WriteAllText(_caminhoBanco, dados);
        }

        public Reserva Cadastrar(Reserva reserva)
        {

            _reserva.Add(reserva);
            Salvar();
            return reserva;
        }


        public Reserva BuscarNome(string nome)
        {

            Reserva reserva = _reserva.Find(reservaBuscar => reservaBuscar.NomeCompleto == nome);
            return reserva;
        }

        public Reserva BuscarCpf(string Cpf)
        {

            Reserva reserva = _reserva.Find(reservaBuscar => reservaBuscar.Cpf == Cpf);
            return reserva;
        }

        public Reserva Atualizar(Reserva reserva)
        {
            Reserva atualizarReserva = BuscarNome(reserva.NomeCompleto);

            if (atualizarReserva != null)
            {
                atualizarReserva.NomeCompleto = reserva.NomeCompleto;
                atualizarReserva.Cpf = reserva.Cpf;
                atualizarReserva.DataReserva = reserva.DataReserva;
                atualizarReserva.DataEstimada = reserva.DataEstimada;
                atualizarReserva.DataEntrega = reserva.DataEntrega;
                atualizarReserva.ValorEstimado = reserva.ValorEstimado;



                Salvar();
            }
            return atualizarReserva;

        }


        public Reserva Remover(Reserva reserva)
        {
            _reserva.Remove(reserva);
            Salvar();
            return reserva;
        }

        public List<Reserva> BuscarTodos()
        {
            return _reserva;
        }















    }
}
