﻿using CursoCSharp.Domain.Entidades;
using CursoCSharp.Repository.Repositories;
using System.Net.Http;
using System.Web.Http;

namespace CursoCSharp.Api.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();

        [HttpGet, Route("listaProdutos")]
        public IHttpActionResult GetProdutos()
        {
            try
            {
                return Ok(_produtoRepository.GetProdutos());
            }
            catch
            {
                return BadRequest("Erro ao listar produtos!");
            }
           
        }

        [HttpPost, Route("cadastraProduto")]
        public IHttpActionResult PostProdutos(Produto produto)
        {
            try
            {
                var retorno = _produtoRepository.CadastraProduto(produto);
                    if(retorno != null)
                {
                    return BadRequest(retorno);
                }
                return Ok("Produto foi cadastrado com sucesso!");
            }
            catch
            {
                return BadRequest("Algo deu errado");
            }
        }
    }
}