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
    public class LivroRepositorio : ICRUD<Livro>
    {
        public List<Livro> _livro = new List<Livro>();

        private readonly string _caminhoBanco;



        public LivroRepositorio(string caminhoBanco)
        {
            _caminhoBanco = caminhoBanco;
            CarregarLista();
        }

        public void CarregarLista()
        {
            string dados = File.ReadAllText(_caminhoBanco);

            _livro = JsonConvert.DeserializeObject<List<Livro>>(dados) ?? new List<Livro>();
        }

        private void Salvar()
        {
            string dados = JsonConvert.SerializeObject(_livro);

            File.WriteAllText(_caminhoBanco, dados);
        }

       

       

       


        

        public List<Livro> BuscarTodosLivros()
        {
            return _livro;
        }

        public Livro Cadastrar(Livro livro)
        {
            _livro.Add(livro);
            Salvar();
            return livro;
        }

        public Livro BuscarNome(string nome)
        {

            Livro livro = _livro.Find(livroBuscar => livroBuscar.Nome == nome);
            return livro;
        }

        public Livro Remover(Livro livro)
        {
            _livro.Remove(livro);
            Salvar();
            return livro;
        }

        public Livro Atualizar(Livro livro)
        {
            Livro atualizarLivro = BuscarNome(livro.Nome);

            if (atualizarLivro != null)
            {
                atualizarLivro.Nome = livro.Nome;
                atualizarLivro.Autor = livro.Autor;
                atualizarLivro.Sinapse = livro.Sinapse;

                Salvar();
            }
            return atualizarLivro;
        }
    }
}
