using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiEF.Models;

namespace WebApplicationApiEF.Controllers
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
        public async Task<ActionResult<IEnumerable<PetAnimal>>> GetPetAnimals()
        {
            return await _context.petAnimals.ToListAsync();
        }

        // GET: api/PetAnimals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetAnimal>> GetPetAnimal(int id)
        {
            var petAnimal = await _context.petAnimals.FindAsync(id);

            if (petAnimal == null)
            {
                return NotFound();
            }

            return petAnimal;
        }

        // POST: api/PetAnimals
        [HttpPost]
        public async Task<ActionResult<PetAnimal>> PostPetAnimal(PetAnimal petAnimal)
        {
            // Log received data
            Console.WriteLine($"Received pet: {petAnimal.petName}, {petAnimal.petType}, {petAnimal.IsVeg}");

            _context.petAnimals.Add(petAnimal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetAnimal", new { id = petAnimal.petId }, petAnimal);
        }

        // PUT: api/PetAnimals/5
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

        // DELETE: api/PetAnimals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetAnimal(int id)
        {
            var petAnimal = await _context.petAnimals.FindAsync(id);
            if (petAnimal == null)
            {
                return NotFound();
            }

            _context.petAnimals.Remove(petAnimal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetAnimalExists(int id)
        {
            return _context.petAnimals.Any(e => e.petId == id);
        }
    }
}
