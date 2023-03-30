using ProjetoTeste.Domain.Commands.Produto;
using ProjetoTeste.Domain.Queries;
using ProjetoTeste.Domain.Repositories;
using ProjetoTeste.Infrastructure.DataBase.MySql;
using System;
using System.Collections.Generic;

namespace ProjetoTeste.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MySQLDapper _comando;
        public ProdutoRepository()
        {
            _comando = new MySQLDapper();
        }

        public QueryProduto BuscarProdutoPor(Guid idProduto)
        {
            var sql = $"SELECT * FROM Produto where idProduto = '{idProduto}'";
            return _comando.QueryFirst<QueryProduto>(sql);
        }

        public IEnumerable<QueryProduto> BuscarProdutoPorCategoria(Guid idCategoria)
        {
            var sql = $"SELECT idproduto, nome, descricao, idcategoria, preco, situacao as ativo FROM Produto where idCategoria = '{idCategoria}'";

            return _comando.QueryAsync<QueryProduto>(sql).Result;
        }

        public IEnumerable<QueryProduto> BuscarProdutos(int pagina, int quantidade, string query)
        {
            var sql = $"SELECT idproduto, nome, descricao, idcategoria, preco, situacao as ativo FROM Produto";

            if (!string.IsNullOrWhiteSpace(query))
                sql += $" where descricao Like '%{query}%'";

            if (pagina > 0 && quantidade > 0)
                sql += $" order by nome LIMIT {(pagina - 1) * quantidade },{quantidade}";

            return _comando.QueryAsync<QueryProduto>(sql).Result;
        }

        public bool CadastrarProduto(CadastrarProdutoCommand command)
        {
            try
            {
                command.IdProduto = Guid.NewGuid();

                var sql = $"insert into Produto(idproduto, nome, descricao, idcategoria, preco) " +
                    $"values('{command.IdProduto}', '{command.Nome}', '{command.Descricao}', " +
                    $"'{command.IdCategoria}', " +
                    $"{command.Preco.ToString().Replace(",",".")})";

                _comando.ExecuteAsync(sql, command);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool EditarProduto(EditarProdutoCommand command)
        {
            try
            {
                  var sql = $"update Produto set " +
                    $"nome = '{command.Nome}', " +
                    $"descricao = '{command.Descricao}', " +
                    $"idcategoria = '{command.IdCategoria}', " +
                    $"preco = {command.Preco.ToString().Replace(",",".")}" +
                    $" where idproduto = '{command.IdProduto}'";

                _comando.ExecuteAsync(sql, command);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
