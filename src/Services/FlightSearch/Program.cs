// <copyright file="Program.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSearch.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightSearch;

/// <summary>
/// Main Entry Point.
/// </summary>
public class Program
{
    /// <summary>
    /// Main Entry Point.
    /// </summary>
    /// <param name="args">args.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Add DBContext with PostgresSQL.
        builder.Services.AddDbContext<ApplicationDbContext>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Wireup the FlightSearchService and its dependencies.
        builder.AddFlightSearchService();

        // Wireup serilog
        builder.AddLoggingAndTracing("FlightSearch");

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Because this is a test app and I want the data refreshed everytgimEnsure the database is created when the app starts
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Drop the database if it exists
            dbContext.Database.EnsureDeleted();

            // Ensure the database is created
            dbContext.Database.EnsureCreated();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
