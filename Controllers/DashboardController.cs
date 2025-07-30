
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SaudiTour.Data;
using SaudiTour.Models;
namespace SaudiTour.Namespace
{
    public class DashboardController : Controller
    {

        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DashboardController
        public ActionResult Index()
        {
            return View();
        }

        //-------------- Trips ----------------//
        public IActionResult Trip()
        {
            var tripType = _context.TripTypes.ToList();
            ViewBag.tripType = tripType;

            var tripProvider = _context.TripProviders.ToList();
            ViewBag.tripProvider = tripProvider;

            var trips = _context.Trips.ToList();
            return View(trips);
        }



        [HttpPost]
        public IActionResult AddTrip(Trip trip, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                trip.Image = fileName;
            }

            _context.Trips.Add(trip);
            _context.SaveChanges();

            return RedirectToAction("Trip");
        }



        public IActionResult EditTrip(int id)
        {
            var tripProvider = _context.TripProviders.ToList();
            ViewBag.tripProvider = tripProvider;

            var TripType = _context.TripTypes.ToList();
            ViewBag.TripType = TripType;

            var Trip = _context.Trips.Find(id);

            return View(Trip);
        }

        public async Task<IActionResult> DeleteTrip(int id)
        {
            var Trip = await _context.Trips.FindAsync(id);

            if (Trip != null)
            {
                _context.Trips.Remove(Trip);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Trip");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTrip(Trip trips)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Trip);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Trip");
        }


        //-------------- Type Trips ----------------//
        public IActionResult TripType()
        {

            var TypeTrip = _context.TripTypes.ToList();
            return View(TypeTrip);
        }
 public async Task<IActionResult> AddTripType(TripType tripType)
        {
            ViewBag.Message = 0;
            if (ModelState.IsValid)
            {
                _context.TripTypes.Add(tripType);
                await _context.SaveChangesAsync();
                ViewBag.Message = 1;
            }

            return RedirectToAction("TripType");
        }

        public async Task<IActionResult> EditTypeTrip(TripType tripType)
        {
            if (ModelState.IsValid)
            {
                _context.TripTypes.Update(tripType);
                await _context.SaveChangesAsync();
                return RedirectToAction("TripType");
            }
            return View("EditTypeTrip", tripType);
        }

        public async Task<IActionResult> DeleteTypeTrip(int id)
        {
            var typ = await _context.TripTypes.FindAsync(id);
            if (typ != null)
            {
                _context.TripTypes.Remove(typ);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("TripType");
        }

        //-------------- Trips Provider ----------------//
        public IActionResult TripProvider()
        {

            var TripProvider = _context.TripProviders.ToList();
            return View(TripProvider);
        }

        public async Task<IActionResult> AddProvider(TripProvider provider)
        {
            if (ModelState.IsValid)
            {
                _context.TripProviders.Add(provider);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("TripProvider");
        }

        public async Task<IActionResult> EditProvider(TripProvider provider)
        {
            if (ModelState.IsValid)
            {
                _context.TripProviders.Update(provider);
                await _context.SaveChangesAsync();
                return RedirectToAction("TripProvider");
            }
            return View("EditTripProvider", provider);
        }

        public async Task<IActionResult> DeleteProvider(int id)
        {
            var prov = await _context.TripProviders.FindAsync(id);
            if (prov != null)
            {
                _context.TripProviders.Remove(prov);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("TripProvider");
        }

    
    }
}