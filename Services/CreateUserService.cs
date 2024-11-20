using Backend.Entities;
using Backend.Repositories;

namespace Backend.Services;

public class CreateUserService(UserRepository repository)
{
    private readonly UserRepository _repository = repository;

    public async Task Execute(string name, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("email cannot be empty");

        if (await _repository.EmailExists(email))
            throw new ArgumentException("email already exists");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("name cannot be empty");

        if (name.Length < 3)
            throw new ArgumentException("name must be at least 3 characters");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("password cannot be empty");

        if (password.Length < 8)
            throw new ArgumentException("password must be at least 8 characters");

        var user = new User
        {
            Name = name,
            Email = email,
            Password = password,
        };

        await _repository.Create(user);
    }
}
