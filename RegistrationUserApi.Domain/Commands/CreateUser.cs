using Flunt.Notifications;
using Flunt.Validations;
using RegistrationUserApi.Domain.Commands.Contracts;

namespace RegistrationUserApi.Domain.Commands;

public class CreateUser : Notifiable, ICommand
{
    public CreateUser() { }

    public CreateUser(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; set; }
    public string Email { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(Name, 3, "Name", "Nome inválido :/")
            .IsEmail(Email, "E-mail", "E-mail inválid")
        );
    }
}
