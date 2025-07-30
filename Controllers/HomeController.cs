
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

using SaudiTour.Data;
using SaudiTour.Models;

namespace SaudiTour.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }


    public IActionResult AllTrips()
    {
        var tripType = _context.TripTypes.Take(3).ToList();
        ViewBag.tripType = tripType;

        var tripProvider = _context.TripProviders.ToList();
        ViewBag.tripProvider = tripProvider;

        var trips = _context.Trips.ToList();
        return View(trips);
    }

    [HttpPost]
    public IActionResult Booking(int id)
    {
        ViewBag.tripType = _context.TripTypes.ToList();
        ViewBag.tripProvider = _context.TripProviders.ToList();

        var trip = _context.Trips
            .Include(t => t.TripType)
            .Include(t => t.provider)
            .FirstOrDefault(t => t.Id == id);

        if (trip == null)
            return NotFound();

        return View(trip);
    }



   public IActionResult Index()
{
    var tripType = _context.TripTypes.Take(3).ToList();
    ViewBag.tripType = tripType;

    var tripProvider = _context.TripProviders.ToList();
    ViewBag.tripProvider = tripProvider;

   
    var trips = _context.Trips
        .OrderByDescending(t => t.Id) 
        .Take(3)
        .ToList();

    return View(trips);
}



   [HttpPost]
    public IActionResult Payment(int id)
    {
        ViewBag.tripType = _context.TripTypes.ToList();
        ViewBag.tripProvider = _context.TripProviders.ToList();

        var trip = _context.Trips
            .Include(t => t.TripType)
            .Include(t => t.provider)
            .FirstOrDefault(t => t.Id == id);

        if (trip == null)
            return NotFound();

        return View(trip);
    }


}
