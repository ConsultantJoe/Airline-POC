// <copyright file="FlightSearchController.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSelect.Models;
using FlightSelect.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightSelect.Controllers;

/// <summary>
/// Controller class for the WeatherForcast.
/// </summary>
[ApiController]
[Route("[controller]")]
public class FlightSelectController : ControllerBase
{
    private readonly ILogger<FlightSelectController> _logger;
    private readonly IFlightSelectService _flightSelectService;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlightSelectController"/> class.
    /// </summary>
    /// <param name="logger">Logger that is wired up via DI.</param>
    /// <param name="flightSelectService">FlightSelectService that is wired up via DI.</param>
    /// <exception cref="ArgumentNullException">Thrown if a parameter is missing.</exception>
    public FlightSelectController(ILogger<FlightSelectController> logger, IFlightSelectService flightSelectService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _flightSelectService = flightSelectService ?? throw new ArgumentNullException(nameof(flightSelectService));
    }

    /// <summary>
    /// Find flights for a given set of parameters.
    /// </summary>
    /// <param name="origin">Origin airport to use in search.</param>
    /// <param name="destination">Destination airport to use in search.</param>
    /// <returns>List of Flight results.</returns>
    [HttpPost(Name = "BookFlight")]
    public async Task<IEnumerable<FlightSelectPayload>> Get(Guid flightId)
    {
        _logger.LogInformation("Getting Flights from the FlightSearchService");
        return await _flightSelectService.BookFlight(flightId);
    }
}
