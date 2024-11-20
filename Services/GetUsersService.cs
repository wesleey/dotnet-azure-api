using Backend.Entities;
using Backend.Repositories;

namespace Backend.Services;

public class GetUsersService(UserRepository repository)
{
    private readonly UserRepository _repository = repository;

    public async Task<List<User>> Execute()
        => await _repository.GetAll();
}
