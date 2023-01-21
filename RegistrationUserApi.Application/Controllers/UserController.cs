using Microsoft.AspNetCore.Mvc;
using RegistrationUserApi.Domain.Commands;
using RegistrationUserApi.Domain.Entities;
using RegistrationUserApi.Domain.Handlers;
using RegistrationUserApi.Domain.Repositories;

namespace RegistrationUserApi.Application.Controllers;

[ApiController]

public class UserController : ControllerBase
{
    
    [HttpGet("v1/user")]
    public IEnumerable<User> GetAll(
        [FromServices] IUserRepository repository    
    )
    {
        return repository.GetAll();
    }

    [HttpGet("v1/user/{id:guid}/{email}")]
    public User GetById(
        [FromRoute] Guid id,
        [FromRoute] string email,
        [FromServices] IUserRepository repository    
    )
    {
        return repository.GetById(id, email);
    }

    [HttpPost("v1/user")]
    public GenericCommandResult Create(
        [FromBody] CreateUser command,
        [FromServices] UserHandler handler    
    )
    {
        return (GenericCommandResult)handler.Handle(command);
    }
    
        
    [HttpPut("v1/user")]
    public GenericCommandResult Upate(
        [FromBody] UpdateUser command,
        [FromServices] UserHandler handler    
    )
    {
        return (GenericCommandResult)handler.Handle(command);
    }
    
            
    [HttpDelete("v1/user")]
    public GenericCommandResult Delete(
        [FromBody] DeleteUser command,
        [FromServices] UserHandler handler    
    )
    {
        return (GenericCommandResult)handler.Handle(command);
    }
}