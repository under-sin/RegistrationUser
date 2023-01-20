using Microsoft.EntityFrameworkCore;
using RegistrationUserApi.Domain.Entities;
using RegistrationUserApi.Domain.Queries;
using RegistrationUserApi.Domain.Repositories;
using RegistrationUserApi.Infra.Context;

namespace RegistrationUserApi.Infra.Repositories;

public class UserRepository : IUserRepository
{

    private readonly DataContext _context;
    
    public UserRepository(DataContext context)
    {
        _context = context;
    }
    
    public void Create(User use)
    {
        _context.Add(use);
        _context.SaveChanges();
    }

    public void Update(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(User user)
    {
        _context.Entry(user).State = EntityState.Deleted;
        _context.SaveChanges();
    }

    public User GetById(Guid id, string email)
    {
        return _context
            .Users
            .AsNoTracking()
            .FirstOrDefault(UserQueries.GetById(id, email));
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }
}