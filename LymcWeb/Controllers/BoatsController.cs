using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LymcWeb.Data;
using LymcWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace LymcWeb.Controllers
{
    [Authorize(Policy = "AllRoles")]
    public class BoatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Boats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Boat.Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Boats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boat
                .Include(b => b.User)
                .SingleOrDefaultAsync(m => m.BoatId == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        [Authorize(Policy = "RequireAdminRole")]
        // GET: Boats/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Boats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Create([Bind("BoatId,BoatName,Picture,LengthInFeet,Make,Year,RecordCreationDate,CreatedBy")] Boat boat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id", boat.CreatedBy);
            return View(boat);
        }

        [Authorize(Policy = "RequireAdminRole")]
        // GET: Boats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boat.SingleOrDefaultAsync(m => m.BoatId == id);
            if (boat == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id", boat.CreatedBy);
            return View(boat);
        }

        // POST: Boats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Edit(int id, [Bind("BoatId,BoatName,Picture,LengthInFeet,Make,Year,RecordCreationDate,CreatedBy")] Boat boat)
        {
            if (id != boat.BoatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoatExists(boat.BoatId))
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
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id", boat.CreatedBy);
            return View(boat);
        }

        [Authorize(Policy = "RequireAdminRole")]
        // GET: Boats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boat
                .Include(b => b.User)
                .SingleOrDefaultAsync(m => m.BoatId == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // POST: Boats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boat = await _context.Boat.SingleOrDefaultAsync(m => m.BoatId == id);
            _context.Boat.Remove(boat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoatExists(int id)
        {
            return _context.Boat.Any(e => e.BoatId == id);
        }
    }
}
