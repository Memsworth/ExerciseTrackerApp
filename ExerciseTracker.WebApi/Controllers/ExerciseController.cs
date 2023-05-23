using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExerciseTracker.DataAccess;
using ExerciseTracker.Domain.Abstractions.Services;
using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        
        /*
        // GET: api/Exercise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseItem>>> GetExerciseItems()
        {
          if (_exerciseService.ExerciseItems == null)
          {
              return NotFound();
          }
            return await _exerciseService.ExerciseItems.ToListAsync();
        }

        // GET: api/Exercise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseItem>> GetExerciseItem(int id)
        {
          if (_exerciseService.ExerciseItems == null)
          {
              return NotFound();
          }
            var exerciseItem = await _exerciseService.ExerciseItems.FindAsync(id);

            if (exerciseItem == null)
            {
                return NotFound();
            }

            return exerciseItem;
        }
        
        // PUT: api/Exercise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExerciseItem(int id, ExerciseItem exerciseItem)
        {
            if (id != exerciseItem.Id)
            {
                return BadRequest();
            }

            _exerciseService.Entry(exerciseItem).State = EntityState.Modified;

            try
            {
                await _exerciseService.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseItemExists(id))
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
*/
        // POST: api/Exercise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExerciseItem>> PostExerciseItem(ExerciseItem exerciseItem)
        {
            await _exerciseService.AddExerciseAsync(exerciseItem);
            return CreatedAtAction("PostExerciseItem", new { id = exerciseItem.Id }, exerciseItem);
        }

        /*
        // DELETE: api/Exercise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseItem(int id)
        {
            if (_exerciseService.ExerciseItems == null)
            {
                return NotFound();
            }
            var exerciseItem = await _exerciseService.ExerciseItems.FindAsync(id);
            if (exerciseItem == null)
            {
                return NotFound();
            }

            _exerciseService.ExerciseItems.Remove(exerciseItem);
            await _exerciseService.SaveChangesAsync();

            return NoContent();
        }

        private bool ExerciseItemExists(int id)
        {
            return (_exerciseService.ExerciseItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        */
    }
}
