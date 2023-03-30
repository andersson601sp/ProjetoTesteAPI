using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoTeste.Infrastructure.DataBase.MySql
{
    interface IMySQLDapper
    {
        public Task<IEnumerable<T>> QueryAsync<T>(string sql);
        public T QueryFirst<T>(string sql);

        public Task<T> QueryFirstAsync<T>(string sql, object entity = null);

        public  int Execute(string sql, object entity);

        public Task<int> ExecuteAsync(string sql, object entity);
    }
}
