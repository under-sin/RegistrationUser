using RegistrationUserApi.Domain.Commands;

namespace RegistrationUserApi.Tests.CommandTests;

[TestClass]
[TestCategory("Commands")]
public class UpdateUserCommandTests
{
    [TestMethod]
    public void DadoAUmUpdateCommandInvalido()
    {
        var command = new UpdateUser(Guid.NewGuid(),"", "");
        command.Validate();
        Assert.AreEqual(command.Valid, false);
    }
    
    [TestMethod]
    public void DadoAUmUpdateCommandValido()
    {
        var command = new UpdateUser(Guid.NewGuid(), "Anderson", "andersonvieira@outlook.com");
        command.Validate();
        Assert.AreEqual(command.Valid, true);
    }
}