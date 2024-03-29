﻿// <copyright file="FlightSearchConfiguration.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

namespace FlightSearch.Configuration;

/// <summary>
/// Configuraton for the Flight Search populated from appsettings.
/// </summary>
public class FlightSearchConfiguration
{
    /// <summary>
    /// Gets or sets the FlightsDataPath.
    /// </summary>
    public string FlightsDataPath { get; set; } = string.Empty;
}
