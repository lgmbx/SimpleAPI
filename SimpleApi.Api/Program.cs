using Microsoft.EntityFrameworkCore;
using SimpleApi.Data.Context;
using SimpleApi.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt => 
    opt
    //.UseLazyLoadingProxies()
    .UseSqlServer(connString)
);

builder.Services.AddControllers();
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
