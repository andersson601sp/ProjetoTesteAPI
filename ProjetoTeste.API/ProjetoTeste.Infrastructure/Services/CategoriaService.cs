using ProjetoTeste.Domain.Queries;
using ProjetoTeste.Domain.Repositories;
using ProjetoTeste.Domain.Services;
using System;
using System.Collections.Generic;

namespace ProjetoTeste.Infrastructure.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public QueryCategoria BuscarCategoriaPor(Guid idCategoria)
        {
            return _repository.BuscarCategoriaPor(idCategoria);
        }

        public IEnumerable<QueryCategoria> BuscarCategorias(int pagina, int quantidade, string query)
        {
            return _repository.BuscarCategorias(pagina, quantidade, query);
        }

    }
}
