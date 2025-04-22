using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto_Locadora.Entidade
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Sinapse { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        

    }
}
