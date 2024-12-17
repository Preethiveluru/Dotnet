using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DMSWebApplication;
using DMSWebApplication.Models;

namespace DMSWebApplication.Controllers
{
    public class DMSController : Controller
    {
        private readonly DMSDbContext _context;

        public DMSController(DMSDbContext context)
        {
            _context = context;
        }

        // GET: DMS
        public async Task<IActionResult> Index()
        {
            return View(await _context.DMS.ToListAsync());
        }

        // GET: DMS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMS = await _context.DMS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dMS == null)
            {
                return NotFound();
            }

            return View(dMS);
        }

        // GET: DMS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DMS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Qualification,speciality")] DMS dMS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dMS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dMS);
        }

        // GET: DMS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMS = await _context.DMS.FindAsync(id);
            if (dMS == null)
            {
                return NotFound();
            }
            return View(dMS);
        }

        // POST: DMS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Qualification,speciality")] DMS dMS)
        {
            if (id != dMS.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dMS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DMSExists(dMS.Id))
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
            return View(dMS);
        }

        // GET: DMS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMS = await _context.DMS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dMS == null)
            {
                return NotFound();
            }

            return View(dMS);
        }

        // POST: DMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dMS = await _context.DMS.FindAsync(id);
            if (dMS != null)
            {
                _context.DMS.Remove(dMS);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DMSExists(int id)
        {
            return _context.DMS.Any(e => e.Id == id);
        }
    }
}
