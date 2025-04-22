namespace Projeto_Locadora.Entidade
{
    public static class LivroExtencao
    {
        public static string InformacoesLivro(this Livro livro)
        {
            string informacoes = "";

            informacoes += "Informações dos Livros \n" +
                $"Nome: {livro.Nome}\n" +
                $"Autor Do Livro: {livro.Autor}\n" +
                $"Sinopse: {livro.Sinapse}\n";
               

            return informacoes;
        }
    }
}
