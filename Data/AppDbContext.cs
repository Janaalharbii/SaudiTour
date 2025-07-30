using Microsoft.EntityFrameworkCore;
using SaudiTour.Models;

namespace SaudiTour.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }


    public DbSet<Trip> Trips { get; set; }
    public DbSet<TripProvider> TripProviders { get; set; }
    public DbSet<TripType> TripTypes { get; set; }
    public DbSet<Booking> bookings { get; set; }    
  

}