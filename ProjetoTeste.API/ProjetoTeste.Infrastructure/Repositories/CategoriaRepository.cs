using ProjetoTeste.Domain.Commands.Categoria;
using ProjetoTeste.Domain.Queries;
using ProjetoTeste.Domain.Repositories;
using ProjetoTeste.Infrastructure.DataBase.MySql;
using System;
using System.Collections.Generic;

namespace ProjetoTeste.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MySQLDapper _comando;
        public CategoriaRepository()
        {
            _comando = new MySQLDapper();
        }

        public QueryCategoria BuscarCategoriaPor(Guid idCategoria)
        {
            var sql = $"SELECT idcategoria, nome, situacao as ativo FROM Categoria where idCategoria = '{idCategoria}'";
  
            return _comando.QueryFirst<QueryCategoria>(sql);
        }

        public IEnumerable<QueryCategoria> BuscarCategorias(int pagina, int quantidade, string query)
        {
            var sql = $"SELECT idcategoria, nome, situacao as ativo FROM Categoria";

            if (!string.IsNullOrWhiteSpace(query))
                sql += $" where nome Like '%{query}%'";

            if (pagina > 0 && quantidade > 0)
                sql += $" order by nome LIMIT {(pagina - 1) * quantidade },{quantidade}";

            return _comando.QueryAsync<QueryCategoria>(sql).Result;
        }

        public bool CadastrarCategoria(CadastrarCategoriaCommand command)
        {
            try
            {
                command.IdCategoria = Guid.NewGuid();
                var sql = $"insert into Categoria(idcategoria, nome) " +
                    $"values('{command.IdCategoria}', '{command.Nome}')";

                _comando.ExecuteAsync(sql, command);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool EditarCategoria(EditarCategoriaCommand command)
        {
            try
            {
                var sql = $"update Categoria set nome =  '{command.Nome}' where idcategoria = '{command.IdCategoria}'";

                _comando.ExecuteAsync(sql, command);
                return true;
            }
            catch (Exception)
            {
                return true;
            };
        }
    }
}
