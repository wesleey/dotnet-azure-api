namespace Backend.DTOs;

public sealed record UpdateUserRequest(string? Name, string? Email, string? Password);
