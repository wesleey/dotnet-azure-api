using Backend.Entities;
using Backend.Repositories;

namespace Backend.Services;

public class GetUserService(UserRepository repository)
{
    private readonly UserRepository _repository = repository;

    public async Task<User> Execute(int id)
        => await _repository.Get(id)
            ?? throw new ArgumentException("user not found");
}
