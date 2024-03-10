// <copyright file="DependencyInjection.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using System.Configuration;

namespace FlightSearch;

/// <summary>
/// Helper class used to aid in service setup.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Setups the IWeatherService and its dependencies.
    /// </summary>
    /// <param name="builder">WebApplicationBuilder to register into.</param>
    /// <returns>WebApplicationBuilder with dependencies registered.</returns>
    /// <exception cref="ConfigurationErrorsException">Thrown if configuration item is missing or invalid.</exception>
    public static WebApplicationBuilder AddFlightSearchService(this WebApplicationBuilder builder)
    {
       return builder;
    }
}
