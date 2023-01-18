using Flunt.Notifications;
using Flunt.Validations;
using RegistrationUserApi.Domain.Commands.Contracts;

namespace RegistrationUserApi.Domain.Commands;

public class DeleteUser : Notifiable, ICommand
{
    public DeleteUser() { }

    public DeleteUser(Guid id, string email)
    {
        Id = id;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Email { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
            .IsEmail(Email, "E-mail", "E-mail inválido")
        );
    }
}
