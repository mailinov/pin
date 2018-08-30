using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class MarkasController : Controller
    {
        private readonly RentCarContext _context;

        public MarkasController(RentCarContext context)
        {
            _context = context;
        }

        // GET: Markas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marka.ToListAsync());
        }

        // GET: Markas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marka = await _context.Marka
                .SingleOrDefaultAsync(m => m.ID == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }

        // GET: Markas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Markas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,naziv")] Marka marka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marka);
        }

        // GET: Markas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marka = await _context.Marka.SingleOrDefaultAsync(m => m.ID == id);
            if (marka == null)
            {
                return NotFound();
            }
            return View(marka);
        }

        // POST: Markas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,naziv")] Marka marka)
        {
            if (id != marka.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkaExists(marka.ID))
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
            return View(marka);
        }

        // GET: Markas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marka = await _context.Marka
                .SingleOrDefaultAsync(m => m.ID == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }

        // POST: Markas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marka = await _context.Marka.SingleOrDefaultAsync(m => m.ID == id);
            _context.Marka.Remove(marka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkaExists(int id)
        {
            return _context.Marka.Any(e => e.ID == id);
        }
    }
}
