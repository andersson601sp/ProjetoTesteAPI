namespace ProjetoTeste.Domain.Queries
{
    public class QueryProduto
    {
        public string IdProduto { get; set; }
        public string IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public bool Ativo { get; set; }        
    }
}
