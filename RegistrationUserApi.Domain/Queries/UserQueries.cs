using System.Linq.Expressions;
using RegistrationUserApi.Domain.Entities;

namespace RegistrationUserApi.Domain.Queries;

public static class UserQueries
{
    public static Expression<Func<User, bool>> GetAll {get;}
    
    public static Expression<Func<User, bool>> GetById(Guid id, string email)
    {
        return x => x.Id == id && x.Email == email;
    }
}