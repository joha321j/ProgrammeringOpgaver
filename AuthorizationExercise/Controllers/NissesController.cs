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
using Microsoft.AspNetCore.Identity;

namespace AuthorizationExercise.Controllers
{
    public class NissesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        UserManager<IdentityUser> _userManager;

        public NissesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IAuthorizationService authorizationService)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        // GET: Nisses
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nisse.ToListAsync());
        }

        // GET: Nisses/Details/5
        [Authorize(Roles = "NoobNisse")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nisse = await _context.Nisse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nisse == null)
            {
                return NotFound();
            }

            return View(nisse);
        }

        [Authorize(Roles = "AdministratorNisse, ModeratorNisse")]
        // GET: Nisses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nisses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] Nisse nisse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nisse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nisse);
        }

        [Authorize(Roles = "AdministratorNisse, ModeratorNisse")]
        // GET: Nisses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nisse = await _context.Nisse.FindAsync(id);
            if (nisse == null)
            {
                return NotFound();
            }
            return View(nisse);
        }

        // POST: Nisses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdministratorNisse, ModeratorNisse")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] Nisse nisse)
        {
            if (id != nisse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nisse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NisseExists(nisse.Id))
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
            return View(nisse);
        }

        // GET: Nisses/Delete/5
        [Authorize(Roles = "AdministratorNisse")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nisse = await _context.Nisse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nisse == null)
            {
                return NotFound();
            }

            return View(nisse);
        }

        // POST: Nisses/Delete/5
        [Authorize(Roles = "AdministratorNisse")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nisse = await _context.Nisse.FindAsync(id);
            _context.Nisse.Remove(nisse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NisseExists(int id)
        {
            return _context.Nisse.Any(e => e.Id == id);
        }
    }
}
