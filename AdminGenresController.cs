using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Areas.Identity.Data;
using ProjectLibrary.Models;

namespace ProjectLibrary
{
    public class AdminGenresController : Controller
    {
        private readonly ProjectLibraryDBContext _context;

        public AdminGenresController(ProjectLibraryDBContext context)
        {
            _context = context;
        }

        // GET: AdminGenres
        public async Task<IActionResult> Index()
        {
            var projectLibraryDBContext = _context.AdminGenre.Include(a => a.AdminBook);
            return View(await projectLibraryDBContext.ToListAsync());
        }

        // GET: AdminGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminGenre == null)
            {
                return NotFound();
            }

            var adminGenre = await _context.AdminGenre
                .Include(a => a.AdminBook)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminGenre == null)
            {
                return NotFound();
            }

            return View(adminGenre);
        }

        // GET: AdminGenres/Create
        public IActionResult Create()
        {
            ViewData["AdminBookId"] = new SelectList(_context.AdminBook, "Id", "Id");
            return View();
        }

        // POST: AdminGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AdminBookId")] AdminGenre adminGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminBookId"] = new SelectList(_context.AdminBook, "Id", "Id", adminGenre.AdminBookId);
            return View(adminGenre);
        }

        // GET: AdminGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminGenre == null)
            {
                return NotFound();
            }

            var adminGenre = await _context.AdminGenre.FindAsync(id);
            if (adminGenre == null)
            {
                return NotFound();
            }
            ViewData["AdminBookId"] = new SelectList(_context.AdminBook, "Id", "Id", adminGenre.AdminBookId);
            return View(adminGenre);
        }

        // POST: AdminGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AdminBookId")] AdminGenre adminGenre)
        {
            if (id != adminGenre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminGenreExists(adminGenre.Id))
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
            ViewData["AdminBookId"] = new SelectList(_context.AdminBook, "Id", "Id", adminGenre.AdminBookId);
            return View(adminGenre);
        }

        // GET: AdminGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminGenre == null)
            {
                return NotFound();
            }

            var adminGenre = await _context.AdminGenre
                .Include(a => a.AdminBook)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminGenre == null)
            {
                return NotFound();
            }

            return View(adminGenre);
        }

        // POST: AdminGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminGenre == null)
            {
                return Problem("Entity set 'ProjectLibraryDBContext.AdminGenre'  is null.");
            }
            var adminGenre = await _context.AdminGenre.FindAsync(id);
            if (adminGenre != null)
            {
                _context.AdminGenre.Remove(adminGenre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminGenreExists(int id)
        {
          return _context.AdminGenre.Any(e => e.Id == id);
        }
    }
}
