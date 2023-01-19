using RegistrationUserApi.Domain.Commands;

namespace RegistrationUserApi.Tests.CommandTests;

[TestClass]
[TestCategory("Commands")]
public class DeleteUserCommandTests
{
    [TestMethod]
    public void DadoAUmEmailInvalidoInterromperAExecucao()
    {
        var command = new DeleteUser(Guid.NewGuid(), "");
        command.Validate();
        Assert.AreEqual(command.Valid, false);
    }
    
    [TestMethod]
    public void DadoAUmEmailValidoConcluir()
    {
        var command = new DeleteUser(Guid.NewGuid(), "andersonvieira@outlook.com");
        command.Validate();
        Assert.AreEqual(command.Valid, true);
    }
}