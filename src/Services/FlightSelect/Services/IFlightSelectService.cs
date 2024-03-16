// <copyright file="IFlightSelectService.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSelect.Models;

namespace FlightSelect.Services;

/// <summary>
/// Interfaces for the FlightSelectService.
/// </summary>
public interface IFlightSelectService
{
    /// <summary>
    /// Gets Flight data based on criteria passed in.
    /// </summary>
    /// <param name="origin">Origin airport to use in search.</param>
    /// <param name="destination">Destination airport to use in search.</param>
    /// <returns>List of Flight results.</returns>
    public Task<IEnumerable<FlightSelectPayload>> BookFlight(Guid flightId);
}
