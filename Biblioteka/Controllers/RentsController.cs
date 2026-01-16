using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Biblioteka.Data;
using Biblioteka.Models;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteka.Controllers
{
    [Authorize]
    public class RentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public RentsController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var rents = _context.Rents
                .Include(r => r.Library)
                .Include(r => r.User);

            return View(await rents.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var rent = await _context.Rents
                .Include(r => r.Library)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rent == null)
                return NotFound();

            return View(rent);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["LibraryId"] = new SelectList(_context.Libraries, "Id", "Id");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rent_Date,Return_Date,LibraryId")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                rent.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _context.Add(rent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["LibraryId"] = new SelectList(_context.Libraries, "Id", "Id", rent.LibraryId);
            return View(rent);
        }

        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var rent = await _context.Rents.FindAsync(id);
            if (rent == null)
                return NotFound();

            ViewData["LibraryId"] = new SelectList(_context.Libraries, "Id", "Id", rent.LibraryId);
            return View(rent);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rent_Date,Return_Date,LibraryId,UserId")] Rent rent)
        {
            if (id != rent.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(rent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["LibraryId"] = new SelectList(_context.Libraries, "Id", "Id", rent.LibraryId);
            return View(rent);
        }

        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var rent = await _context.Rents
                .Include(r => r.Library)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rent == null)
                return NotFound();

            return View(rent);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rent = await _context.Rents.FindAsync(id);
            if (rent != null)
            {
                _context.Rents.Remove(rent);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RentExists(int id)
        {
            return _context.Rents.Any(e => e.Id == id);
        }
    }
}
