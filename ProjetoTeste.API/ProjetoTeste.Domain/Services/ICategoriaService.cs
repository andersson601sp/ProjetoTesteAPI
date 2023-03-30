using ProjetoTeste.Domain.Commands.Categoria;
using ProjetoTeste.Domain.Queries;
using System;
using System.Collections.Generic;

namespace ProjetoTeste.Domain.Services
{
    public interface ICategoriaService
    {
        IEnumerable<QueryCategoria> BuscarCategorias(int pagina, int quantidade, string query);
        QueryCategoria BuscarCategoriaPor(Guid idCategoria);
    }
}
