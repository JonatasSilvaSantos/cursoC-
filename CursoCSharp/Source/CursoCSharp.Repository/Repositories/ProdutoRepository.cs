using CursoCSharp.Domain.Entidades;
using CursoCSharp.Repository.DataBase;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace CursoCSharp.Repository.Repositories
{
    public class ProdutoRepository : Execucao
    {
        private static readonly Conexao conexao = new Conexao();

        public ProdutoRepository() : base(conexao)
        {
        }

        public IEnumerable<Produto> GetProdutos()
        {
            ExecuteProcedure("[dbo].[SP_SelProdutos]");

            var produtos = new List<Produto>();

            using (var reader = ExecuteReader())
            {
                while (reader.Read())
                    produtos.Add(new Produto(while (reader.Read())
                    listaProdutos.Add(new Produto);
            }
        }
    }
}
