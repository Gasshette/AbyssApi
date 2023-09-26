using Core.Interfaces.Repositories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDeepRepository, DeepRepository>();

builder.Services.AddDbContext<AbyssDbContext>(options =>
{
    string azureAbyssConnectionString = builder.Configuration.GetConnectionString("AzureSqlServer");
    options.UseSqlServer(azureAbyssConnectionString);
});

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(opts => opts.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.Run();
