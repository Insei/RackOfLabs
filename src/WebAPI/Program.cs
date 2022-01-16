using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using RackOfLabs.Application.Extensions;
using RackOfLabs.Infrastructure.Persistence.Contexts;
using RackOfLabs.Infrastructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructurePersistence();


var app = builder.Build();

using (var scope = 
       app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<DataDbContext>())
    context.Database.EnsureCreated();

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