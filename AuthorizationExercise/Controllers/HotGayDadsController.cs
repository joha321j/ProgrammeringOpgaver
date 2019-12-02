using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthorizationExercise.Data;
using AuthorizationExercise.Models;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationExercise.Controllers
{
    
    [Authorize(Policy = "Legal")]
    public class HotGayDadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotGayDadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HotGayDad
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotGayDads.ToListAsync());
        }

        // GET: HotGayDad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotGayDads = await _context.HotGayDads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotGayDads == null)
            {
                return NotFound();
            }

            return View(hotGayDads);
        }

        // GET: HotGayDad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotGayDad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNumber,Rate")] HotGayDad hotGayDad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotGayDad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotGayDad);
        }

        // GET: HotGayDad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotGayDads = await _context.HotGayDads.FindAsync(id);
            if (hotGayDads == null)
            {
                return NotFound();
            }
            return View(hotGayDads);
        }

        // POST: HotGayDad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber,Rate")] HotGayDad hotGayDad)
        {
            if (id != hotGayDad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotGayDad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotGayDadsExists(hotGayDad.Id))
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
            return View(hotGayDad);
        }

        // GET: HotGayDad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotGayDads = await _context.HotGayDads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotGayDads == null)
            {
                return NotFound();
            }

            return View(hotGayDads);
        }

        // POST: HotGayDad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotGayDads = await _context.HotGayDads.FindAsync(id);
            _context.HotGayDads.Remove(hotGayDads);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotGayDadsExists(int id)
        {
            return _context.HotGayDads.Any(e => e.Id == id);
        }

        [Authorize(Policy = "SickCunt")]
        public async Task<IActionResult> Book(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotGayDads = await _context.HotGayDads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotGayDads == null)
            {
                return NotFound();
            }

            return View(hotGayDads);
        }

        // POST: HotGayDad/Delete/5
        [HttpPost, ActionName("Book")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookConfirmed(int id)
        { 
            return RedirectToAction(nameof(Index));
        }
    }
}
