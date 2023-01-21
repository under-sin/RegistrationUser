using Microsoft.EntityFrameworkCore;
using RegistrationUserApi.Domain.Handlers;
using RegistrationUserApi.Domain.Repositories;
using RegistrationUserApi.Infra.Context;
using RegistrationUserApi.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Database"));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserHandler, UserHandler>();
    
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
