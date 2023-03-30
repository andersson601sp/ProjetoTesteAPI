using ProjetoTeste.Domain.Commands.Produto;
using ProjetoTeste.Domain.Queries;
using System;
using System.Collections.Generic;

namespace ProjetoTeste.Domain.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<QueryProduto> BuscarProdutos(int pagina, int quantidade, string query);
        QueryProduto BuscarProdutoPor(Guid idProduto);
        IEnumerable<QueryProduto> BuscarProdutoPorCategoria(Guid idCategoria);
        bool CadastrarProduto(CadastrarProdutoCommand command);
        bool EditarProduto(EditarProdutoCommand command);
    }
}
