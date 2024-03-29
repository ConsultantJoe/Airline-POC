﻿// <copyright file="DependencyInjection.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using System.Configuration;
using FlightSearch.Configuration;
using FlightSearch.Repositories;
using FlightSearch.Services;
using Serilog;

namespace FlightSearch;

/// <summary>
/// Helper class used to aid in service setup.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Setup the IFlightSearchService and its dependencies.
    /// </summary>
    /// <param name="builder">WebApplicationBuilder to register into.</param>
    /// <returns>WebApplicationBuilder with dependencies registered.</returns>
    /// <exception cref="ConfigurationErrorsException">Thrown if configuration item is missing or invalid.</exception>
    public static WebApplicationBuilder AddFlightSearchService(this WebApplicationBuilder builder)
    {
        var flightSearchConfiguration = builder.Configuration.GetSection(nameof(FlightSearchConfiguration)).Get<FlightSearchConfiguration>();

        if (flightSearchConfiguration is null)
        {
            throw new ConfigurationErrorsException($"{nameof(flightSearchConfiguration)} is invalid or missing");
        }

        builder.Services
            .AddSingleton(flightSearchConfiguration)
            .AddSingleton<IFlightSearchService, FlightSearchService>()
            .AddSingleton<IFlightsDao, FlightsDao>();

        return builder;
    }

    /// <summary>
    /// Setup Logging and Tracing.
    /// </summary>
    /// <param name="builder">WebApplicationBuilder to register into.</param>
    /// <param name="serviceName">Name of the Service that Logging is being configured for.</param>
    /// <returns>WebApplicationBuilder with dependencies registered.</returns>
    public static WebApplicationBuilder AddLoggingAndTracing(this WebApplicationBuilder builder, string serviceName)
    {
        builder.Host.UseSerilog((ctx, lc) =>
            lc.ReadFrom
                .Configuration(ctx.Configuration)
                .Enrich.WithProperty("Application", serviceName));

        return builder;
    }
}
