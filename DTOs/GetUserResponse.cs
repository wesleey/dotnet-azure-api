namespace Backend.DTOs;

public class GetUserResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
