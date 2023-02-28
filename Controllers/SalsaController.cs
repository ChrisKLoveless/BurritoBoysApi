using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BurritoBoysApi.Models;

namespace BurritoBoysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalsaController : ControllerBase
    {
        private readonly BurritoBoysApiContext _db;
        public SalsaController(BurritoBoysApiContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Salsa>> GetSalsa(int id)
        {
            Salsa salsa = await _db.Salsas.FindAsync(id);

            if (salsa == null)
            {
                return NotFound();
            }

            return salsa;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salsa>>> Get(string name)
        {
            IQueryable<Salsa> query = _db.Salsas.AsQueryable();

            if (name != null)
            {
                query = query.Where(salsa => salsa.Name == name);
            }

            return await query.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Salsa>> Post(Salsa salsa)
        {
            _db.Salsas.Add(salsa);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSalsa), new { id = salsa.SalsaId }, salsa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Salsa salsa)
        {
            if (id != salsa.SalsaId)
            {
                return BadRequest(new Error
                {
                    Code = "400",
                    Description = "BAD_REQUEST : id passed does not match SalsaId in updated salsa."
                });
            }
            _db.Salsas.Update(salsa);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalsaExists(id))
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

        private bool SalsaExists(int id)
        {
            return _db.Salsas.Any(e => e.SalsaId == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Salsa thisSalsa = await _db.Salsas
                .FirstOrDefaultAsync(salsa => salsa.SalsaId == id);
            if (thisSalsa == null)
            {
                return NotFound();
            }
            _db.Salsas.Remove(thisSalsa);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}