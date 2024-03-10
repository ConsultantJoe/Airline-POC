// <copyright file="FlightsDao.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using System.Text.Json;
using FlightSearch.Configuration;
using FlightSearch.Models;

namespace FlightSearch.Repositories;

/// <summary>
/// Dao that returns flights data from a JSON file.
/// </summary>
public class FlightsDao : IFlightsDao
{
    private readonly FlightSearchConfiguration _flightSearchConfiguration;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlightsDao"/> class.
    /// </summary>
    /// <param name="flightSearchConfiguration">Config for flight search.</param>
    public FlightsDao(FlightSearchConfiguration flightSearchConfiguration)
    {
        _flightSearchConfiguration = flightSearchConfiguration ?? throw new ArgumentNullException(nameof(flightSearchConfiguration));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<FlightSearchPayload>> GetAll()
    {
        var flightsJson = new FileStream(_flightSearchConfiguration.FlightsDataPath, FileMode.Open, FileAccess.Read);

        if (flightsJson == null)
        {
            throw new ArgumentNullException(nameof(flightsJson));
        }

        return await JsonSerializer.DeserializeAsync<List<FlightSearchPayload>>(flightsJson) ?? throw new ArgumentNullException($"Unable to deserilize {_flightSearchConfiguration.FlightsDataPath}.");
    }
}
