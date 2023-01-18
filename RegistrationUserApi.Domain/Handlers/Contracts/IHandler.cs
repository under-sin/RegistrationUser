using RegistrationUserApi.Domain.Commands.Contracts;

namespace RegistrationUserApi.Domain.Handlers.Contracts;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}
