using Backend.Data;
using Backend.Repositories;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<CreateUserService>();
builder.Services.AddScoped<UpdateUserService>();
builder.Services.AddScoped<RemoveUserService>();
builder.Services.AddScoped<GetUserService>();
builder.Services.AddScoped<GetUsersService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
