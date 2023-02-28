using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BurritoBoysApi.Models;

namespace BurritoBoysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotController : ControllerBase
    {
        private readonly BurritoBoysApiContext _db;
        public SpotController(BurritoBoysApiContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Spot>> GetSpot(int id)
        {
            Spot spot = await _db.Spots.FindAsync(id);

            if (spot == null)
            {
                return NotFound();
            }

            return spot;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spot>>> Get(string name, string city, string state)
        {
            IQueryable<Spot> query = _db.Spots.AsQueryable();

            if (name != null)
            {
                query = query.Where(spot => spot.Name == name);
            }
            if (city != null)
            {
                query = query.Where(spot => spot.City == city);
            }
            if (state != null)
            {
                query = query.Where(spot => spot.State == state);
            }

            return await query.Include(spot => spot.Ratings)
                                .Include(spot => spot.Salsas).ToListAsync();
        }

        [HttpGet("gettop/{amount}")]
        public async Task<ActionResult<IEnumerable<Spot>>> GetTop(int amount)
        {
            List<Spot> spots = _db.Spots
                .OrderByDescending(spot => spot.AverageRating)
                .Take(amount)
                .ToList();
            return spots;
        }

        [HttpPost]
        public async Task<ActionResult<Spot>> Post(Spot spot)
        {
            if (spot.Ratings != null || spot.Salsas != null)
            {
                return BadRequest();
            }
            _db.Spots.Add(spot);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSpot), new { id = spot.SpotId }, spot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Spot spot)
        {
            if (id != spot.SpotId)
            {
                return BadRequest();
            }
            _db.Spots.Update(spot);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpotExists(id))
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

        private bool SpotExists(int id)
        {
            return _db.Spots.Any(e => e.SpotId == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Spot thisSpot = await _db.Spots
                .FirstOrDefaultAsync(spot => spot.SpotId == id);
            if (thisSpot == null)
            {
                return NotFound();
            }
            _db.Spots.Remove(thisSpot);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}