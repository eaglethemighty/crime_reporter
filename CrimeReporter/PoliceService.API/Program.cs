using MediatR;
using PoliceService.Application.Extensions;
using PoliceService.Application.Functions.PoliceUnits.Queries.GetPoliceUnitsList;
using PoliceService.Persistence.Extensions;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPoliceServicePersistence();
builder.Services.AddPoliceServiceApplicationCore();
builder.Services.AddLogging();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open",
        builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Open");

app.UseAuthorization();

app.MapControllers();

app.Run();
