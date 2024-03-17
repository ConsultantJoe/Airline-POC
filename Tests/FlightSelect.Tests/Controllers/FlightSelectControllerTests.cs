// <copyright file="FlightSelectControllerTests.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSelect.Controllers;
using FlightSelect.Services;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace FlightSelect.Tests;

/// <summary>
/// Test class for testing the FlightSelectController.
/// </summary>
public class FlightSelectControllerTests
{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    /// <summary>
    /// Tests the ILogger missing in the constructor.
    /// </summary>
    [Fact]
    public void ConstructorShouldThrowError_WhenILoggerIsNull()
    {
        // Arrange, Act, and Assert
       Assert.Throws<ArgumentNullException>(() => { new FlightSelectController(null, Substitute.For<IFlightSelectService>()); });
    }

    /// <summary>
    /// Tests the IFlightSearchService missing in the constructor.
    /// </summary>
    [Fact]
    public void ConstructorShouldThrowError_WhenIFlightSearchServiceIsNull()
    {
        // Arrange, Act, and Assert
        Assert.Throws<ArgumentNullException>(() => { new FlightSelectController(Substitute.For<ILogger<FlightSelectController>>(), null); });
    }

    /// <summary>
    /// Tests the controllers Get method.
    /// </summary>
    /// <returns>A Empty Task.</returns>
    [Fact]
    public async Task PostShouldReturnPayload_WhenCorrectParametersArePassed()
    {
        // Arrange
        var searchService = Substitute.For<IFlightSelectService>();
        searchService.BookFlight(Guid.Empty)
            .ReturnsForAnyArgs(Task.FromResult(FlightSelectHelper.GetBookFlightPayload()));

        var controller = new FlightSelectController(Substitute.For<ILogger<FlightSelectController>>(), searchService);

        // Act
        var result = await controller.Post(new Guid("2fc3f906-3dc2-4c17-bf0d-ec5533c5a2af"));

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}