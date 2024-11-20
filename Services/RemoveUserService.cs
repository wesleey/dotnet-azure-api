using Backend.Repositories;

namespace Backend.Services;

public class RemoveUserService(UserRepository repository)
{
    private readonly UserRepository _repository = repository;

    public async Task Execute(int id)
    {
        var user = await _repository.Get(id)
            ?? throw new ArgumentException("user not found");

        await _repository.Remove(user);
    }
}
