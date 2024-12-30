using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApplicationwebAPIEFwithmvc;
using webApplicationwebAPIEFwithmvc.Models;

namespace webApplicationwebAPIEFwithmvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetAnimalsController : ControllerBase
    {
        private readonly PetDBContext _context;

        public PetAnimalsController(PetDBContext context)
        {
            _context = context;
        }

        // GET: api/PetAnimals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetAnimal>>> GetPetAnimal()
        {
            return await _context.PetAnimal.ToListAsync();
        }

        // GET: api/PetAnimals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetAnimal>> GetPetAnimal(int id)
        {
            var petAnimal = await _context.PetAnimal.FindAsync(id);

            if (petAnimal == null)
            {
                return NotFound();
            }

            return petAnimal;
        }

        // PUT: api/PetAnimals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetAnimal(int id, PetAnimal petAnimal)
        {
            if (id != petAnimal.petId)
            {
                return BadRequest();
            }

            _context.Entry(petAnimal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetAnimalExists(id))
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

        // POST: api/PetAnimals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PetAnimal>> PostPetAnimal(PetAnimal petAnimal)
        {
            _context.PetAnimal.Add(petAnimal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetAnimal", new { id = petAnimal.petId }, petAnimal);
        }

        // DELETE: api/PetAnimals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetAnimal(int id)
        {
            var petAnimal = await _context.PetAnimal.FindAsync(id);
            if (petAnimal == null)
            {
                return NotFound();
            }

            _context.PetAnimal.Remove(petAnimal);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool PetAnimalExists(int id)
        {
            return _context.PetAnimal.Any(e => e.petId == id);
        }
    }
}
