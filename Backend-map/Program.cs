using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Backend_map.Data;
using Backend_map;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Backend_mapContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Backend_mapContext") ?? throw new InvalidOperationException("Connection string 'Backend_mapContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
