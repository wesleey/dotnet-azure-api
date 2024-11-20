using Backend.Data;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UserRepository(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task Create(User user)
    {
        user.Created = DateTime.UtcNow;
        user.Updated = DateTime.UtcNow;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        user.Updated = DateTime.UtcNow;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> Get(int id)
        => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<User>> GetAll()
        => await _context.Users.ToListAsync();

    public async Task<bool> EmailExists(string email)
        => await _context.Users.AnyAsync(x => x.Email == email);
}
