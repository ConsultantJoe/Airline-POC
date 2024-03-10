// <copyright file="IFlightSearchService.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSearch.Models;

namespace FlightSearch.Services;

/// <summary>
/// Interfaces for the FlightSearchService.
/// </summary>
public interface IFlightSearchService
{
    /// <summary>
    /// Gets Flight data based on criteria passed in.
    /// </summary>
    /// <param name="origin">Origin airport to use in search.</param>
    /// <param name="destination">Destination airport to use in search.</param>
    /// <param name="departureDate">Departure date flying on.</param>
    /// <returns>List of Flight results.</returns>
    public Task<IEnumerable<FlightSearchPayload>> FindFlights(string origin, string destination);
}
