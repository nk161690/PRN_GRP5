using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group5.Models;
using Microsoft.AspNetCore.Http;

namespace Group5.Controllers
{
    public class BookingsController : Controller
    {
        private readonly CinemaContext _context;

        public BookingsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index(int id)
        {
            var cinemaContext = _context.Shows
                .Include(s => s.Film)
                .Include(s => s.Room);
            var show = await _context.Shows
                .FirstOrDefaultAsync(s => s.ShowId == id);
            ViewData["show"] = show;
            ViewData["bookings"] = await _context.Bookings
                .Where(b => b.ShowId == show.ShowId).
                ToListAsync();
            ViewData["room"] = await _context.Rooms
                .FirstOrDefaultAsync(r => r.RoomId == show.RoomId);
            return View();
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(m => m.BookingId == id);
            var show = await _context.Shows
                .FirstOrDefaultAsync(s => s.ShowId == booking.ShowId);
            ViewData["show"] = show;
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["bookings"] = booking;
            ViewData["room"] = await _context.Rooms
                .FirstOrDefaultAsync(r => r.RoomId == show.RoomId);
            return View(booking);
        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create(int id)
        {
            var cinemaContext = _context.Shows
                .Include(s => s.Film)
                .Include(s => s.Room);
            var show = await _context.Shows
                .FirstOrDefaultAsync(s => s.ShowId == id);
            ViewData["show"] = show;
            ViewData["bookings"] = await _context.Bookings
                .Where(b => b.ShowId == show.ShowId).
                ToListAsync();
            ViewData["room"] = await _context.Rooms
                .FirstOrDefaultAsync(r => r.RoomId == show.RoomId);
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,Name,SeatStatus,Amount")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Bookings", new { id = booking.ShowId });
            }
            return Redirect("/Bookings/Index/55");
        }

        // GET: Bookings/Edit/5
         public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
<<<<<<< Updated upstream

            var booking = await _context.Bookings.FindAsync(id);
            var show = await _context.Shows
               .FirstOrDefaultAsync(s => s.ShowId == booking.ShowId);
            ViewData["show"] = show;
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["bookings"] = booking;
            ViewData["room"] = await _context.Rooms
                .FirstOrDefaultAsync(r => r.RoomId == show.RoomId);
            return View(booking);
=======
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.BookingId == id);
            var show = await _context.Shows
                .FirstOrDefaultAsync(s => s.ShowId == booking.ShowId);
            ViewData["booking"] = await _context.Bookings.FindAsync(id);
            ViewData["bookings"] = await _context.Bookings.Where(b => b.BookingId != id).ToListAsync();
            ViewData["room"] = await _context.Rooms
                .FirstOrDefaultAsync(r => r.RoomId == show.RoomId);
            ViewData["show"] = show;
            return View();
>>>>>>> Stashed changes
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,ShowId,Name,SeatStatus,Amount")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                     return RedirectToAction("Index", "Bookings", new { id = booking.ShowId });
                 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Bookings", new { id = booking.ShowId });
            }
<<<<<<< Updated upstream
            //return View(booking);
            return RedirectToAction("Index", "Bookings", new { id = booking.ShowId });
=======
            return View();
>>>>>>> Stashed changes
        }
        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Bookings", new { id = booking.ShowId });
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
         return RedirectToAction("Index", "Bookings", new { id = booking.ShowId });
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
