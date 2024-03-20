using Dapr.Actors.Runtime;
using FlightSelect.Models;

namespace FlightSelect.Actors;

public class AirlineSessionActor : Actor, IAirlineSessionActor
{
    public AirlineSessionActor(ActorHost host)
        : base(host)
    {
    }

    public Task AddFlightToSession(BookFlightPayload payload)
    {
        throw new NotImplementedException();
    }

    public Task<BookFlightPayload> GetFlightFromSession()
    {
        throw new NotImplementedException();
    }
}
