using Flunt.Notifications;
using Flunt.Validations;
using RegistrationUserApi.Domain.Commands.Contracts;


namespace RegistrationUserApi.Domain.Commands;

public class UpdateUser : Notifiable, ICommand
{
    public UpdateUser() { }

    public UpdateUser(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(Name, 3, "Name", "Nome inválido")
            .HasMinLen(Email, 8, "E-mail", "E-mail inválido")
            .IsEmail(Email, "E-mail", "E-mail inválido")
        );
    }
}
