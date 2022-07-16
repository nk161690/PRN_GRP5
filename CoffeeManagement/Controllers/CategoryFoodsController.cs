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
    public class CategoryFoodsController : Controller
    {
        private readonly CoffeeManagementContext _context;

        public CategoryFoodsController(CoffeeManagementContext context)
        {
            _context = context;
        }

        // GET: CategoryFoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryFoods.ToListAsync());
        }

        // GET: CategoryFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryFood = await _context.CategoryFoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryFood == null)
            {
                return NotFound();
            }

            return View(categoryFood);
        }

        // GET: CategoryFoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryFoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CategoryFood categoryFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryFood);
        }

        // GET: CategoryFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryFood = await _context.CategoryFoods.FindAsync(id);
            if (categoryFood == null)
            {
                return NotFound();
            }
            return View(categoryFood);
        }

        // POST: CategoryFoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CategoryFood categoryFood)
        {
            if (id != categoryFood.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryFoodExists(categoryFood.Id))
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
            return View(categoryFood);
        }

        // GET: CategoryFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryFood = await _context.CategoryFoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryFood == null)
            {
                return NotFound();
            }

            return View(categoryFood);
        }

        // POST: CategoryFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryFood = await _context.CategoryFoods.FindAsync(id);
            _context.CategoryFoods.Remove(categoryFood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryFoodExists(int id)
        {
            return _context.CategoryFoods.Any(e => e.Id == id);
        }
    }
}
