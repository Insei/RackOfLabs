using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using RackOfLabs.Application.Extensions;
using RackOfLabs.Infrastructure.Persistence.Contexts;
using RackOfLabs.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataDbContext>(options => options.UseInMemoryDatabase("LabOfRacks"+ DateTime.Now));
builder.Services.AddApplication();
builder.Services.AddInfrastructurePersistence();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();