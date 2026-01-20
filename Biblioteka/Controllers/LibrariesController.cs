using Biblioteka.Data;
using Biblioteka.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Controllers
{
    public class LibrariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Libraries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Libraries
                .Include(l => l.Address)
                .ToListAsync());
        }

        // GET: Libraries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var library = await _context.Libraries
                .Include(l => l.Address)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (library == null)
                return NotFound();

            return View(library);
        }

        // GET: Libraries/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "AddressLine");
            return View();
        }

        // POST: Libraries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Library library)
        {
            if (ModelState.IsValid)
            {
                _context.Add(library);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "AddressLine", library.AddressId);
            return View(library);
        }

        // GET: Libraries/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var library = await _context.Libraries.FindAsync(id);
            if (library == null)
                return NotFound();

            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "AddressLine", library.AddressId);
            return View(library);
        }

        // POST: Libraries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Library library)
        {
            if (id != library.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(library);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "AddressLine", library.AddressId);
            return View(library);
        }

        // GET: Libraries/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var library = await _context.Libraries
                .Include(l => l.Address)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (library == null)
                return NotFound();

            return View(library);
        }

        // POST: Libraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var library = await _context.Libraries.FindAsync(id);
            if (library != null)
                _context.Libraries.Remove(library);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}