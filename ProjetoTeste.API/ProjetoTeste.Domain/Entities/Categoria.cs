using Shared.FluentValidator;
using System;

namespace ProjetoTeste.Domain.Entities
{
    public class Categoria : Notifiable
    {
        public Categoria()
        {

        }

        public Categoria(string nome)
        {
            Nome = nome;
        }

        public Guid IdCategoria { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
    }
}
