using RegistrationUserApi.Domain.Entities;

namespace RegistrationUserApi.Domain.Repositories;

public interface IUserRepository
{
    void Create(User use);
    void Update(User user);
    void Delete(User user); // depois ver se vai se preico só do Id
    User GetById(Guid id, string email);    
    IEnumerable<User> GetAll();
}
