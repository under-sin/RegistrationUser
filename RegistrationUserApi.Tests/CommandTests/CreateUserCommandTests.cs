using RegistrationUserApi.Domain.Commands;

namespace RegistrationUserApi.Tests.CommandTests;

[TestClass]
[TestCategory("Commands")]
public class CreateUserCommandTests
{
    [TestMethod]
    public void DadoAUmCommandInvalido()
    {
        var command = new CreateUser("", "");
        command.Validate();
        Assert.AreEqual(command.Valid, false);
    }
    
    [TestMethod]
    public void DadoAUmCommandValido()
    {
        var command = new CreateUser("Anderson", "andersonvieira@outlook.com");
        command.Validate();
        Assert.AreEqual(command.Valid, true);
    }
}