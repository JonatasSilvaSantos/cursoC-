using CursoCSharp.Application;
using CursoCSharp.Application.Applications;
using CursoCSharp.Application.Models;
using System.Net;
using System.Web.Mvc;

namespace CursoCSharp.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoApplication _produtoApplication = new ProdutoApplication();

        public ActionResult listarProdutos()
        {
            var response = _produtoApplication.GetProdutos();

            if (response.Status != HttpStatusCode.OK)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.ContentAsString);
            }

            return View("GridProdutos", response.Content);
        }

        public ActionResult CadastrarProduto(ProdutoModel produto)
        {
            var response = _produtoApplication.PostProduto(produto);

            if (response.Status != HttpStatusCode.OK)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.ContentAsString);
            }

            return Content(response.Content);
        }
    }
}