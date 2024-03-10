// <copyright file="FlightSearchControllerTests.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSearch.Controllers;
using FlightSearch.Services;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace FlightSearch.Tests;

/// <summary>
/// Test class for testing the FlightSearchController.
/// </summary>
public class FlightSearchControllerTests
{
    /// <summary>
    /// Tests the ILogger in the constructor.
    /// </summary>
    [Fact]
    public void ConstructorShouldThrowError_WhenILoggerIsNull()
    {
        // Arrange, Act, and Assert
       Assert.Throws<ArgumentNullException>(() => { new FlightSearchController(null, Substitute.For<IFlightSearchService>()); });
    }

    /// <summary>
    /// Tests the IFlightSearchService in the constructor.
    /// </summary>
    [Fact]
    public void ConstructorShouldThrowError_WhenIFlightSearchServiceIsNull()
    {
        // Arrange, Act, and Assert
        Assert.Throws<ArgumentNullException>(() => { new FlightSearchController(Substitute.For<ILogger<FlightSearchController>>(), null); });
    }

    /// <summary>
    /// Tests the controllers Get method.
    /// </summary>
    /// <returns>A Empty Task.</returns>
    [Fact]
    public async Task GetShouldReturnPayload_WhenCorrectParametersArePassed()
    {
        // Arrange
        var searchService = Substitute.For<IFlightSearchService>();
        searchService.findFlights(string.Empty, string.Empty, default)
            .ReturnsForAnyArgs(Task.FromResult(FlightSearchHelper.GetFlightSearchPayload()));

        var controller = new FlightSearchController(Substitute.For<ILogger<FlightSearchController>>(), searchService);

        // Act
        var result = await controller.Get("DEN", "JFK", DateTime.Parse("2024-06-09"));

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}