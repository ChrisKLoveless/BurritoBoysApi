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

        [HttpPost]
        public async Task<ActionResult<Spot>> Post(Spot spot)
        {
            _db.Spots.Add(spot);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSpot), new { id = spot.SpotId }, spot);
        }
    }
}