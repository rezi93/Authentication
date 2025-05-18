using AuthECAPI.Models;
using AuthECAPI.Repositories;
using AuthECAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext with connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the UserService
builder.Services.AddTransient<UserService>(sp =>
{
  var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
  return new UserService(connectionString);
});
builder.Services.AddCors();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")  
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
