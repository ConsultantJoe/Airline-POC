// <copyright file="BookFlightPayload.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

namespace FlightSelect.Models;

/// <summary>
/// Payload for a flight search.
/// </summary>
public class BookFlightPayload
{
    /// <summary>
    /// Gets or Sets the Flight Id.
    /// </summary>
    public Guid FlightId { get; set; } = Guid.Empty;

    /// <summary>
    /// Gets or sets the Flight Number.
    /// </summary>
    public string FlightNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Origin Airport.
    /// </summary>
    public string Origin { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Destination Airport.
    /// </summary>
    public string Destination { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Origin Departure Time.
    /// </summary>
    public DateTime DepartureTime { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Gets or sets the Arrivalo Time.
    /// </summary>
    public DateTime ArrivalTime { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Gets or sets the Fare Price.
    /// </summary>
    public decimal Price { get; set; } = 0m;
}
