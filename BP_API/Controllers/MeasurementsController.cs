using BP_API.Data;
using BP_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;

namespace BP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementsController : ControllerBase 
    {
        private readonly LogContext _context;
        public MeasurementsController(LogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurements()
        {
            return await _context.measurements.ToListAsync();
        }

        [HttpGet("date")]
        public async Task<ActionResult<Measurement>> GetMeasurement(DateOnly date)
        {
            var measurement = await _context.measurements.FindAsync(date);

            if(measurement == null)
            {
                return NotFound();
            }
            return measurement;
        }

        [HttpPost]
        public async Task<ActionResult<Measurement>> AddMeasurement(Measurement measurement)
        {
            _context.measurements.Add(measurement);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMeasurement), new {date = measurement.Date}, measurement);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMeasurement(DateOnly date, Measurement measurement)
        {
            if(date == measurement.Date)
            {
                //update measurement here
                _context.Entry(measurement).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return BadRequest("");
            }
        }

        [HttpDelete("date")]
        public async Task<IActionResult> Delete(DateOnly date)
        {
            var measurement = await _context.measurements.FindAsync(date);

            if(measurement == null)
            {
                return NotFound();
            }

            _context.measurements.Remove(measurement);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}