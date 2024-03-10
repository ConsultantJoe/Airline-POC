// <copyright file="FlightSearchService.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSearch.Models;

namespace FlightSearch.Services;

/// <summary>
/// Service used for flight related tasks.
/// </summary>
public class FlightSearchService : IFlightSearchService
{
    /// <inheritdoc/>
    public async Task<IEnumerable<FlightSearchPayload>> findFlights(string origin, string destination, DateTime departureDate)
    {
        throw new NotImplementedException();
    }
}
