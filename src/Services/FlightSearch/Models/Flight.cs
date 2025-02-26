// <copyright file="FlightSearchPayload.cs" company="Consultant Joes Inc">
// Copyright (c) Consultant Joes Inc. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSearch.Models;

/// <summary>
/// Payload for a flight search.
/// </summary>
public record Flight
{
    /// <summary>
    /// Gets the Flight Id.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FlightId { get; init; }

    /// <summary>
    /// Gets the Flight Number.
    /// </summary>
    public string FlightNumber { get; init; } = string.Empty;

    /// <summary>
    /// Gets the Origin Airport.
    /// </summary>
    public string Origin { get; init; } = string.Empty;

    /// <summary>
    /// Gets the Destination Airport.
    /// </summary>
    public string Destination { get; init; } = string.Empty;

    /// <summary>
    /// Gets the Origin Departure Time.
    /// </summary>
    public DateTime DepartureTime { get; init; }

    /// <summary>
    /// Gets the Arrivalo Time.
    /// </summary>
    public DateTime ArrivalTime { get; init; }

    /// <summary>
    /// Gets the Fare Price.
    /// </summary>
    public decimal Price { get; init; }
}
