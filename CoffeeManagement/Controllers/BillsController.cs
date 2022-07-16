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
    public class BillsController : Controller
    {
        private readonly CoffeeManagementContext _context;

        public BillsController(CoffeeManagementContext context)
        {
            _context = context;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var coffeeManagementContext = _context.Bills.Include(b => b.Table);
            return View(await coffeeManagementContext.ToListAsync());
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .Include(b => b.Table)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        public IActionResult Create(int id)
        {
            ViewData["TableId"] = id;
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CheckIn,CheckOut,TableId,Discount,TotalPrice,Status")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TableId"] = new SelectList(_context.TableCoffees, "Id", "Name", bill.TableId);
            return View(bill);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            ViewData["TableId"] = new SelectList(_context.TableCoffees, "Id", "Name", bill.TableId);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , IFormCollection formCollection)
        {
            var discount = HttpContext.Request.Form["discount"].ToString();
            var name = HttpContext.Request.Form["name"].ToString();
            var Bcontext = _context.Bills.Include(b => b.Table).Include(b => b.BillInfos);
            var BFcontext = _context.BillInfos.Include(b => b.Food).Include(b => b.Bill);
            var bill = await Bcontext.FirstOrDefaultAsync(b => b.Table.Id == id);
            List<BillInfo> lbf = await BFcontext.Where(b => b.BillId == bill.Id).ToListAsync();
            int totalPrc = 0;
            foreach(var billInfo in lbf)
            {
                totalPrc += billInfo.Food.Price * billInfo.Amount;
            }
            bill.TotalPrice = totalPrc - (totalPrc * int.Parse(discount) / 100);
            bill.Status = 1;
            TableCoffee tableCoffee = await _context.TableCoffees.FirstOrDefaultAsync(t => t.Id == id);
            tableCoffee.Status = "Blank";
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "TableCoffees");
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .Include(b => b.Table)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillExists(int id)
        {
            return _context.Bills.Any(e => e.Id == id);
        }
    }
}
