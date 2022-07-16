using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeManagement.Models;
using Microsoft.AspNetCore.Http;

namespace CoffeeManagement.Controllers
{
    public class BillInfoesController : Controller
    {
        private readonly CoffeeManagementContext _context;

        public BillInfoesController(CoffeeManagementContext context)
        {
            _context = context;
        }

        // GET: BillInfoes
        public async Task<IActionResult> Index()
        {
            var coffeeManagementContext = _context.BillInfos.Include(b => b.Bill).Include(b => b.Food);
            return View(await coffeeManagementContext.ToListAsync());
        }

        // GET: BillInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billInfo = await _context.BillInfos
                .Include(b => b.Bill)
                .Include(b => b.Food)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billInfo == null)
            {
                return NotFound();
            }

            return View(billInfo);
        }

        // GET: BillInfoes/Create
        public IActionResult Create()
        {
            ViewData["BillId"] = new SelectList(_context.Bills, "Id", "Id");
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Name");
            return View();
        }

        // POST: BillInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BillId,FoodId,Amount")] BillInfo billInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillId"] = new SelectList(_context.Bills, "Id", "Id", billInfo.BillId);
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Name", billInfo.FoodId);
            return View(billInfo);
        }

        // GET: BillInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billInfo = await _context.BillInfos.FindAsync(id);
            if (billInfo == null)
            {
                return NotFound();
            }
            ViewData["BillId"] = new SelectList(_context.Bills, "Id", "Id", billInfo.BillId);
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Name", billInfo.FoodId);
            return View(billInfo);
        }

        // POST: BillInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormCollection formCollection)
        {
            var id = HttpContext.Request.Form["billId"].ToString();
            var tid = HttpContext.Request.Form["tableId"].ToString();
            var name = HttpContext.Request.Form["itemName"].ToString();
            var amount = HttpContext.Request.Form["amountEdit"].ToString();
            var item = await _context.BillInfos.FirstOrDefaultAsync(b => b.Id == int.Parse(id) && b.Food.Name == name);
            item.Amount = int.Parse(amount);
            await _context.SaveChangesAsync();
            return RedirectToAction("Book", "TableCoffees", new { id = tid });
        }

        // GET: BillInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billInfo = await _context.BillInfos
                .Include(b => b.Bill)
                .Include(b => b.Food)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billInfo == null)
            {
                return NotFound();
            }

            return View(billInfo);
        }

        // POST: BillInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(IFormCollection iformcollection)
        {
            var id = HttpContext.Request.Form["delBill"].ToString();
            var tid = HttpContext.Request.Form["tableId"].ToString();
            var name = HttpContext.Request.Form["delName"].ToString();
            var item = await _context.BillInfos.FirstOrDefaultAsync(b => b.Id == int.Parse(id) && b.Food.Name == name);
            _context.BillInfos.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Book", "TableCoffees", new { id = tid });
        }

        private bool BillInfoExists(int id)
        {
            return _context.BillInfos.Any(e => e.Id == id);
        }
    }
}
