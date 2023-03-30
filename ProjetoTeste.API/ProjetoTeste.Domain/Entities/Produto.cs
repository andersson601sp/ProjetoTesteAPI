using Shared.FluentValidator;
using System;

namespace ProjetoTeste.Domain.Entities
{
    public class Produto : Notifiable
    {
        public Produto()
        {

        }

        public Produto(Guid idCategoria, string nome, string descricao, double preco)
        {
            IdCategoria = idCategoria;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public Guid IdProduto{ get; private set; }
        public Guid IdCategoria { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double Preco { get; private set; }
        public bool Ativo { get; private set; }
    }
}
