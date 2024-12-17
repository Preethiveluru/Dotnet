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
    public class patientsController : Controller
    {
        private readonly DMSDbContext _context;

        public patientsController(DMSDbContext context)
        {
            _context = context;
        }

        // GET: patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        // GET: patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.PId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PId,PName,PDisease,specilaist,Id")] patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
               // return RedirectToAction(nameof(Index));
            }


            string PName = patient.PName;



            var Name = GetDocData(patient.specilaist).FirstOrDefault();

            TempData["Result"] = $"Welcome {PName}!! Your request has been recorded and DR.{Name} has been assigned to you.";


            return RedirectToAction("Index", "Home");
        }

        public List<Object> GetDocData(string spec)
        {
            var query = from patient in _context.Patients join doctor in _context.DMS on patient.Id equals doctor.Id where patient.specilaist == (spec) select doctor.Name;
            return query.ToList<Object>();
        }
        

        // GET: patients/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,PName,PDisease,specilaist,Id")] patient patient)
        {
            if (id != patient.PId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!patientExists(patient.PId))
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
            return View(patient);
        }

        // GET: patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.PId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool patientExists(int id)
        {
            return _context.Patients.Any(e => e.PId == id);
        }
    }
}
