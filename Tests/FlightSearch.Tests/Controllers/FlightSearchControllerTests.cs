// <copyright file="FlightSearchControllerTests.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSearch.Controllers;
using FlightSearch.Services;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace FlightSearch.Tests;

/// <summary>
/// Test class for testing the FlightSearchController.
/// </summary>
public class FlightSearchControllerTests
{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    /// <summary>
    /// Tests the ILogger missing in the constructor.
    /// </summary>
    [Fact]
    public void ConstructorShouldThrowError_WhenILoggerIsNull()
    {
        // Arrange, Act, and Assert
       Assert.Throws<ArgumentNullException>(() => { new FlightSearchController(null, Substitute.For<IFlightSearchService>()); });
    }

    /// <summary>
    /// Tests the IFlightSearchService missing in the constructor.
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
        searchService.FindFlights(string.Empty, string.Empty)
            .ReturnsForAnyArgs(Task.FromResult(FlightSearchHelper.GetFlightSearchPayload()));

        var controller = new FlightSearchController(Substitute.For<ILogger<FlightSearchController>>(), searchService);

        // Act
        var result = await controller.Get("DEN", "JFK");

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}