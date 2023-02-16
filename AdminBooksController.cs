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
    public class AdminBooksController : Controller
    {
        private readonly ProjectLibraryDBContext _context;

        public AdminBooksController(ProjectLibraryDBContext context)
        {
            _context = context;
        }

        // GET: AdminBooks
        public async Task<IActionResult> Index()
        {
            var projectLibraryDBContext = _context.AdminBook.Include(a => a.AdminAuthor);
            return View(await projectLibraryDBContext.ToListAsync());
        }

        // GET: AdminBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminBook == null)
            {
                return NotFound();
            }

            var adminBook = await _context.AdminBook
                .Include(a => a.AdminAuthor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminBook == null)
            {
                return NotFound();
            }

            return View(adminBook);
        }

        // GET: AdminBooks/Create
        public IActionResult Create()
        {
            ViewData["AdminAuthorID"] = new SelectList(_context.Set<AdminAuthor>(), "Id", "Id");
            return View();
        }

        // POST: AdminBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,AdminAuthorID,GenreID,Opis,Date")] AdminBook adminBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminAuthorID"] = new SelectList(_context.Set<AdminAuthor>(), "Id", "Id", adminBook.AdminAuthorID);
            return View(adminBook);
        }

        // GET: AdminBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminBook == null)
            {
                return NotFound();
            }

            var adminBook = await _context.AdminBook.FindAsync(id);
            if (adminBook == null)
            {
                return NotFound();
            }
            ViewData["AdminAuthorID"] = new SelectList(_context.Set<AdminAuthor>(), "Id", "Id", adminBook.AdminAuthorID);
            return View(adminBook);
        }

        // POST: AdminBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,AdminAuthorID,GenreID,Opis,Date")] AdminBook adminBook)
        {
            if (id != adminBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminBookExists(adminBook.Id))
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
            ViewData["AdminAuthorID"] = new SelectList(_context.Set<AdminAuthor>(), "Id", "Id", adminBook.AdminAuthorID);
            return View(adminBook);
        }

        // GET: AdminBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminBook == null)
            {
                return NotFound();
            }

            var adminBook = await _context.AdminBook
                .Include(a => a.AdminAuthor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminBook == null)
            {
                return NotFound();
            }

            return View(adminBook);
        }

        // POST: AdminBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminBook == null)
            {
                return Problem("Entity set 'ProjectLibraryDBContext.AdminBook'  is null.");
            }
            var adminBook = await _context.AdminBook.FindAsync(id);
            if (adminBook != null)
            {
                _context.AdminBook.Remove(adminBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminBookExists(int id)
        {
          return _context.AdminBook.Any(e => e.Id == id);
        }
    }
}
