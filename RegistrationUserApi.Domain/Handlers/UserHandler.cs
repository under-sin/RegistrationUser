using Flunt.Notifications;
using RegistrationUserApi.Domain.Commands;
using RegistrationUserApi.Domain.Commands.Contracts;
using RegistrationUserApi.Domain.Entities;
using RegistrationUserApi.Domain.Handlers.Contracts;
using RegistrationUserApi.Domain.Repositories;

namespace RegistrationUserApi.Domain.Handlers;

public class UserHandler :
    Notifiable,
    IHandler<CreateUser>,
    IHandler<UpdateUser>,
    IHandler<DeleteUser>
{
    private readonly IUserRepository _repository;

    public UserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateUser command)
    {
        // Fail fast validate
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Erro ao tentar criar o usuário", command.Notifications);

        var user = new User(command.Name, command.Email);
        _repository.Create(user);

        return new GenericCommandResult(true, "Usuário cadastrado com sucesso!", user);
    }

    public ICommandResult Handle(UpdateUser command)
    {
        // Fail fast validate
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Erro ao tentar atualizar o usuário", command.Notifications);

        var user = _repository.GetById(command.Id, command.Email);

        user.UpdateName(command.Name);
        _repository.Update(user);

        return new GenericCommandResult(true, "Usuário atualizado com sucesso!", user);
    }

    public ICommandResult Handle(DeleteUser command)
    {
        // Fail fast validate
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Erro ao tentar deletar o usuário", command.Notifications);

        var user = _repository.GetById(command.Id, command.Email);
        _repository.Delete(user);

        return new GenericCommandResult(true, "Usuário deletado com sucesso!", user);
    }
}
