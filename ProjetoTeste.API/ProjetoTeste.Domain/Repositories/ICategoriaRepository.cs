using ProjetoTeste.Domain.Commands.Categoria;
using ProjetoTeste.Domain.Queries;
using System;
using System.Collections.Generic;

namespace ProjetoTeste.Domain.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<QueryCategoria> BuscarCategorias(int pagina, int quantidade, string query);
        QueryCategoria BuscarCategoriaPor(Guid idCategoria);
        bool CadastrarCategoria(CadastrarCategoriaCommand command);
        bool EditarCategoria(EditarCategoriaCommand command);
    }
}
