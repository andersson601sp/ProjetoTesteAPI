using ProjetoTeste.Domain.Commands.Produto;
using ProjetoTeste.Domain.Queries;
using System;
using System.Collections.Generic;

namespace ProjetoTeste.Domain.Services
{
    public interface IProdutoService
    {
        IEnumerable<QueryProduto> BuscarProdutos(int pagina, int quantidade, string query);
        QueryProduto BuscarProdutoPor(Guid idProduto);
        IEnumerable<QueryProduto> BuscarProdutoPorCategoria(Guid idCategoria);
    }
}
