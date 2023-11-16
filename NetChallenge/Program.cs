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
using NetChallenge.Dto.Input;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

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
    .AddSingleton<ILocationRepository,LocationRepository>()
    .AddSingleton<IOfficeRepository, OfficeRepository>()
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
    new LocationRepository(context).Add(location);
    await context.SaveChangesAsync();
    return Results.Created($"api/locations/{location.Id}", location);
})
.WithName("Locations")
.WithOpenApi();

app.MapGet("api/office-suggestions/capacity={minCapacity}&neigborhood={neigborhoodPrefference}&facilities={facilitiesEssentials}", async (AppDbContext context,
                                                int minCapacity,
                                                string neigborHoodPrefference,
                                                string facilitiesEssentials) =>
{
    SuggestionsRequest suggestionsRequest = new ()
    {
        MinCapacity = minCapacity,
        NeigborHoodPrefference = neigborHoodPrefference,
        FacilitiesEssentials = facilitiesEssentials.Split(','),
    };

    List<Office> offices = new();
    var officeSuggestions = await Task.Run(() =>

        offices = new OfficeRepository(context).GetMany(x => x.Id>0).ToList()

    );
    return Results.Ok(officeSuggestions);
})
.WithName("Office-Suggestions")
.WithOpenApi();

app.Run();