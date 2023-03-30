using ProjetoTeste.Domain.Commands;
using ProjetoTeste.Domain.Commands.Produto;
using ProjetoTeste.Domain.Repositories;
using Shared.Commands;
using Shared.FluentValidator;

namespace ProjetoTeste.Domain.Handlers
{
    public class ProdutoHandler : Notifiable,
        ICommandHandler<CadastrarProdutoCommand>,
        ICommandHandler<EditarProdutoCommand>
    {
        private readonly IProdutoRepository _repository;

        public ProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CadastrarProdutoCommand command)
        {
            if (Invalid)
                return new CommandResult(false, "Por favor, corrija os campos", Notifications);
            if (!_repository.CadastrarProduto(command))
                return new CommandResult(false, "Ocorreu um erro ao cadastrar o produto", new { });

            return new CommandResult(true, "Produto cadastrado com sucesso!", new { });
        }

        public ICommandResult Handle(EditarProdutoCommand command)
        {
            if (Invalid)
                return new CommandResult(false, "Por favor, corrija os campos", Notifications);
            if (!_repository.EditarProduto(command))
                return new CommandResult(false, "Ocorreu um erro ao editar o produto", new { });

            return new CommandResult(true, "Produto editado com sucesso!", new { });
        }
    }
}
