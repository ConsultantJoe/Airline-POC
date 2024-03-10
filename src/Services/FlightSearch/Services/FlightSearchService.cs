// <copyright file="FlightSearchService.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSearch.Models;
using FlightSearch.Repositories;

namespace FlightSearch.Services;

/// <summary>
/// Service used for flight related tasks.
/// </summary>
public class FlightSearchService : IFlightSearchService
{
    private readonly ILogger<FlightSearchService> _logger;
    private readonly IFlightsDao _flightsDao;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlightSearchService"/> class.
    /// </summary>
    /// <param name="logger">Logger that is wired up via DI.</param>
    /// <param name="flightsDao">Repo used to get data from JSON file.</param>
    /// <exception cref="ArgumentNullException">Thrown if a parameter is missing.</exception>
    public FlightSearchService(ILogger<FlightSearchService> logger, IFlightsDao flightsDao)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _flightsDao = flightsDao ?? throw new ArgumentNullException(nameof(flightsDao));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<FlightSearchPayload>> FindFlights(string origin, string destination)
    {
        var flights = await _flightsDao.GetAll();
        if (flights == null)
        {
            throw new InvalidDataException("Invaild or missing flight data.");
        }

        return flights.Where(f => f.Origin == origin && f.Destination == destination)
            .AsEnumerable();
    }
}
