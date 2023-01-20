using RegistrationUserApi.Domain.Entities;
using RegistrationUserApi.Domain.Repositories;

namespace RegistrationUserApi.Tests.Repositories;

public class FakeUserRepository : IUserRepository
{
    public void Create(User use)
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }

    public void Delete(User user)
    {
        throw new NotImplementedException();
    }

    public User GetById(Guid id, string email)
    {
        return new User("Anderson", "under-sin@outlook.com");
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }
}