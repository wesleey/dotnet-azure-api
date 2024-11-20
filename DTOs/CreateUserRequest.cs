namespace Backend.DTOs;

public sealed record CreateUserRequest(string Name, string Email, string Password);

