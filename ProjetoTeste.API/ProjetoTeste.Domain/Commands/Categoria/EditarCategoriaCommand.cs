using Shared.Commands;
using Shared.FluentValidator;
using Shared.FluentValidator.Validation;
using System;

namespace ProjetoTeste.Domain.Commands.Categoria
{
    public class EditarCategoriaCommand : Notifiable, ICommand
    {
        public Guid IdCategoria { get; set; }
        public string Nome { get; set; }

        public bool Validate()
        {
            AddNotifications(new ValidationContract()
                .GuidIsEmptyOrNull(IdCategoria, "idCategoria", "O idCategoria não pode ser vazio ou nulo."));
            AddNotifications(new ValidationContract()
                .IsNullOrEmpty(Nome, "nome", "O nome não pode ser vazio ou nulo."));

            return Valid;
        }
    }
}
