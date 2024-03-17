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
    /// Books a flight.
    /// </summary>
    /// <param name="flightId">FlightId of the .</param>
    /// <returns>Flight that was added to the booking..</returns>
    public Task<IEnumerable<BookFlightPayload>> BookFlight(Guid flightId);
}
