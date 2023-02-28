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
        public async Task<ActionResult<IEnumerable<Rating>>> Get()
        {
            IQueryable<Rating> query = _db.Ratings.AsQueryable();

            return await query.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Rating>> Post(Rating rating)
        {
            if (rating.Rate < 0 || rating.Rate > 5)
            {
                return BadRequest(new Error
                {
                    Code = "400",
                    Description = "BAD_REQUEST : rate can only be a number between 0 and 5."
                });
            }

            _db.Ratings.Add(rating);

            List<Rating> ratings = _db.Ratings.Where(rate => rate.SpotId == rating.SpotId).ToList();
            ratings.Add(rating);
            double average = 0;
            ratings.ForEach(rate => {
                average += rate.Rate;
            });
            average = average / (double)ratings.Count();
            Console.WriteLine(average);

            Spot spot = await _db.Spots.FirstOrDefaultAsync(spot => spot.SpotId == rating.SpotId);
            spot.AverageRating = average;
            _db.Spots.Update(spot);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpotExists(spot.SpotId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        
            return CreatedAtAction(nameof(GetRating), new { id = rating.RatingId }, rating);
        }

        private bool SpotExists(int id)
        {
            return _db.Spots.Any(e => e.SpotId == id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Rating rating)
        {
            if (id != rating.RatingId)
            {
                return BadRequest(new Error
                {
                    Code = "400",
                    Description = "BAD_REQUEST : id passed does not match RatingId in updated rating."
                });
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