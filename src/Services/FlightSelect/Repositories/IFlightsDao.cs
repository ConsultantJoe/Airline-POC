// <copyright file="IFlightsDao.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSelect.Models;

namespace FlightSelect.Repositories;

/// <summary>
/// Interface for the FlightsDao.
/// </summary>
public interface IFlightsDao
{
    /// <summary>
    /// Gets all data from the Flights.json file.
    /// </summary>
    /// <returns>Collection of FlightSearchPayload objects.</returns>
    Task<IEnumerable<BookFlightPayload>> GetAll();
}
