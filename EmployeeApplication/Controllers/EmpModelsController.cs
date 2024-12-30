using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeApplication;
using EmployeeApplication.Models;

namespace EmployeeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpModelsController : ControllerBase
    {
        private readonly EmpDbcontext _context;

        public EmpModelsController(EmpDbcontext context)
        {
            _context = context;
        }

        // GET: api/EmpModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpModel>>> GetpetAnimals()
        {
            return await _context.petAnimals.ToListAsync();
        }

        // GET: api/EmpModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpModel>> GetEmpModel(int id)
        {
            var empModel = await _context.petAnimals.FindAsync(id);

            if (empModel == null)
            {
                return NotFound();
            }

            return empModel;
        }

        // PUT: api/EmpModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpModel(int id, EmpModel empModel)
        {
            if (id != empModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(empModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmpModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpModel>> PostEmpModel(EmpModel empModel)
        {
            _context.petAnimals.Add(empModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpModel", new { id = empModel.Id }, empModel);
        }

        // DELETE: api/EmpModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpModel(int id)
        {
            var empModel = await _context.petAnimals.FindAsync(id);
            if (empModel == null)
            {
                return NotFound();
            }

            _context.petAnimals.Remove(empModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpModelExists(int id)
        {
            return _context.petAnimals.Any(e => e.Id == id);
        }
    }
}
