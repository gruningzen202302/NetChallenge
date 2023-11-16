using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetChallenge.Data;
using NetChallenge.Domain;
using AutoMapper;
using NetChallenge.Abstractions;
using NetChallenge.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options=>{
    options.AddPolicy("AllowXamarin", builder =>{
        builder
        .AllowAnyOrigin()
        //.WithOrigins("http://localhost:8081","http://192.168.1.24:8081")//TODO if the wildcard fails try this verbosity 
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services
    .AddAutoMapper(typeof(BookingProfile))
    .AddSingleton<ILocationRepository,ILocationRepository>()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

string GetDatabasePath()
{
    var databasePath = "";
    var databaseName = "OfficeRental.sqlite";
    return Path.Combine(databasePath,databaseName);

}
builder.Services.AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlite($"Filename={GetDatabasePath()}");
        opt.EnableSensitiveDataLogging();
    });

var app = builder.Build();
app.UseCors("AllowXamarin");
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("api/locations", async (AppDbContext context, Location location) =>
{
    //await context.Locations.AddAsync(location);
    new LocationRepository(context).Add(location);
    await context.SaveChangesAsync();
    return Results.Created($"api/locations/{location.Id}", location);
})
.WithName("Locations")
.WithOpenApi();

app.Run();