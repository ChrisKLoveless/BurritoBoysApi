using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BurritoBoysApi.Models;

namespace BurritoBoysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly BurritoBoysApiContext _db;
        public RatingController(BurritoBoysApiContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetRating(int id)
        {
            Rating rating = await _db.Ratings.FindAsync(id);

            if (rating == null)
            {
                return NotFound();
            }

            return rating;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> Get(string rate)
        {
            IQueryable<Rating> query = _db.Ratings.AsQueryable();

            if (rate != null)
            {
                query = query.Where(rating => rating.Rate == rate);
            }

            return await query.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Rating>> Post(Rating rating)
        {
            _db.Ratings.Add(rating);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRating), new { id = rating.RatingId }, rating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Rating rating)
        {
            if (id != rating.RatingId)
            {
                return BadRequest();
            }
            _db.Ratings.Update(rating);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
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

        private bool RatingExists(int id)
        {
            return _db.Ratings.Any(e => e.RatingId == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Rating thisRating = await _db.Ratings
                .FirstOrDefaultAsync(rating => rating.RatingId == id);
            if (thisRating == null)
            {
                return NotFound();
            }
            _db.Ratings.Remove(thisRating);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}