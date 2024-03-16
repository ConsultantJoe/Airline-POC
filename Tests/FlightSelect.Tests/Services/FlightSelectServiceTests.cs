// <copyright file="FlightSearchServiceTests.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSelect.Repositories;
using FlightSelect.Services;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace FlightSelect.Tests.Services;

/// <summary>
/// Tests for the FlightSearchService.
/// </summary>
public class FlightSelectServiceTests
{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    /// <summary>
    /// Tests the ILogger missing in the constructor.
    /// </summary>
    [Fact]
    public void ConstructorShouldThrowError_WhenILoggerIsNull()
    {
        // Arrange, Act, and Assert
        Assert.Throws<ArgumentNullException>(() => { new FlightSearchService(null, Substitute.For<IFlightsDao>()); });
    }

    /// <summary>
    /// Tests the IFlightsDao missing in the constructor.
    /// </summary>
    [Fact]
    public void ConstructorShouldThrowError_WhenIFlightSearchServiceIsNull()
    {
        // Arrange, Act, and Assert
        Assert.Throws<ArgumentNullException>(() => { new FlightSearchService(Substitute.For<ILogger<FlightSearchService>>(), null); });
    }

    /// <summary>
    /// Tests that a populated payload is returned if the correct values are passed in.
    /// </summary>
    /// <returns>A Empty Task.</returns>
    [Fact]
    public async Task FindFlightsShouldReturnPayload_WhenCorrectParametersArePassed()
    {
        // Arrange
        var flightsDao = Substitute.For<IFlightsDao>();
        flightsDao.GetAll()
            .Returns(Task.FromResult(FlightSelectHelper.GetFlightSearchPayload()));

        var service = new FlightSearchService(Substitute.For<ILogger<FlightSearchService>>(), flightsDao);

        // Act
        var flights = await service.FindFlights("DEN", "JFK");

        // Assert
        Assert.NotNull(flights);
        Assert.Single(flights);
    }

    /// <summary>
    /// Tests that a empty payload is returned if the correct values are passed in.
    /// </summary>
    /// <returns>A Empty Task.</returns>
    [Fact]
    public async Task FindFlightsShouldReturnEmptyPayload_WhenCorrectParametersArePassed()
    {
        // Arrange
        var flightsDao = Substitute.For<IFlightsDao>();
        flightsDao.GetAll()
            .Returns(Task.FromResult(FlightSelectHelper.GetFlightSearchPayload()));

        var service = new FlightSearchService(Substitute.For<ILogger<FlightSearchService>>(), flightsDao);

        // Act
        var flights = await service.FindFlights("DEN", "SEA");

        // Assert
        Assert.NotNull(flights);
        Assert.Empty(flights);
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}
