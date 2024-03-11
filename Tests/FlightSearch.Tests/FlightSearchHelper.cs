// <copyright file="FlightSearchHelper.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSearch.Models;

namespace FlightSearch.Tests;

/// <summary>
/// Helper to aid with Unit Testing.
/// </summary>
public static class FlightSearchHelper
{
    /// <summary>
    /// Gets a FlightSearchPayload for unit testing.
    /// </summary>
    /// <returns>A populated FlightSearchPayload.</returns>
    public static IEnumerable<FlightSearchPayload> GetFlightSearchPayload() =>
        new List<FlightSearchPayload>
        {
            new FlightSearchPayload
            {
                ArrivalTime = DateTime.Now,
                DepartureTime = DateTime.Now.AddHours(-4),
                Origin = "DEN",
                Destination = "JFK",
                Price = 400.00m,
                FlightId = Guid.NewGuid(),
                FlightNumber = "AS450",
            },
        };
}
