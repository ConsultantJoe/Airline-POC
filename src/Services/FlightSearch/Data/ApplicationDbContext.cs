using FlightSearch.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightSearch.Data;

public sealed class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Flight> FlightSearchPayloads { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresServer"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Flight>().HasData(
            new Flight
            {
                FlightId = 1,
                FlightNumber = "AS123",
                Origin = "DEN",
                Destination = "JFK",
                DepartureTime = DateTime.Parse("2024-06-09T08:00:00").ToUniversalTime(),
                ArrivalTime = DateTime.Parse("2024-06-09T12:00:00").ToUniversalTime(),
                Price = 250.00m,
            },
            new Flight
            {
                FlightId = 2,
                FlightNumber = "AS456",
                Origin = "DEN",
                Destination = "ORD",
                DepartureTime = DateTime.Parse("2024-06-09T10:00:00").ToUniversalTime(),
                ArrivalTime = DateTime.Parse("2024-06-09T12:30:00").ToUniversalTime(),
                Price = 180.00m,
            },
            new Flight
            {
                FlightId = 3,
                FlightNumber = "AS789",
                Origin = "DEN",
                Destination = "LAX",
                DepartureTime = DateTime.Parse("2024-06-09T11:30:00").ToUniversalTime(),
                ArrivalTime = DateTime.Parse("2024-06-09T14:30:00").ToUniversalTime(),
                Price = 300.00m,
            },
            new Flight
            {
                FlightId = 4,
                FlightNumber = "AS234",
                Origin = "SEA",
                Destination = "SFO",
                DepartureTime = DateTime.Parse("2024-06-10T09:30:00").ToUniversalTime(),
                ArrivalTime = DateTime.Parse("2024-06-10T11:30:00").ToUniversalTime(),
                Price = 200.00m,
            },
            new Flight
            {
                FlightId = 5,
                FlightNumber = "AS567",
                Origin = "SEA",
                Destination = "DFW",
                DepartureTime = DateTime.Parse("2024-06-10T12:00:00").ToUniversalTime(),
                ArrivalTime = DateTime.Parse("2024-06-10T16:00:00").ToUniversalTime(),
                Price = 320.00m,
            },
            new Flight
            {
                FlightId = 6,
                FlightNumber = "AS890",
                Origin = "SEA",
                Destination = "MIA",
                DepartureTime = DateTime.Parse("2024-06-10T14:30:00").ToUniversalTime(),
                ArrivalTime = DateTime.Parse("2024-06-10T20:30:00").ToUniversalTime(),
                Price = 400.00m,
            }
        );
    }

}
