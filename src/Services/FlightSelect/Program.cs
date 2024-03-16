// <copyright file="Program.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

namespace FlightSelect;

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

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Wireup the FlightSelectService and its dependencies.
        builder.AddFlightSelectService();

        // Wireup serilog
        builder.AddLoggingAndTracing("FlightSearch");

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
    }
}
