// <copyright file="FlightSearchController.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSearch.Models;
using FlightSearch.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightSearch.Controllers;

/// <summary>
/// Controller class for the WeatherForcast.
/// </summary>
[ApiController]
[Route("[controller]")]
public class FlightSearchController : ControllerBase
{
    private readonly ILogger<FlightSearchController> _logger;
    private readonly IFlightSearchService _flightSearchService;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlightSearchController"/> class.
    /// </summary>
    /// <param name="logger">Logger that is wired up via DI.</param>
    /// <exception cref="ArgumentNullException">Thrown if a parameter is missing.</exception>
    public FlightSearchController(ILogger<FlightSearchController> logger, IFlightSearchService flightSearchService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _flightSearchService = flightSearchService ?? throw new ArgumentNullException(nameof(flightSearchService));
    }

    /// <summary>
    /// Find flights for a given set of parameters.
    /// </summary>
    /// <param name="origin">Origin airport to use in search.</param>
    /// <param name="destination">Destination airport to use in search.</param>
    /// <param name="departureDate">Departure date flying on.</param>
    /// <returns>List of Flight results.</returns>
    [HttpGet(Name = "FindFlights")]
    public async Task<IEnumerable<FlightSearchPayload>> Get(string origin, string destination, DateTime departureDate)
    {
        return await _flightSearchService.findFlights(origin, destination, departureDate);
    }
}
