using Dapr.Actors;
using FlightSelect.Models;

namespace FlightSelect.Actors;

public interface IAirlineSessionActor : IActor
{
    Task<BookFlightPayload> GetFlightFromSession();
    Task AddFlightToSession(BookFlightPayload payload);
}
