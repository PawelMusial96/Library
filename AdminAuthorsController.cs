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
    public class AdminAuthorsController : Controller
    {
        private readonly ProjectLibraryDBContext _context;

        public AdminAuthorsController(ProjectLibraryDBContext context)
        {
            _context = context;
        }

        // GET: AdminAuthors
        public async Task<IActionResult> Index()
        {
              return View(await _context.AdminAuthor.ToListAsync());
        }

        // GET: AdminAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminAuthor == null)
            {
                return NotFound();
            }

            var adminAuthor = await _context.AdminAuthor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminAuthor == null)
            {
                return NotFound();
            }

            return View(adminAuthor);
        }

        // GET: AdminAuthors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname")] AdminAuthor adminAuthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminAuthor);
        }

        // GET: AdminAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminAuthor == null)
            {
                return NotFound();
            }

            var adminAuthor = await _context.AdminAuthor.FindAsync(id);
            if (adminAuthor == null)
            {
                return NotFound();
            }
            return View(adminAuthor);
        }

        // POST: AdminAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname")] AdminAuthor adminAuthor)
        {
            if (id != adminAuthor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminAuthorExists(adminAuthor.Id))
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
            return View(adminAuthor);
        }

        // GET: AdminAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminAuthor == null)
            {
                return NotFound();
            }

            var adminAuthor = await _context.AdminAuthor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminAuthor == null)
            {
                return NotFound();
            }

            return View(adminAuthor);
        }

        // POST: AdminAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminAuthor == null)
            {
                return Problem("Entity set 'ProjectLibraryDBContext.AdminAuthor'  is null.");
            }
            var adminAuthor = await _context.AdminAuthor.FindAsync(id);
            if (adminAuthor != null)
            {
                _context.AdminAuthor.Remove(adminAuthor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminAuthorExists(int id)
        {
          return _context.AdminAuthor.Any(e => e.Id == id);
        }
    }
}
