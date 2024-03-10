// <copyright file="FlightSearchControllerTests.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using FlightSearch.Controllers;

namespace FlightSearch.Tests;

public class FlightSearchControllerTests
{
    [Fact]
    public void ConstructorShouldThrowError_WhenIloggerIsNull()
    {
        // Arrange, Act, and Assert
       Assert.Throws<ArgumentNullException>(() => { new FlightSearchController(null); });
    }

    [Fact]
    public void GetShouldReturnPayload_WhenCorrectParametersArePassed()
    {
    }
}