using Microsoft.AspNetCore.Mvc;
using RegistrationUserApi.Domain.Commands;
using RegistrationUserApi.Domain.Entities;
using RegistrationUserApi.Domain.Handlers;
using RegistrationUserApi.Domain.Repositories;

namespace RegistrationUserApi.Application.Controllers;

[ApiController]
[Route("v1/user")]
public class UserController : ControllerBase
{
    
    [HttpGet("")]
    public IEnumerable<User> GetAll(
        [FromServices] IUserRepository repository    
    )
    {
        return repository.GetAll();
    }
    
    [HttpPost("")]
    public GenericCommandResult Create(
        [FromBody] CreateUser command,
        [FromServices] UserHandler handler    
    )
    {
        return (GenericCommandResult)handler.Handle(command);
    }
}