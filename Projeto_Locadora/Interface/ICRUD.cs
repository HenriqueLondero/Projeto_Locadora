using Projeto_Locadora.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Locadora.Interface
{
    public interface ICRUD<T>
    {
        T Cadastrar(T entidade);
        T BuscarNome(string Nome);
        T Remover(T entidade);
        T Atualizar(T entidade);
    }
}
