using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeManagement.Models;

namespace CoffeeManagement.Controllers
{
    public class TableCoffeesController : Controller
    {
        private readonly CoffeeManagementContext _context;

        public TableCoffeesController(CoffeeManagementContext context)
        {
            _context = context;
        }

        // GET: TableCoffees
        public async Task<IActionResult> Index()
        {
            ViewData["TableCoffee"] = await _context.TableCoffees.ToListAsync();
            ViewData["FoodCategory"] = new SelectList(_context.CategoryFoods, "Id", "Name");
            var food = await _context.Foods.Select(s => new
            {
                Id = s.Id,
                Item = string.Format("{0}-- VND{1}", s.Name, s.Price)
            }).ToListAsync();
            ViewData["Food"] = new SelectList(food, "Id", "Item");
            return View();
        }

        // GET: BookTable
        public async Task<IActionResult> Book(int id)
        {
            ViewData["id"] = id;
            ViewData["FoodCategory"] = new SelectList(_context.CategoryFoods, "Id", "Name");          
            return View();
        }

        public JsonResult GetFoodList(String Id)
        {
            List<Food> list = _context.Foods.Where(f => f.Id == int.Parse(Id)).ToList();   
            return Json(list);
        }

        // GET: TableCoffees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableCoffee = await _context.TableCoffees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableCoffee == null)
            {
                return NotFound();
            }

            return View(tableCoffee);
        }

        // GET: TableCoffees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableCoffees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status")] TableCoffee tableCoffee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableCoffee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableCoffee);
        }

        // GET: TableCoffees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableCoffee = await _context.TableCoffees.FindAsync(id);
            if (tableCoffee == null)
            {
                return NotFound();
            }
            return View(tableCoffee);
        }

        // POST: TableCoffees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status")] TableCoffee tableCoffee)
        {
            if (id != tableCoffee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableCoffee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableCoffeeExists(tableCoffee.Id))
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
            return View(tableCoffee);
        }

        // GET: TableCoffees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableCoffee = await _context.TableCoffees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableCoffee == null)
            {
                return NotFound();
            }

            return View(tableCoffee);
        }

        // POST: TableCoffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tableCoffee = await _context.TableCoffees.FindAsync(id);
            _context.TableCoffees.Remove(tableCoffee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableCoffeeExists(int id)
        {
            return _context.TableCoffees.Any(e => e.Id == id);
        }
    }
}
