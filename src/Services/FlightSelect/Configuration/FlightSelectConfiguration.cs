// <copyright file="FlightSelectConfiguration.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

namespace FlightSelect.Configuration;

/// <summary>
/// Configuraton for the Flight Search populated from appsettings.
/// </summary>
public class FlightSelectConfiguration
{
    /// <summary>
    /// Gets or sets the FlightsDataPath.
    /// </summary>
    public string FlightsDataPath { get; set; } = string.Empty;
}
