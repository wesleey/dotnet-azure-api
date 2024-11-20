using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateUser([FromServices] CreateUserService service, [FromBody] CreateUserRequest request)
    {
        try
        {
            await service.Execute(request.Name, request.Email, request.Password);
            return Ok(new { success = true, message = "user created successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateUser(int id, [FromServices] UpdateUserService service, [FromBody] UpdateUserRequest request)
    {
        try
        {
            await service.Execute(id, request.Name, request.Email, request.Password);
            return Ok(new { success = true, message = "user updated successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> RemoveUser(int id, [FromServices] RemoveUserService service)
    {
        try
        {
            await service.Execute(id);
            return Ok(new { success = true, message = "user removed successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetUserResponse>> GetUser(int id, [FromServices] GetUserService service)
    {
        try
        {
            var user = await service.Execute(id);

            return Ok(new GetUserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Created = user.Created,
                Updated = user.Updated
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<GetUserResponse>>> GetUsers([FromServices] GetUsersService service)
    {
        try
        {
            var users = await service.Execute();

            return Ok(users.Select(user => new GetUserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Created = user.Created,
                Updated = user.Updated
            }));
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
}
