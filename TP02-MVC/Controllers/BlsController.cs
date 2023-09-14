using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP02_MVC.Data;
using TP02_MVC.Models;

namespace TP02_MVC.Controllers
{
    public class BlsController : Controller
    {
        private readonly Context _context;

        public BlsController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return View(await _context.Bls.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bls == null)
            {
                return NotFound();
            }

            var bl = await _context.Bls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bl == null)
            {
                return NotFound();
            }

            return View(bl);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Consignee,Ship")] Bl bl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bl);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bls == null)
            {
                return NotFound();
            }

            var bl = await _context.Bls.FindAsync(id);
            if (bl == null)
            {
                return NotFound();
            }
            return View(bl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Consignee,Ship")] Bl bl)
        {
            if (id != bl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlExists(bl.Id))
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
            return View(bl);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bls == null)
            {
                return NotFound();
            }

            var bl = await _context.Bls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bl == null)
            {
                return NotFound();
            }

            return View(bl);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bls == null)
            {
                return Problem("Entity set 'Context.Bls'  is null.");
            }
            var bl = await _context.Bls.FindAsync(id);
            if (bl != null)
            {
                _context.Bls.Remove(bl);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlExists(int id)
        {
          return _context.Bls.Any(e => e.Id == id);
        }
    }
}
