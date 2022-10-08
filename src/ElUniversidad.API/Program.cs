using ElUniversidad.Application.Extensions;
using ElUniversidad.Infrastructure.Data.Modules;
using ElUniversidad.Infrastructure.Data.Seeders;
using ElUniversidad.Infrastructure.Serialization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.DescribeAllParametersInCamelCase();
});

builder.Services
    .AddAppServices()
    .AddAutoMapperConfiguration(Assembly.Load("ElUniversidad.Application"))
    .AddDataInfrastructure(builder.Configuration)
    .AddCQRSConfiguration();

ElUniversidadInitializer.ElUniversidadInitializeAndSeed(builder.Services);

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

app.UseCors(policy =>
{
    policy
        .WithOrigins("https://localhost:4200", "http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.Run();
