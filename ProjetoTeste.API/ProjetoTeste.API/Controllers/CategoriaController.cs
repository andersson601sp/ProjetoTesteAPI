using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoTeste.Domain.Commands.Categoria;
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
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _service;
        private readonly CategoriaHandler _handler;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ICategoriaService service, CategoriaHandler handler, ILogger<CategoriaController> logger)
        {
            _service = service;
            _handler = handler;
            _logger = logger;
        }

        [HttpGet]
        [Route("v1/categoria")]
        public IEnumerable<QueryCategoria> Get(int pagina, int quantidade, string query)
        {
            return _service.BuscarCategorias(pagina, quantidade, query);
        }

        [HttpGet]
        [Route("v1/categoria/:categoriaId")]
        public QueryCategoria GetId(Guid categoriaId)
        {
            return _service.BuscarCategoriaPor(categoriaId);
        }

        [HttpPost]
        [Route("v1/categoria")]
        public ICommandResult Post(CadastrarCategoriaCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/categoria")]
        public ICommandResult Put(EditarCategoriaCommand command)
        {
            return _handler.Handle(command);
        }
    }
}
