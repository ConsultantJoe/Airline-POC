// <copyright file="FlightSelectHelper.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSelect.Models;

namespace FlightSelect.Tests;

/// <summary>
/// Helper to aid with Unit Testing.
/// </summary>
public static class FlightSelectHelper
{
    /// <summary>
    /// Gets a FlightSearchPayload for unit testing.
    /// </summary>
    /// <returns>A populated FlightSearchPayload.</returns>
    public static IEnumerable<BookFlightPayload> GetBookFlightPayload() =>
        new List<BookFlightPayload>
        {
            new BookFlightPayload
            {
                ArrivalTime = DateTime.Now,
                DepartureTime = DateTime.Now.AddHours(-4),
                Origin = "DEN",
                Destination = "JFK",
                Price = 400.00m,
                FlightId = new Guid("2fc3f906-3dc2-4c17-bf0d-ec5533c5a2af"),
                FlightNumber = "AS450",
            },
        };
}
