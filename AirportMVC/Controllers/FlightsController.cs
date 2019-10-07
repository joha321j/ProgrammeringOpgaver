using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirportMVC.Models;
using AirportMVC.Services;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace AirportMVC.Controllers
{
    public class FlightsController : Controller
    {
        private readonly AirportMVCContext _context;
        private readonly ILogger<FlightsController> _logger;
        private readonly IMailService _mailService;

        public FlightsController(AirportMVCContext context, ILogger<FlightsController> logger, IMailService mailService)
        {
            _context = context;
            _logger = logger;
            _mailService = mailService;
        }

        // GET: Flights
        public async Task<IActionResult> Index(string fromLocationSearchString, string toLocationSearchString)
        {
            Response.StatusCode = (int) HttpStatusCode.OK;

            var flights = from f in _context.Flight
                select f;
            if (!string.IsNullOrEmpty(fromLocationSearchString))
            {
                flights = flights.Where(f => f.FromLocation.Contains(fromLocationSearchString));
            }

            if (!string.IsNullOrEmpty(toLocationSearchString))
            {
                flights = flights.Where(f => f.ToLocation.Contains(toLocationSearchString));
            }

            var flightVm = new FlightViewModel
            {
                Flights = await flights.ToListAsync()
            };

            return View(flightVm);
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = (int) HttpStatusCode.NotFound;
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }

            Response.StatusCode = (int) HttpStatusCode.OK;
            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            Response.StatusCode = (int) HttpStatusCode.OK;
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,AircraftType,FromLocation,ToLocation,DepartureTime,ArrivalTime")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var image in files)
                {
                    if (image != null && image.Length > 0)
                    {
                        var file = image;
                        var uploads = Path.Combine("wwwroot/images/", file.FileName);

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName
                                .ToString().Trim('"');

                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                flight.ImageName = file.FileName;
                            }

                        }
                    }
                }
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            Response.StatusCode = (int) HttpStatusCode.Created;
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }

            var flight = await _context.Flight.FindAsync(id);
            if (flight == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }

            Response.StatusCode = (int)HttpStatusCode.OK;
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("FlightId,AircraftType,FromLocation,ToLocation,DepartureTime,ArrivalTime, RowVersion")]
            Flight flight)
        {
            if (id != flight.FlightId)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var tempFlight = await _context.Flight.FindAsync(id);
                    if (tempFlight.RowVersion == flight.RowVersion)
                    {
                        string loggingString = "Flight with ID " + flight.FlightId + ", has been changed at " +
                                               DateTime.Now;

                        _logger.LogInformation(loggingString);

                        _context.Update(flight);

                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        throw new DbUpdateConcurrencyException(
                            "Someone else updated the model, whilst you were updating. Try again fucker.", new List<IUpdateEntry>());
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightId))
                    {
                        Response.StatusCode = (int)HttpStatusCode.NotFound;
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                Response.StatusCode = (int)HttpStatusCode.Found;
                return RedirectToAction(nameof(Index));
            }

            Response.StatusCode = (int) HttpStatusCode.OK;
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.FlightId == id);

            if (flight == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }

            Response.StatusCode = (int) HttpStatusCode.OK;
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, byte[] rowVersion)
        {
            var flight = await _context.Flight.FindAsync(id);

            if (flight.RowVersion == rowVersion)
            {

                string email = "kaare@mike.hf";
                string subject = "Flight has been cancelled";
                string mailBody =
                    "Yo fuckface, your flight has been cancelled. Russia tried to access our website, so we burned it all down.";

                _mailService.SendEmail(email, subject, mailBody);
                _context.Flight.Remove(flight);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new DBConcurrencyException("Flight has already been deleted.");
            }
            
            Response.StatusCode = (int) HttpStatusCode.Found;

            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.FlightId == id);
        }
    }
}
