using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkApi.Models;

namespace ParkApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParkApiContext _db;

    public ParksController(ParkApiContext db)
    {
      _db = db;
    }

    // GET api/parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string state, string climate, string dogFriendly)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();

      if (state != null)
      {
        query = query.Where(e => e.State == state);
      }

      if (climate != null)
      {
        query = query.Where(e => e.Climate == climate);
      }

      if (dogFriendly != null)
      {
        query = query.Where(e => e.DogFriendly == dogFriendly);
      }
      return await _db.Parks.ToListAsync();
    }

    // GET: api/Parks/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    // POST api/parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    // PUT: api/Animals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Parks.Update(park);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
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

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }

    // DELETE: api/Parks/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    // [HttpGet]
    // public IActionResult GetParks([FromQuery] ParkParameters parkParameters)
    // {
    //   var parks = _db.Parks.GetParks(parkParameters);
    //   _logger.LogInfo($"Returned {parks.Count()} owners from database.");
    //   return Ok(parks);
    // }
  }
}
