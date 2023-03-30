using Shared.Commands;
using Shared.FluentValidator;
using Shared.FluentValidator.Validation;
using System;

namespace ProjetoTeste.Domain.Commands.Produto
{
    public class CadastrarProdutoCommand : Notifiable, ICommand
    {
        public Guid? IdProduto { get; set; }
        public Guid IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public bool Validate()
        {
            AddNotifications(new ValidationContract()
                .GuidIsEmptyOrNull(IdCategoria, "idCategoria", "O idCategoria não pode ser vazio ou nulo."));
            AddNotifications(new ValidationContract()
                .IsNullOrEmpty(Nome, "nome", "O nome não pode ser vazio ou nulo."));
            AddNotifications(new ValidationContract()
               .IsNullOrEmpty(Descricao, "descricao", "A descrição não pode ser vazio ou nulo."));
            AddNotifications(new ValidationContract()
               .AreNotEquals(Preco, "preco", "O preço não pode ser zero."));


            return Valid;
        }
    }
}
