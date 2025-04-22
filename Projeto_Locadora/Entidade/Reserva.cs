using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Locadora.Entidade
{
    public class Reserva
    {
        public Guid Id { get; set; }
        public string NomeCompleto {  get; set; }
        public string Cpf {  get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime DataEstimada { get; set;  }
        public DateTime DataEntrega { get; set; }
        public decimal ValorEstimado { get; set; }

    }
}
