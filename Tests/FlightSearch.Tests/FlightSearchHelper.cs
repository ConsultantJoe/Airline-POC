using FlightSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearch.Tests;
public static class FlightSearchHelper
{
    /// <summary>
    /// Gets a FlightSearchPayload for unit testing.
    /// </summary>
    /// <returns>A populated FlightSearchPayload.</returns>
    public static IEnumerable<FlightSearchPayload> GetFlightSearchPayload() =>
        new List<FlightSearchPayload>
        {
            new FlightSearchPayload
            {
                ArrivalTime = DateTime.Now,
                DepartureTime = DateTime.Now.AddHours(-4),
                Origin = "DEN",
                Destination = "JFK",
                Price = 400.00m,
                FlightId = Guid.NewGuid(),
                FlightNumber = "AS450",
            },
        };

}
