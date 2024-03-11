// <copyright file="FlightsDaoTests.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSearch.Configuration;
using FlightSearch.Repositories;

namespace FlightSearch.Tests.Repositories;

/// <summary>
/// Test for the FlightsDao.
/// </summary>
public class FlightsDaoTests
{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    /// <summary>
    /// Constructor test.
    /// </summary>
    [Fact]
    public void ShouldThrowException_WhenConstructorIsCalledWithoutConfig()
    {
        // Arrange, Act, and Assert
        Assert.Throws<ArgumentNullException>(() => { new FlightsDao(null); });
    }

    /// <summary>
    /// Tests GetAll method.
    /// </summary>
    /// <returns>Task.</returns>
    [Fact]
    public async Task ShouldReturnAllData_WhenGetAllIsCalled()
    {
        // Arrange
        var config = new FlightSearchConfiguration
        {
            FlightsDataPath = "Data/Flights.json",
        };
        var flightsDao = new FlightsDao(config);

        // Act
        var result = await flightsDao.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Count() == 6);
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}
