using RegistrationUserApi.Domain.Entities;
using RegistrationUserApi.Domain.Queries;

namespace RegistrationUserApi.Tests.QueryTests;

[TestClass]
[TestCategory("Queries")]
public class UserQueryTests
{
    private List<User> _users;

    public UserQueryTests()
    {
        _users = new List<User>();
        _users.Add(new User("User 01", "under-sin@outlook"));
        _users.Add(new User("User 02", "under-sin@outlook"));
        _users.Add(new User("User 03", "under-sin@outlook"));
        _users.Add(new User("User 04", "under-sin@outlook"));
        _users.Add(new User("User 05", "under-sin@outlook"));
    }
    
    [TestMethod]
    public void Dado_a_consulta_deve_retornar_todos_os_cinco_usuarios_com_o_mesmo_email()
    {
        var result = _users.AsQueryable().Where(UserQueries.GetByEmail("under-sin@outlook"));
        Assert.AreEqual(5, result.Count());
    }
}