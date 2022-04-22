using Microsoft.EntityFrameworkCore;
using CrimeService.Data.DAL;
using CrimeService.Data.Repository;
using CrimeService.Controllers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILogger>(provider =>
   provider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<CrimeEventsController>>());

builder.Services.AddControllers()
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        }); ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbAccess>(options => options.UseSqlServer(builder.Configuration.GetValue<string>("DbConnectionString")));

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EfCoreRepository<>));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyPendingMigrations();
app.SeedCrimeData();

app.UseExceptionHandler("/error");

app.UseAuthorization();

app.MapControllers();

app.Run();
