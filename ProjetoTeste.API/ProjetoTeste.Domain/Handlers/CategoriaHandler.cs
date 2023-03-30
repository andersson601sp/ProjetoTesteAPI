using ProjetoTeste.Domain.Commands;
using ProjetoTeste.Domain.Commands.Categoria;
using ProjetoTeste.Domain.Repositories;
using Shared.Commands;
using Shared.FluentValidator;

namespace ProjetoTeste.Domain.Handlers
{
    public class CategoriaHandler : Notifiable,
      ICommandHandler<CadastrarCategoriaCommand>,
      ICommandHandler<EditarCategoriaCommand>
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaHandler(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CadastrarCategoriaCommand command)
        {
            if (Invalid)
                return new CommandResult(false, "Por favor, corrija os campos", Notifications);
            if (!_repository.CadastrarCategoria(command))
                return new CommandResult(false, "Ocorreu um erro ao cadastrar a categoria", new { });

            return new CommandResult(true, "Categoria cadastrada com sucesso!", new { });
        }

        public ICommandResult Handle(EditarCategoriaCommand command)
        {
            if (Invalid)
                return new CommandResult(false, "Por favor, corrija os campos", Notifications);
            if (!_repository.EditarCategoria(command))
                return new CommandResult(false, "Ocorreu um erro ao editar a categoria", new { });

            return new CommandResult(true, "Categoria editada com sucesso!", new { });
        }
    }
}
