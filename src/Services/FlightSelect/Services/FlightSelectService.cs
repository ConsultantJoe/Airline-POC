// <copyright file="FlightSelectService.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSelect.Models;
using FlightSelect.Repositories;

namespace FlightSelect.Services;

/// <summary>
/// Service used for flight related tasks.
/// </summary>
public class FlightSelectService : IFlightSelectService
{
    private readonly ILogger<FlightSelectService> _logger;
    private readonly IFlightsDao _flightsDao;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlightSelectService"/> class.
    /// </summary>
    /// <param name="logger">Logger that is wired up via DI.</param>
    /// <param name="flightsDao">Repo used to get data from JSON file.</param>
    /// <exception cref="ArgumentNullException">Thrown if a parameter is missing.</exception>
    public FlightSelectService(ILogger<FlightSelectService> logger, IFlightsDao flightsDao)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _flightsDao = flightsDao ?? throw new ArgumentNullException(nameof(flightsDao));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<BookFlightPayload>> BookFlight(Guid flightId)
    {
        var flights = await _flightsDao.GetAll();
        if (flights == null)
        {
            throw new InvalidDataException("Invaild or missing flight data.");
        }

        _logger.LogInformation($"Getting flights for flightId {flightId}.");

        return flights.Where(f => f.FlightId == flightId).AsEnumerable();
    }
}
