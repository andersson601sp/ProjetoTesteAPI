using ProjetoTeste.Domain.Queries;
using ProjetoTeste.Domain.Repositories;
using ProjetoTeste.Domain.Services;
using System;
using System.Collections.Generic;

namespace ProjetoTeste.Infrastructure.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public QueryProduto BuscarProdutoPor(Guid idProduto)
        {
            return _repository.BuscarProdutoPor(idProduto);
        }

        public IEnumerable<QueryProduto> BuscarProdutoPorCategoria(Guid idCategoria)
        {
            return _repository.BuscarProdutoPorCategoria(idCategoria);
        }

        public IEnumerable<QueryProduto> BuscarProdutos(int pagina, int quantidade, string query)
        {
            return _repository.BuscarProdutos(pagina, quantidade, query);
        }
    }
}
