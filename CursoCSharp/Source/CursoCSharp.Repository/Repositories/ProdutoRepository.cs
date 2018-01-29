using CursoCSharp.Domain.Entidades;
using CursoCSharp.Repository.DataBase;
using ProjetoCursoFeriasSMN.Repository.DataBase;
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

            var listaProdutos = new List<Produto>();

            using (var reader = ExecuteReader())
                while (reader.Read())
                    listaProdutos.Add(new Produto
                    {
                        CodigoProduto = reader.ReadAsInt("CodigoProduto"),
                        Nome = reader.ReadAsString("Nome"),
                        Preco = reader.ReadAsDecimal("Preco"),
                        Estoque = reader.ReadAsInt("Estoque")
                    });
            
        }
    }
}
