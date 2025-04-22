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
    public class LivroServico : ICRUD<Livro>
    {
        LivroRepositorio _livroRepositorio;

        public LivroServico(string caminhoBanco)
        {
            _livroRepositorio = new LivroRepositorio(caminhoBanco);
        }
        public Livro Atualizar(Livro livro)
        {
            return _livroRepositorio.Atualizar(livro);
        }

        public Livro BuscarNome(string nome)
        {
            return _livroRepositorio.BuscarNome(nome);
        }



        public Livro Cadastrar(Livro livro)
        {
           return  _livroRepositorio.Cadastrar(livro);
        }


        public Livro Remover(Livro livro)
        {
            return _livroRepositorio.Remover(livro);
        }

        public List<Livro> BuscarTodosLivros()
        {
            return _livroRepositorio.BuscarTodosLivros();
        }




    }
}
