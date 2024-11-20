using Backend.Repositories;

namespace Backend.Services;

public class UpdateUserService(UserRepository repository)
{
    private readonly UserRepository _repository = repository;

    public async Task Execute(int id, string? name, string? email, string? password)
    {
        var user = await _repository.Get(id)
            ?? throw new ArgumentException("user not found");

        if (email is not null)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("email cannot be empty");

            if (await _repository.EmailExists(email))
                throw new ArgumentException("email already exists");

            user.Email = email;
        }

        if (name is not null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be empty");

            if (name.Length < 3)
                throw new ArgumentException("name must be at least 3 characters");

            user.Name = name;
        }

        if (password is not null)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("password cannot be empty");

            if (password.Length < 8)
                throw new ArgumentException("password must be at least 8 characters");

            user.Password = password;
        }

        await _repository.Update(user);
    }
}
