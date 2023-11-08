using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetChallenge.Data;
using NetChallenge.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options=>{
    options.AddPolicy("AllowXamarin", builder =>{
        builder
        .AllowAnyOrigin()
        //.WithOrigins("http://localhost:8081","http://192.168.1.24:8081")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

string GetDatabasePath()
{
    var databasePath = "";
    var databaseName = "OfficeBooking.sqlite";
    return Path.Combine(databasePath,databaseName);

}
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(
        //builder.Configuration.GetConnectionString("DefaultConnection")
        $"Filename={GetDatabasePath()}"
        //connectionString
        ));

var app = builder.Build();
app.UseCors("AllowXamarin");
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("api/locations", async (AppDbContext context, Location location) =>
{
    await context.Locations.AddAsync(location);
    await context.SaveChangesAsync();
    return Results.Created($"api/locations/{location.Id}", location);
})
.WithName("Locations")
.WithOpenApi();

app.Run();