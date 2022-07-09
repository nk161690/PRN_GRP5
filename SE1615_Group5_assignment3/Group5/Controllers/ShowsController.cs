using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group5.Models;

namespace Group5.Controllers
{
    public class ShowsController : Controller
    {
        private readonly CinemaContext _context;

        public ShowsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var cinemaContext = _context.Shows
                .Include(s => s.Film)
                .Include(s => s.Room);
            ViewData["shows"] = await cinemaContext.ToListAsync();
            Show show = new Show();
            show.ShowDate = DateTime.Now;
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name");
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title");
            return View(show);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Show show)
        {
            var cinemaContext = _context.Shows
                .Include(s => s.Film)
                .Include(s => s.Room);
            ViewData["shows"] = await cinemaContext
                .Where(s => s.ShowDate == show.ShowDate
                && s.RoomId == show.RoomId
                && s.FilmId == show.FilmId)
                .ToListAsync();
            show.ShowDate = DateTime.Now;
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", show.RoomId);
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title", show.FilmId);
            return View(show);
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["ShowDate"] = DateTime.Now;
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,RoomId,FilmId,ShowDate,Price,Status,Slot")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            bool[] slots = new bool[9];
            List<Show> shows = _context.Shows.
                    Where(s => s.RoomId == show.RoomId
                    && s.ShowDate == show.ShowDate
                    && s.ShowId != show.ShowId).ToList<Show>();
            foreach (Show s in shows)
                slots[(int)s.Slot - 1] = true;
            List<int> ls = new List<int>();
            for (int i = 0; i < slots.Length; i++)
                if (slots[i] == false) ls.Add(i + 1);
            int slot = (int)show.Slot;
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title", show.FilmId);
            ViewData["Slot"] = new SelectList(ls, slot);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowId,RoomId,FilmId,ShowDate,Price,Slot")] Show show)
        {
            if (id != show.ShowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.ShowId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.ShowId == id);
        }
    }
}
