using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoTeste.Domain.Commands.Produto;
using ProjetoTeste.Domain.Handlers;
using ProjetoTeste.Domain.Queries;
using ProjetoTeste.Domain.Services;
using Shared.Commands;
using System;
using System.Collections.Generic;

namespace ProjetoTeste.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;
        private readonly ProdutoHandler _handler;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(IProdutoService service, ProdutoHandler handler, ILogger<ProdutoController> logger)
        {
            _service = service;
            _handler = handler;
            _logger = logger;
        }

        [HttpGet]
        [Route("v1/produto")]
        public IEnumerable<QueryProduto> Get(int pagina, int quantidade, string query)
        {
            return _service.BuscarProdutos(pagina, quantidade, query);
        }

        [HttpGet]
        [Route("v1/produto/:produtoId")]
        public QueryProduto GetId(Guid produtoId)
        {
            return _service.BuscarProdutoPor(produtoId);
        }

        [HttpGet]
        [Route("v1/produto/:categoriaId")]
        public IEnumerable<QueryProduto> GetProdutoPorCategoria(Guid categoriaId)
        {
            return _service.BuscarProdutoPorCategoria(categoriaId);
        }

        [HttpPost]
        [Route("v1/produto")]
        public ICommandResult Post(CadastrarProdutoCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/produto")]
        public ICommandResult Put(EditarProdutoCommand command)
        {
            return _handler.Handle(command);
        }
    }
}
