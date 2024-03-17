// <copyright file="FlightSelectServiceTests.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSelect.Repositories;
using FlightSelect.Services;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace FlightSelect.Tests.Services;

/// <summary>
/// Tests for the FlightSelectService.
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
        Assert.Throws<ArgumentNullException>(() => { new FlightSelectService(null, Substitute.For<IFlightsDao>()); });
    }

    /// <summary>
    /// Tests the IFlightsDao missing in the constructor.
    /// </summary>
    [Fact]
    public void ConstructorShouldThrowError_WhenIFlightSelectServiceIsNull()
    {
        // Arrange, Act, and Assert
        Assert.Throws<ArgumentNullException>(() => { new FlightSelectService(Substitute.For<ILogger<FlightSelectService>>(), null); });
    }

    /// <summary>
    /// Tests that a populated payload is returned if the correct values are passed in.
    /// </summary>
    /// <returns>A Empty Task.</returns>
    [Fact]
    public async Task BookFlightShouldReturnPayload_WhenCorrectParametersArePassed()
    {
        // Arrange
        var flightsDao = Substitute.For<IFlightsDao>();
        flightsDao.GetAll()
            .Returns(Task.FromResult(FlightSelectHelper.GetBookFlightPayload()));

        var service = new FlightSelectService(Substitute.For<ILogger<FlightSelectService>>(), flightsDao);

        // Act
        var flights = await service.BookFlight(new Guid("2fc3f906-3dc2-4c17-bf0d-ec5533c5a2af"));

        // Assert
        Assert.NotNull(flights);
        Assert.Single(flights);
    }

    /// <summary>
    /// Tests that a empty payload is returned if the correct values are passed in.
    /// </summary>
    /// <returns>A Empty Task.</returns>
    [Fact]
    public async Task BookFlightShouldReturnEmptyPayload_WhenCorrectParametersArePassed()
    {
        // Arrange
        var flightsDao = Substitute.For<IFlightsDao>();
        flightsDao.GetAll()
            .Returns(Task.FromResult(FlightSelectHelper.GetBookFlightPayload()));

        var service = new FlightSelectService(Substitute.For<ILogger<FlightSelectService>>(), flightsDao);

        // Act
        var flights = await service.BookFlight(new Guid("77ea4269-ff8b-42ff-a8c5-92e399270dbc"));

        // Assert
        Assert.NotNull(flights);
        Assert.Empty(flights);
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}
