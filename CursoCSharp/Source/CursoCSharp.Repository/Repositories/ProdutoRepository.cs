using CursoCSharp.Domain.Entidades;
using CursoCSharp.Repository.DataBase;
using ProjetoCursoFeriasSMN.Repository.DataBase;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System;

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
                        Estoque = reader.ReadAsShort("Estoque")
                    });
            return listaProdutos;
        }

        public string CadastraProduto(Produto produto)
        {
            ExecuteProcedure("SP_InsProduto");
            AddParameter("@Nome", produto.Nome);
            AddParameter("@Preco", produto.Preco);
            AddParameter("@Estoque", produto.Estoque);

            var retorno = ExecuteNonQueryWithReturn();

            if (retorno == 1)
                return "Erro ao inserir o produto.";

            return null;
        }

        public string DeletarProduto(int codigoProduto)
        {
            ExecuteProcedure("SP_DelProduto");
            AddParameter("@CodigoProduto", codigoProduto);

            var retorno = ExecuteNonQueryWithReturn();

            switch(retorno)
            {
                case 1: return "Exclusão não permitida, o produto esta vinculado a uma venda";
                case 2: return "Erro ao excluir o produto";
            }
            return null;
        } 
    }
}
